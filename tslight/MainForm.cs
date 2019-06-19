using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace tslight
{
    /// Description of MainForm.
    public partial class MainForm : Form
	{
		public string AppDir; // путь к папке приложения
		public string sLogin; // логин пользователя для сервера Transaq
		public string sPassword; // пароль пользователя для сервера Transaq
		public string ServerIP; // IP адрес сервера Transaq
		public string ServerPort; // номер порта сервера Transaq
        public int session_timeout;
        public int request_timeout;

 
 
        public Position currentPosition = null;
                
        public class ComboboxItem {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString() {  return Text; }
        }

        private bool bConnected;
        private bool bConnecting;
		
		public DataSet_tslight DTS; // DataSet для таблиц с данными
		
		public char PointChar; // символ для замены точки в числах
        private bool PassHide = true; // флаг прячем ли пароль


        private event NewStringDataHandler onNewFormDataEvent;
        private event NewStringDataHandler onNewSecurityEvent;
        private event NewStringDataHandler onNewTimeframeEvent;
        private event NewBoolDataHandler onNewStatusEvent;
        private event NewStringDataHandler onOrdersPublished;
        private event quotationDelegate onQuotation;
        private event PositionDelegate onPositionSuscriber;
        private event NewStringDataHandler onMamushkaStatusResponse;


        public static XmlSerializer serializer4orders;
        public static XmlReaderSettings xs;


        //================================================================================
        public MainForm()
		{
			// определение папки, в которой запущена программа
			string path = Application.ExecutablePath;
			AppDir = path.Substring(0, path.LastIndexOf('\\')+1);

			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();

			// определение разделителя в числах на компьютере (запятая или точка)
			PointChar = ',';
			string str = (1.2).ToString();
			if (str.IndexOf('.') > 0) PointChar = '.';

            XmlRootAttribute rootNodeOrders = new XmlRootAttribute { ElementName = "orders" };
            Type deserializeType = typeof(quotations);
            deserializeType = typeof(orders);
            serializer4orders = new XmlSerializer(deserializeType, rootNodeOrders);

            xs = new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                ConformanceLevel = ConformanceLevel.Fragment,
                ProhibitDtd = false
            };
        }

		//================================================================================
		void MainFormLoad(object sender, EventArgs e)
		{

            ctl_Tabs.SelectTab("tab_Param");
           
            // параметры по умолчанию
            ServerIP = "tr1.finam.ru"; 
            ServerPort = "3900";

            loadLogginDetails();

            session_timeout = 25;
            request_timeout = 10;                       

            comboBox1.Items.Add(new ComboboxItem() { Text = "FORTS", Value = 4 });
            comboBox1.Items.Add(new ComboboxItem() { Text = "ММВБ", Value = 1 });
            comboBox1.Items.Add(new ComboboxItem() { Text = "SPBEX", Value = 7 });
            comboBox1.Items.Add(new ComboboxItem() { Text = "INF", Value = 8 });
            comboBox1.Items.Add(new ComboboxItem() { Text = "MMA", Value = 14 });
            comboBox1.Items.Add(new ComboboxItem() { Text = "ETS", Value = 8 });

            comboBox1.SelectedIndex = 0;


            edt_Login.Text = sLogin;
            edt_Password.Text = sPassword;
			edt_IP.Text = ServerIP;
			edt_Port.Text = ServerPort;

            bConnected = false;
            bConnecting = false;

            Enable_Password_Controls(false);

            Init_Data();

            // открытие лог-файла
            log.StartLogging(AppDir + "log" + DateTime.Now.ToString("yyMMdd") + ".txt");

            TXmlConnector.statusTimeout = session_timeout * 1000;

            TXmlConnector.ConnectorSetCallback(OnNewFormData, OnNewSecurity, OnNewTimeframe, OnNewStatus );            

            this.onNewFormDataEvent += new NewStringDataHandler(Add_FormData);
            this.onNewSecurityEvent += new NewStringDataHandler(Add_Security);
            this.onNewTimeframeEvent += new NewStringDataHandler(Add_Timeframe);
            this.onNewStatusEvent += new NewBoolDataHandler(ConnectionStatusReflect);

            TXmlConnector.Orders4HMISubscribe(OrdersSubscriber);
            this.onOrdersPublished += new NewStringDataHandler(processOrdersDistribution);


            OportunityMonitor.init();

            TXmlConnector.FormReady = true;

            string LogPath = AppDir + "\0";

            if (TXmlConnector.ConnectorInitialize(LogPath, 3)) TXmlConnector.statusDisconnected.Set();

            OportunityMonitor.subscribeQuotationUpdate( quotationCall );
            this.onQuotation += new quotationDelegate( setQuotationPrice );

            OportunityMonitor.PositionPublisherCallback( PositionPublisherCall );
            onPositionSuscriber += new PositionDelegate( setTakingClosingPosition );

            MamuschkaRepeater.mamushkaStatusSubscribe(mamuschkaStatusCall);
            onMamushkaStatusResponse += new NewStringDataHandler(setMamushkaServerStatus);
            MamuschkaRepeater.monitorMamuschkaServer();

        }

        private void mamuschkaStatusCall(string data)
        {
            this.Invoke(this.onMamushkaStatusResponse, new object[] { data });
        }

        public void OrdersSubscriber(string data)
        {
            this.Invoke(this.onOrdersPublished, new object[] { data });

        }

        private void quotationCall(double OrderPrice) {
            this.Invoke(onQuotation, new object[] { OrderPrice });
        }

        private void PositionPublisherCall( Position position )
        {
            this.Invoke(onPositionSuscriber, new object[] { position });
        }
        public void setQuotationPrice (double quotationPrice) {
            label5.Text = quotationPrice.ToString( System.Globalization.CultureInfo.GetCultureInfo("en-US") );
        }

        private void OnNewFormData(string data)
        {
            this.Invoke(onNewFormDataEvent, new object[] { data }); 
        }
        private void OnNewSecurity(string data)
        {
            this.Invoke(onNewSecurityEvent, new object[] { data }); 
        }
        private void OnNewTimeframe(string data)
        {
            this.Invoke(onNewTimeframeEvent, new object[] { data }); 
        }
        private void OnNewStatus(bool status)
        {
            this.Invoke(onNewStatusEvent, new object[] { status }); 
        }

        //================================================================================
        void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
            MamuschkaRepeater.stopMonitoringMamuschkaServer();
            TXmlConnector.FormReady = false;

            if (bConnected || bConnecting)
			{
				Transaq_Disconnect();
			}

            TXmlConnector.ConnectorUnInitialize();

            log.StopLogging();

            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }

		
		//================================================================================
		public void ShowStatus(string status_str)
		{
			// вывод сообщения в строке статуса формы
			txt_Status.Text = status_str;
			txt_Status.Refresh();
		}
		
		//================================================================================
		public void Init_Data()
		{
			// создание объекта DataSet с таблицами 
			DTS = new DataSet_tslight();
		}

		//================================================================================
		void Transaq_Connect()
		{

			// чтение параметров из формы
			sLogin = edt_Login.Text;
			sPassword = edt_Password.Text;
			ServerIP = edt_IP.Text;
			ServerPort = edt_Port.Text;
			
			// проверка наличия параметров
			if (sLogin.Length == 0)
			{
				ShowStatus("Не указан логин");
				return;
			}
			if (sPassword.Length == 0)
			{
				ShowStatus("Не указан пароль");
				return;
			}
			if (ServerIP.Length == 0)
			{
				ShowStatus("Не указан IP-адрес");
				return;
			}
			if (ServerPort.Length == 0)
			{
				ShowStatus("Не указан порт");
				return;
			}

            ConnectingReflect();

			// очистка таблиц с данными
			DTS.t_timeframe.Clear();
			DTS.t_security.Clear();
            DTS.t_candle.Clear();

            DTS.t_my_securities.Clear();
            DTS.t_my_takingPositions.Clear();
            DTS.t_my_ClosingPositions.Clear();

            // формирование текста команды
            string cmd = "<command id=\"connect\">";
			cmd = cmd + "<login>" + sLogin + "</login>";
			cmd = cmd + "<password>" + sPassword + "</password>";
			cmd = cmd + "<host>" + ServerIP + "</host>";
			cmd = cmd + "<port>" + ServerPort + "</port>";
            cmd = cmd + "<rqdelay>100</rqdelay>";
            cmd = cmd + "<session_timeout>" + session_timeout.ToString() + "</session_timeout> ";
            cmd = cmd + "<request_timeout>" + request_timeout.ToString() + "</request_timeout>"; 
			cmd = cmd + "</command>";

			// отправка команды
            log.WriteLog("SendCommand: <command id=\"connect\"><login>" + sLogin + "</login><password>*</password><host>" + ServerIP + "</host><port>" + ServerPort + "</port><logsdir>" + AppDir + "</logsdir><rqdelay>100</rqdelay></command>");
            TXmlConnector.statusDisconnected.Reset();
            string res = TXmlConnector.ConnectorSendCommand(cmd);
            log.WriteLog("ServerReply: " + res);
			
		}

        //================================================================================
        // отключение коннектора от сервера Транзак
        void Transaq_Disconnect() {
			
            DisconnectingReflect();
			
			string cmd = "<command id=\"disconnect\"/>";

            log.WriteLog("SendCommand: " + cmd);
            TXmlConnector.statusDisconnected.Reset();
            string res = TXmlConnector.ConnectorSendCommand(cmd);
            log.WriteLog("ServerReply: " + res);

		}

        //================================================================================
        // запрос исторических данных для инструмента

        void Get_Transaq_History(int SecurityID, int TimeframeID, int HistoryLength, bool ResetFlag) {
			
			string cmd = "<command id=\"gethistorydata\" ";
			cmd = cmd + "secid=\"" + SecurityID.ToString() + "\" ";
			cmd = cmd + "period=\"" + TimeframeID.ToString() + "\" ";
			cmd = cmd + "count=\"" + HistoryLength.ToString() + "\" ";
			string s = "false";
			if (ResetFlag) s = "true";
			cmd = cmd + "reset=\""+s+"\"/>";
            
            log.WriteLog("SendCommand: " + cmd);
            string res = TXmlConnector.ConnectorSendCommand(cmd);
            log.WriteLog("ServerReply: " + res);
        }

        void ConnectingReflect()
        {
            bConnecting = true;
            txt_Connect.Text = "connecting";
            btn_Connect.Text = "Подключаю";
            btn_Connect.Refresh();
            txt_Connect.Refresh();
            ShowStatus("Подключение к серверу...");
         }

        void DisconnectingReflect() {
            bConnecting = false;
            txt_Connect.Text = "disconnecting";
            btn_Connect.Text = "Отключаю";
            btn_Connect.Refresh();
            txt_Connect.Refresh();
            ShowStatus("Отключение от сервера...");
        }

        void loadMyInstruments()
        {
            string line;
            StreamReader file = new StreamReader(@"myInstruments.xml");
            while ((line = file.ReadLine()) != null)
            {
                string[] sec = line.Split(';');

                int id = int.Parse(sec[0]);
                string secname = sec[1];
                string code = sec[2];
                int lotsize = int.Parse(sec[3]);
                int decimals = int.Parse(sec[4]);
                int market = int.Parse(sec[5]);
                string board = sec[6];

                DTS.t_my_securities.Add_Row(id, secname, code, lotsize, decimals, market, board);
            }
        }

        //================================================================================
        // отображение состояния подключения на форме
        void ConnectionStatusReflect(bool connected) {
			
            bConnected = connected; 
            bConnecting = false;

            if (connected) {
                    dg_Security.DataSource = DTS.t_security;
                    dg_Security.Refresh();

                    dataGridViewMyInstruments.DataSource = DTS.t_my_securities;
                    dataGridViewMyInstruments.Refresh();

                    dg_takingPositions.DataSource = DTS.t_my_takingPositions;
               
                    dg_takingPositions.Refresh();
                    dg_takingPositions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    dg_closingPositions.DataSource = DTS.t_my_ClosingPositions;
                    dg_closingPositions.Refresh();
                    dg_closingPositions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                    txt_Connect.Text = "online";
                    btn_Connect.Text = "Отключить";
                    ShowStatus("Подключение установлено");
                    Enable_Password_Controls(true);

                    loadMyInstruments();
                    saveLogginDetails();
                    ctl_Tabs.SelectTab("tabMyInstruments");

            } else {

                    DTS.t_timeframe.Clear();
                    DTS.t_security.Clear();
                    DTS.t_candle.Clear();
                    DTS.t_my_securities.Clear();
                    DTS.t_my_takingPositions.Clear();
                    DTS.t_my_ClosingPositions.Clear();

                    dg_Security.Refresh();
                    dataGridViewMyInstruments.Refresh();
                    dg_takingPositions.Refresh();
                    dg_closingPositions.Refresh();

                    txt_Connect.Text = "offline";
			        btn_Connect.Text  = "Подключить";
			        ShowStatus("Подключение разъединено");
                    Enable_Password_Controls(false);
            }
            
			btn_Connect.Refresh();
			txt_Connect.Refresh();
		}

        public void Add_FormData(string data) {
            txtBoxAns.AppendText(DateTime.Now.ToString("HH:mm:ss.fff") + "   " + data + "\n =================================================== \n");
            txtBoxAns.ScrollToCaret();
        }       

        public void setTakingClosingPosition( Position position )
        {
            this.currentPosition = position;
            
            label14.Text = position.price.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            label11.Text = position.takeProfit.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            label10.Text = position.stopLoss.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"));

        }
                
       public void setMamushkaServerStatus(string response){

            if (response == "connected"){
                label16.ForeColor = System.Drawing.Color.Green;
                label16.BackColor = System.Drawing.Color.Green;

            }
            else if (response == "disconnected"){
                label16.ForeColor = System.Drawing.Color.Yellow;
                label16.BackColor = System.Drawing.Color.Yellow;
            }
            else if (response == "failed"){
                label16.ForeColor = System.Drawing.Color.Red;
                label16.BackColor = System.Drawing.Color.Red;
            }
            else {
                label16.ForeColor = System.Drawing.Color.Red;
                label16.BackColor = System.Drawing.Color.Red;
            }

        }

        //================================================================================
        // добавление записи о таймфрейме

        public void Add_Timeframe(string data) { 
			string[] tf = data.Split(';');
			if (tf.Length < 3) return;
			
			int id = int.Parse(tf[0]);
			int length = int.Parse(tf[1]);
			string name = tf[2];
			
			DTS.t_timeframe.Add_Row(id, length, name);
		}

        //================================================================================
        // добавление записи об инструменте

        public void Add_Security(string data) { 

			string[] sec = data.Split(';');
			if (sec.Length < 16) return;			
			int id = int.Parse(sec[0]);
            bool active = bool.Parse(sec[1]);
			string code = sec[2];
            string board = sec[3];
            string secname = sec[4];
            int decimals = int.Parse(sec[5]);
            int market = int.Parse(sec[6]);
            //string sectype = sec[7];
            //bool usecredit = bool.Parse(sec[8].Replace("yes", "true").Replace("no","false"));
            //bool bymarket = bool.Parse(sec[9].Replace("yes", "true").Replace("no", "false"));
            //bool nosplit = bool.Parse(sec[10].Replace("yes", "true").Replace("no", "false"));
            //bool immorcancel = bool.Parse(sec[11].Replace("yes", "true").Replace("no","false"));
            //bool cancelbalance = bool.Parse(sec[12].Replace("yes", "true").Replace("no", "false"));
            //double minstep = double.Parse(sec[13].Replace('.', PointChar));
			int lotsize = int.Parse(sec[14]);
            //double pointcost = double.Parse(sec[15].Replace('.', PointChar));

            // ограничимся инструментами ММВБ, только акции
            ComboboxItem mySelectedMarket = (ComboboxItem)comboBox1.SelectedItem;
            int marketIndex = (int)mySelectedMarket.Value;

            if (market == marketIndex && active) {
                DTS.t_security.Add_Row(id, secname, code, lotsize, decimals, market, board);
            }
		}

        //================================================================================
        // если подключен или подключается
        void btn_Connect_Click(object sender, EventArgs e) {
			
            if (bConnected || bConnecting)	{
				Transaq_Disconnect();
                if ( checkBox1.Checked == true ){
                    MamuschkaRepeater.disconnect();
                }
            }
            else {
                if (!bConnecting)
                {
                    Transaq_Connect();
                    if ( checkBox1.Checked == true ){
                        MamuschkaRepeater.connect();
                    }
                    
                }
			}			
		}

        //================================================================================
      
        void loadLogginDetails()
        {
            string line;
            try {
                StreamReader file = new StreamReader(@"myLogginDetails.xml");
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');

                    if (parts != null && parts[0] != null) {
                        sLogin = parts[0];
                        sPassword = parts[1];
                    }
                }
            }
            catch (FileNotFoundException) {
            }

        }

        void saveLogginDetails()
        {            
            string text2file = "";

            text2file += sLogin + ";" + sPassword + ";\n";
         
            File.WriteAllText("myLogginDetails.xml", text2file);
        }

        void saveMyInstruments()
        {
            DataTable_security newDataTable = new DataTable_security();
            string DataTable2file = "";
            foreach (DataRow_security row in DTS.t_my_securities.Rows)
            {
                DataTable2file += row.security_id + ";" + row.security_name + ";" + row.security_code + ";" + row.lotsize + ";" + row.decimals + ";" + row.market + ";" + row.board + "; \n"; 
            }

            File.WriteAllText("myInstruments.xml", DataTable2file);
        }


        void Enable_Password_Controls(bool bEnable)
        {
            // установка состояния элементов управления для смены пароля
            txtOldPass.Enabled = bEnable;
            txtNewPass.Enabled = bEnable;
            checkHide.Enabled = bEnable;
            btnPassChange.Enabled = bEnable;
        }

        private void btnPassChange_Click(object sender, EventArgs e)
        {
            // Проверяем пароль
            // Правило: только латинские буквы и цифры, минимум 4, максимум 19
            string passPattern = @"^[a-zA-Z0-9]{4,20}$";

            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;

            string result;
            Match m = Regex.Match(newPass, passPattern);

            if (!bConnected)
            {
                ShowStatus("Для смены пароля подключитесь к серверу");
            }
            else if (txtNewPass.Text.Length == 0)
            {
                ShowStatus("Введите новый пароль");
            }
            else if (m.Success)
            {
                string cmd = String.Format("<command id=\"change_pass\" oldpass=\"{0}\" newpass=\"{1}\" />", oldPass, newPass);
                log.WriteLog("SendCommand: <command id=\"change_pass\" oldpass=\"*\" newpass=\"*\" />");
                result = TXmlConnector.ConnectorSendCommand(cmd);
                log.WriteLog("ServerReply: " + result);
                ShowStatus(result);
                XDocument aXmlDoc = XDocument.Load(new System.IO.StringReader(result));
                if (aXmlDoc.Root.Name == "result")
                {
                    if (aXmlDoc.Root.Attribute("success").Value == "true")
                    {
                        ShowStatus("Пароль изменен");
                        log.WriteLog("Password was changed");
                        txtOldPass.Text = "";
                        txtNewPass.Text = "";
                    }
                    else if (aXmlDoc.Root.Attribute("success").Value == "false")
                    {
                        ShowStatus(aXmlDoc.Root.Value);
                    }
                }
                else
                {
                    ShowStatus("Произошла ошибка");
                }
            }
            else
            {
                ShowStatus("Введите верный новый пароль");
            }

        }

        private void checkHide_CheckedChanged(object sender, EventArgs e)
        {
            PassHide = checkHide.Checked;
            if (PassHide)
            {
                txtNewPass.PasswordChar = '*';
            }
            else
            {
                txtNewPass.PasswordChar = (char)0;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

            System.Windows.Forms.TextBox myTextbox = (System.Windows.Forms.TextBox)sender;
            
            if (Double.TryParse(myTextbox.Text,
                 System.Globalization.NumberStyles.Any,
                 System.Globalization.CultureInfo.GetCultureInfo("en-US") , 
                 out double delta)) {

                myTextbox.ForeColor = System.Drawing.Color.Black;
                OportunityMonitor.deltaOnHMI = delta;
                OportunityMonitor.calculateOportunities();
            }
            else{
                myTextbox.ForeColor = System.Drawing.Color.Red;
            }         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPosition != null)
            {
                OportunityMonitor.sendOrder2Transaq(currentPosition);
                if ( checkBox1.Checked == true ) {
                    MamuschkaRepeater.forwardPosition(currentPosition);
                }
            }

        }        

        private void button2_Click(object sender, EventArgs e) {

            if ( OportunityMonitor.trend == "growing"){
                button2.BackgroundImage = Properties.Resources.descend;
                OportunityMonitor.trend = "descending";
                label7.Text = "продажа";
                label7.ForeColor = System.Drawing.Color.Salmon;
                label6.Text = "покупка (take profit)";
                label6.ForeColor = System.Drawing.Color.SeaGreen;
                label8.Text = "покупка (stop loss)";
                label8.ForeColor = System.Drawing.Color.SeaGreen;
            }else  {            
                button2.BackgroundImage = Properties.Resources.grow;
                OportunityMonitor.trend = "growing";
                label7.Text = "покупка";
                label7.ForeColor = System.Drawing.Color.SeaGreen;
                label6.Text = "продажа (take profit)";
                label6.ForeColor = System.Drawing.Color.Salmon;
                label8.Text = "продажа (stop loss)";
                label8.ForeColor = System.Drawing.Color.Salmon;
            }
            OportunityMonitor.calculateOportunities();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox myTextbox = (System.Windows.Forms.TextBox)sender;

            if (int.TryParse(myTextbox.Text, out int lots))
            {
                myTextbox.ForeColor = System.Drawing.Color.Black;
                OportunityMonitor.lotsOnHMI = lots;
            }
            else
            {
                myTextbox.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox myTextbox = (TextBox)sender;

            if (Double.TryParse(myTextbox.Text,
                 System.Globalization.NumberStyles.Any,
                 System.Globalization.CultureInfo.GetCultureInfo("en-US"),
                 out double input))
            {

                myTextbox.ForeColor = Color.Black;
                OportunityMonitor.orderCoefficientOnHMI = input;
                OportunityMonitor.calculateOportunities();
            }
            else
            {
                myTextbox.ForeColor = Color.Red;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox myTextbox = (TextBox)sender;

            if (Double.TryParse(myTextbox.Text,
                 System.Globalization.NumberStyles.Any,
                 System.Globalization.CultureInfo.GetCultureInfo("en-US"),
                 out double input))
            {

                myTextbox.ForeColor = Color.Black;
                OportunityMonitor.stopLossCoefficientOnHMI = input;
                OportunityMonitor.calculateOportunities();
            }
            else
            {
                myTextbox.ForeColor = Color.Red;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            TextBox myTextbox = (TextBox)sender;

            if (Double.TryParse(myTextbox.Text,
                 System.Globalization.NumberStyles.Any,
                 System.Globalization.CultureInfo.GetCultureInfo("en-US"),
                 out double input))
            {

                myTextbox.ForeColor = Color.Black;
                OportunityMonitor.takeProfitCoefficientOnHMI = input;
                OportunityMonitor.calculateOportunities();
            }
            else
            {
                myTextbox.ForeColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OportunityMonitor.sendCancelAll2Transaq();
            if ( checkBox1.Checked == true ){
                MamuschkaRepeater.cancellAll();
            }
        }

        private void dataGridViewMyInstruments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView myObject = (DataGridView)sender;
            if (myObject.CurrentRow == null) return;
            string seccode = myObject.CurrentRow.Cells[2].Value.ToString();
            int decimals = (int)myObject.CurrentRow.Cells[4].Value;
            int market = (int)myObject.CurrentRow.Cells[5].Value;
            string board = myObject.CurrentRow.Cells[6].Value.ToString();

            OportunityMonitor.monitoredSecurityOnHMI = new Security(seccode, board, decimals, market);
            OportunityMonitor.addSecurityForMonitoring(new Security(seccode, board, decimals, market));

            string cmd = "<command id=\"subscribe\">";
            cmd = cmd + "   <quotations><security><board>" + board + "</board><seccode>" + seccode + "</seccode></security></quotations>";
            cmd = cmd + "</command>";

            string res = TXmlConnector.ConnectorSendCommand(cmd);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveMyInstruments();
        }

        private void onRemoveInstrument_Click(object sender, EventArgs e)
        {
            if (dataGridViewMyInstruments.CurrentRow == null) return;
            int id = (int)dataGridViewMyInstruments.CurrentRow.Cells[0].Value;

            dataGridViewMyInstruments.Rows.RemoveAt(dataGridViewMyInstruments.SelectedRows[0].Index);

            DTS.AcceptChanges();

            foreach (DataRow_security row in DTS.t_my_securities.Rows)
            {
                if (row != null && row.security_id == id)
                {
                    DTS.t_my_securities.Remove_Row(row);
                }
            }

            DTS.AcceptChanges();

        }

        private void save2myInstruments_Click(object sender, EventArgs e)
        {
            if (dg_Security.CurrentRow == null) return;
            DataGridViewRow currentRow = dg_Security.CurrentRow;


            int id = (int)currentRow.Cells[0].Value;
            string secname = currentRow.Cells[1].Value.ToString();
            string code = currentRow.Cells[2].Value.ToString();
            int lotsize = (int)currentRow.Cells[3].Value;
            int decimals = (int)currentRow.Cells[4].Value;
            int market = (int)currentRow.Cells[5].Value;
            string board = currentRow.Cells[6].Value.ToString();

            DTS.t_my_securities.Add_Row(id, secname, code, lotsize, decimals, market, board);           

        }

        private void processOrdersDistribution(string data)
        {

            XmlReader xr = XmlReader.Create(new StringReader(data), xs);
            orders orders = (orders)serializer4orders.Deserialize(xr);

            if (orders != null && orders.order != null)
            {
                for (int i = 0; i < orders.order.Length; i++)
                {
                    processOrder(orders.order[i]);
                }
            }
            if (orders != null && orders.stoporder != null)
            {
                for (int i = 0; i < orders.stoporder.Length; i++)
                {
                    processStopOrder(orders.stoporder[i]);
                }
            }

            xr.Close();
        }
        private void processOrder(Order order)
        {
            DataRow_order row = (DataRow_order)DTS.t_my_takingPositions.FindByID(order.transactionid);
            if (row != null)
            {
                DTS.t_my_takingPositions.Remove_Row(row);
            }
            DTS.t_my_takingPositions.AcceptChanges();
            DTS.t_my_takingPositions.Add_Row(order.seccode, order.buysell, order.price, order.status, order.transactionid);
            DTS.t_my_takingPositions.AcceptChanges();
            
        }

        private void processStopOrder(Stoporder stopOrder)
        {
            DataRow_stopOrder row = (DataRow_stopOrder)DTS.t_my_ClosingPositions.FindByID(stopOrder.transactionid);
            if (row != null)
            {
                DTS.t_my_ClosingPositions.Remove_Row(row);
            }
            DTS.t_my_ClosingPositions.AcceptChanges();
            DTS.t_my_ClosingPositions.Add_Row(stopOrder.seccode, stopOrder.buysell, stopOrder.stoploss.activationprice, stopOrder.takeprofit.activationprice, stopOrder.status, stopOrder.transactionid);
            DTS.t_my_ClosingPositions.AcceptChanges();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true){
                checkBox1.Text = "да  ";
                MamuschkaRepeater.connect();
            }else{
                checkBox1.Text = "нет ";
                MamuschkaRepeater.disconnect();
            }
        }
    }
}

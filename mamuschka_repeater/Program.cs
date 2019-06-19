using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using tslight;

namespace mamuschka_repeater
{
    class Program
    {
        static string sAppDir; // путь к папке приложения
        static string sLogPath;
        static string sLogin; // логин пользователя для сервера Transaq
        static string sPassword; // пароль пользователя для сервера Transaq
        static string sTransaqServerIP; // IP адрес сервера Transaq
        static string sTransaqServerPort; // номер порта сервера Transaq
        static int session_timeout;
        static int request_timeout;

        static event NewStringDataHandler onNewFormDataEvent;
        static event NewStringDataHandler onNewSecurityEvent;
        static event NewStringDataHandler onNewTimeframeEvent;
        static event NewBoolDataHandler onNewStatusEvent;
        static event PositionDelegate onPositionSuscriber;
        public static bool bConnected;
        static bool bConnecting;

        public static XmlSerializer serializer4orders;
        public static XmlReaderSettings xs;
        static char PointChar; // символ для замены точки в числах

        static Position currentPosition = null;


        ///////////////////////////////////////////////////////////////////////
        /// PROGRAM'S SETTINGS
        ///////////////////////////////////////////////////////////////////////
        static void loadSettings() {
            try
            {
                sAppDir = Assembly.GetEntryAssembly().Location;
                sAppDir = sAppDir.Substring(0, sAppDir.LastIndexOf('\\') + 1);
                sLogPath = sAppDir + "\0";
                PointChar = ',';
                string str = (1.2).ToString();
                if (str.IndexOf('.') > 0) PointChar = '.';

                string line;
                StreamReader file = new StreamReader(@"mySettings.conf");
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');

                    if (parts != null && parts[0] != null)
                    {
                        sLogin = parts[0];
                        sPassword = parts[1];
                        sTransaqServerIP = parts[2];
                        sTransaqServerPort = parts[3];
                        session_timeout = Int32.Parse(parts[4]);
                        request_timeout = Int32.Parse(parts[5]);
                        OportunityMonitor.operationMode = parts[6];
                    }
                }
                // проверка наличия параметров
                if (sLogin.Length == 0)
                {
                    ShowStatus("Не указан логин");
                }
                if (sPassword.Length == 0)
                {
                    ShowStatus("Не указан пароль");
                }
                if (sTransaqServerIP.Length == 0)
                {
                    ShowStatus("Не указан IP-адрес");
                }
                if (sTransaqServerPort.Length == 0)
                {
                    ShowStatus("Не указан порт");
                }
            } 
            catch (FileNotFoundException)  { }
        }

        static void saveSettings()
        {
            string text2file = "";

            text2file += sLogin + ";" + sPassword + ";\n";

            File.WriteAllText("mySettings.conf", text2file);
        }

        ///////////////////////////////////////////////////////////////////////
        /// EVENT TRIGGERS
        ///////////////////////////////////////////////////////////////////////

        static void PositionPublisherCall(Position position)
        {
            onPositionSuscriber.BeginInvoke(position, null, null);            
        }
        static void OnNewFormData(string data)
        {
            onNewFormDataEvent.BeginInvoke(data,null,null);            
        }
        static void OnNewSecurity(string data)
        {
            onNewSecurityEvent.BeginInvoke(data, null, null);
        }
        static void OnNewTimeframe(string data)
        {
            onNewTimeframeEvent.BeginInvoke(data,null,null);            
        }
        static void OnNewStatus(bool status)
        {
            onNewStatusEvent.BeginInvoke(status, null, null);            
        }
    

        ///////////////////////////////////////////////////////////////////////
        /// EVENT HANDLERS
        ///////////////////////////////////////////////////////////////////////

        static void setTakingClosingPosition(Position position)
        {
            currentPosition = position;
        }

        static void loadEventHandlers() {

            onNewFormDataEvent += new NewStringDataHandler(ShowStatus);
            onNewSecurityEvent += new NewStringDataHandler(ShowStatus);
            onNewTimeframeEvent += new NewStringDataHandler(ShowStatus);
            onNewStatusEvent += new NewBoolDataHandler(ConnectionStatusReflect);
            onPositionSuscriber += new PositionDelegate(setTakingClosingPosition);

            bConnected = false;
            bConnecting = false;

        }
        ///////////////////////////////////////////////////////////////////////
        /// LOGGING
        ///////////////////////////////////////////////////////////////////////
        static void ShowStatus(string status_str)
        {
            // вывод сообщения в строке статуса формы
            log.WriteLog(status_str);
        }

        static void ConnectingReflect()
        {
            bConnecting = true;
            ShowStatus("connecting to server...");
            ShowStatus("Подключение к серверу...");
        }
        static void DisconnectingReflect()
        {
            bConnecting = false;
            ShowStatus("disconnecting from server...");
            ShowStatus("Отключение от сервера...");
        }
        static void ConnectionStatusReflect(bool connected)
        {
            bConnected = connected;
            bConnecting = false;

            if (connected)
            {
                ShowStatus("online");
                ShowStatus("Подключение установлено");
            }
            else
            {
                ShowStatus("offline");
                ShowStatus("Подключение разъединено");
            }
        }

        ///////////////////////////////////////////////////////////////////////
        /// TRANSAQ METHODS
        ///////////////////////////////////////////////////////////////////////

        public static void Transaq_Connect()
        {
            ConnectingReflect();
            // формирование текста команды
            string cmd = "<command id=\"connect\">";
            cmd = cmd + "<login>" + sLogin + "</login>";
            cmd = cmd + "<password>" + sPassword + "</password>";
            cmd = cmd + "<host>" + sTransaqServerIP + "</host>";
            cmd = cmd + "<port>" + sTransaqServerPort + "</port>";
            cmd = cmd + "<rqdelay>100</rqdelay>";
            cmd = cmd + "<session_timeout>" + session_timeout.ToString() + "</session_timeout> ";
            cmd = cmd + "<request_timeout>" + request_timeout.ToString() + "</request_timeout>";
            cmd = cmd + "</command>";

            // отправка команды
            log.WriteLog("Transaq_Connect:::ServerRequest " + cmd );
            TXmlConnector.statusDisconnected.Reset();
            string res = TXmlConnector.ConnectorSendCommand(cmd);
            log.WriteLog("Transaq_Connect:::ServerReply " + res);
        }
        // отключение коннектора от сервера Транзак
        public static void Transaq_Disconnect()
        {
            DisconnectingReflect();
            string cmd = "<command id=\"disconnect\"/>";
            log.WriteLog("SendCommand: " + cmd);
            TXmlConnector.statusDisconnected.Reset();
            string res = TXmlConnector.ConnectorSendCommand(cmd);
            log.WriteLog("ServerReply: " + res);
        }


        static void Main(string[] args)
        {
            loadSettings();
            loadEventHandlers();

            log.StartLogging(sAppDir + "log" + DateTime.Now.ToString("yyMMdd") + ".txt");

            TXmlConnector.statusTimeout = session_timeout * 1000;
            TXmlConnector.ConnectorSetCallback(OnNewFormData, OnNewSecurity, OnNewTimeframe, OnNewStatus);
            TXmlConnector.FormReady = true;
            if (TXmlConnector.ConnectorInitialize(sLogPath, 3)) TXmlConnector.statusDisconnected.Set();
            
            OportunityMonitor.init();
            OportunityMonitor.PositionPublisherCallback(PositionPublisherCall);

            MyTcpServer tcpServer = new MyTcpServer();
            tcpServer.start();   

        }
    }
}

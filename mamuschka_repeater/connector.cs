using System;
using System.Threading;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace tslight
{
	static class MarshalUTF8
	{
		private static UTF8Encoding _utf8;

		//--------------------------------------------------------------------------------
		static MarshalUTF8()
		{
			_utf8 = new UTF8Encoding();
		}

		//--------------------------------------------------------------------------------
		public static IntPtr StringToHGlobalUTF8(String data)
		{
            Byte[] dataEncoded = _utf8.GetBytes(data + "\0");

			int size = Marshal.SizeOf(dataEncoded[0]) * dataEncoded.Length;

			IntPtr pData = Marshal.AllocHGlobal(size);

			Marshal.Copy(dataEncoded, 0, pData, dataEncoded.Length);

			return pData;
		}

		//--------------------------------------------------------------------------------
		public static String PtrToStringUTF8(IntPtr pData)
		{
			// this is just to get buffer length in bytes
			String errStr = Marshal.PtrToStringAnsi(pData);
			int length = errStr.Length;

			Byte[] data = new byte[length];
			Marshal.Copy(pData, data, 0, length);

			return _utf8.GetString(data);
		}
		//--------------------------------------------------------------------------------
	}

    delegate void NewStringDataHandler(string data);
    delegate void NewBoolDataHandler(bool data);


	static class TXmlConnector
	{
		const String EX_SETTING_CALLBACK = "Не смог установить функцию обратного вызова";
         
        delegate bool CallBackDelegate(IntPtr pData);
        //delegate bool CallBackExDelegate(IntPtr pData, IntPtr userData);
		
		static readonly CallBackDelegate myCallbackDelegate =  new CallBackDelegate(myCallBack);
        static readonly GCHandle callbackHandle = GCHandle.Alloc(myCallbackDelegate);

        private static bool bConnected; // флаг наличия подключения к серверу
        
        public static AutoResetEvent statusDisconnected = new AutoResetEvent(true);
        public static int statusTimeout;

        public static bool FormReady;

        static NewStringDataHandler send_new_form_data;
        static NewStringDataHandler send_new_security;
        static NewStringDataHandler send_new_timeframe;
        static NewBoolDataHandler send_new_status;
        static NewStringDataHandler onNewQuotation;
        static NewStringDataHandler onOrdersPublisher;
        static NewStringDataHandler onOrders4HMIPublisher;
        static NewStringDataHandler onMarketsPublisher;
        static NewStringDataHandler onClientPublisher;

        public static void OrdersSubscribe( NewStringDataHandler callback)  {
            onOrdersPublisher = new NewStringDataHandler(callback);
        }
        public static void Orders4HMISubscribe(NewStringDataHandler callback)
        {
            onOrders4HMIPublisher = new NewStringDataHandler(callback);
        }
        public static void MarketsSubscribe(NewStringDataHandler callback)
        {
            onMarketsPublisher = new NewStringDataHandler(callback);
        }
        public static void ClientSubscribe(NewStringDataHandler callback)
        {
            onClientPublisher = new NewStringDataHandler(callback);
        }


        public static void NewQuotationCallback(NewStringDataHandler callback)
        {
            onNewQuotation = new NewStringDataHandler(callback);
        }

        public static void ConnectorSetCallback(NewStringDataHandler new_form_data
                                                , NewStringDataHandler new_security
                                                , NewStringDataHandler new_timeframe
                                                , NewBoolDataHandler new_status )
        {
            if (!SetCallback(myCallbackDelegate)) {  throw (new Exception(EX_SETTING_CALLBACK));  }

            TXmlConnector.send_new_form_data = new_form_data;
            TXmlConnector.send_new_security = new_security;
            TXmlConnector.send_new_timeframe = new_timeframe;
            TXmlConnector.send_new_status = new_status;

        }


        //--------------------------------------------------------------------------------
        static bool myCallBack(IntPtr pData)
		{
            string res;
			String data = MarshalUTF8.PtrToStringUTF8(pData);
			FreeMemory(pData);

            res = Transaq_HandleData(data);
            if (res == "server_status") New_Status();
            return true;
		}

		//--------------------------------------------------------------------------------
         
        static void Form_AddText(string stringData)
        {
            if (FormReady)
                send_new_form_data.BeginInvoke(stringData, null, null);
        }

        static void On_New_Security(string stringData)
        {
            if (FormReady) 
                send_new_security.BeginInvoke(stringData, null, null);
        }

        static void On_New_Timeframe(string stringData)
        {
            if (FormReady) 
                send_new_timeframe.BeginInvoke(stringData, null, null);
        }
 
        static void New_Status()
        {
            if (FormReady) 
                send_new_status.BeginInvoke(bConnected, null, null);

            if (bConnected) {
                statusDisconnected.Reset();
            }else {
                statusDisconnected.Set();
            }
        }

        static void On_New_Quotation(string stringData)  {
            if (FormReady) {
                onNewQuotation.BeginInvoke(stringData, null, null);
            }
        }

        static void publishOrders(string stringData)
        {
            if (FormReady)
            {
                onOrdersPublisher.BeginInvoke(stringData, null, null);
                if (OportunityMonitor.operationMode == "manual")
                    onOrders4HMIPublisher.BeginInvoke(stringData, null, null);
            }
        }

        static void publishMarkets(string stringData)
        {
            if (FormReady)
            {
                onMarketsPublisher.BeginInvoke(stringData, null, null);
            }
        }

        static void publishClient(string stringData)
        {
            if (FormReady)
            {
                onClientPublisher.BeginInvoke(stringData, null, null);
            }
        }



        //--------------------------------------------------------------------------------
        public static String ConnectorSendCommand(String command)
		{

			IntPtr pData = MarshalUTF8.StringToHGlobalUTF8(command);
			IntPtr pResult = SendCommand(pData);

			String result = MarshalUTF8.PtrToStringUTF8(pResult);            

			Marshal.FreeHGlobal(pData);
			FreeMemory(pResult);

			return result;

		}


        public static bool ConnectorInitialize(String Path, Int16 LogLevel)
        {

            IntPtr pPath = MarshalUTF8.StringToHGlobalUTF8(Path);
            IntPtr pResult = Initialize(pPath, LogLevel);

            if (!pResult.Equals(IntPtr.Zero))
            {
                String result = MarshalUTF8.PtrToStringUTF8(pResult);
                Marshal.FreeHGlobal(pPath);
                FreeMemory(pResult);
                log.WriteLog(result);
                return false;
            }
            else
            {
                Marshal.FreeHGlobal(pPath);
                log.WriteLog("Initialize() OK");
                return true;
            }

        }

        public static void ConnectorUnInitialize()     {

            if (statusDisconnected.WaitOne(statusTimeout))    {

                IntPtr pResult = UnInitialize();

                if (!pResult.Equals(IntPtr.Zero))     {
                    String result = MarshalUTF8.PtrToStringUTF8(pResult);
                    FreeMemory(pResult);
                    log.WriteLog(result);
                }else {
                    log.WriteLog("UnInitialize() OK");
                }
            }else  {
                log.WriteLog("WARNING! Не дождались статуса disconnected. UnInitialize() не выполнено.");
            }

        }

        //================================================================================
        // обработка данных, полученных коннектором от сервера Транзак
        public static string Transaq_HandleData(string data) {
            
            string sTime = DateTime.Now.ToString("HH:mm:ss.fff");
            string info = "";

            // включить полученные данные в строку вывода в лог-файл
            string textForWindow = data;
            
            XmlReaderSettings xs = new XmlReaderSettings();
            xs.IgnoreWhitespace = true;
            xs.ConformanceLevel = ConformanceLevel.Fragment;
            xs.ProhibitDtd = false;
            XmlReader xr = XmlReader.Create(new System.IO.StringReader(data), xs);
            string section = "";
            string line = "";
            string str = "";
            string ename = "";
            string evalue = "";
            string attr = "";

            // обработка "узлов" 
            while (xr.Read())
            {
                switch (xr.NodeType)
                {
                    case XmlNodeType.Element:
                    case XmlNodeType.EndElement:
                        ename = xr.Name; break;
                    case XmlNodeType.Text:
                    case XmlNodeType.CDATA:
                    case XmlNodeType.Comment:
                    case XmlNodeType.XmlDeclaration:
                        evalue = xr.Value; break;
                    case XmlNodeType.DocumentType:
                        ename = xr.Name; evalue = xr.Value; break;
                    default: break;
                }

                //................................................................................
                // определяем узел верхнего уровня - "секцию"
                if (xr.Depth == 0) {

                    if (xr.NodeType == XmlNodeType.Element) {

                        section = ename;
                        if (section == "quotations"){
                            On_New_Quotation(data);
                            xr.Close();
                            return section;
                        }
                        if (section == "orders")
                        {
                            publishOrders(data);
                            xr.Close();
                            return section;
                        }
                        if (section == "markets")
                        {
                            publishMarkets(data);
                            xr.Close();
                            return section;
                        }
                        if (section == "client")
                        {
                            publishClient(data);
                            xr.Close();
                            return section;
                        }
                        if (section == "sec_info_upd" || section == "pits" || section == "news_header") {
                            xr.Close();
                            return section;
                        }
                        if (section != "securities" && section != "server_status" ) {
                            Form_AddText(textForWindow);
                            textForWindow = "";
                            xr.Close();
                            return section;
                        }                     

                    }    
                }
                //................................................................................
                // данные для инструментов
                if (section == "securities") {
                    if (ename == "security")  {
                        if (xr.NodeType == XmlNodeType.Element)   {
                            line = "";
                            str = "";
                            for (int i = 0; i < xr.AttributeCount; i++) {
                                str = str + xr.GetAttribute(i) + ";";
                            }
                        }
                        if (xr.NodeType == XmlNodeType.EndElement) {
                            //line = "add security: " + str;
                            On_New_Security(str);
                            str = "";
                        }
                    }
                    else {
                        if (xr.NodeType == XmlNodeType.Element)
                        {
                            for (int i = 0; i < xr.AttributeCount; i++) {
                                str = str + xr.GetAttribute(i) + ";";
                            }
                        }
                        if (xr.NodeType == XmlNodeType.Text) {
                            str = str + evalue + ";";
                        }
                    }
                }  
                //................................................................................
                // данные о статусе соединения с сервером
                if (section == "server_status")
                {
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        line = "";
                        str = "";
                        string attr_connected = xr.GetAttribute("connected");
                        if (attr_connected == "true") bConnected = true;
                        if (attr_connected == "false") bConnected = false;

                        for (int i = 0; i < xr.AttributeCount; i++)
                        {
                            attr = xr.GetAttribute(i);
                            str = str + i.ToString() + ":<" + attr + ">;";
                        }
                        line = "set server_status: " + str;
                    }

                }
                //................................................................................
                if (line.Length > 0) {
                    if (info.Length > 0) info = info + (char)13 + (char)10;
                    info = info + line;
                }
            }
            if (info.Length > 0) log.WriteLog(info);

            xr.Close();

            return section;
            // вывод дополнительной информации для удобства отладки
        }


 
		//--------------------------------------------------------------------------------
		// файл библиотеки TXmlConnector.dll должен находиться в одной папке с программой

        [DllImport("txmlconnector.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern bool SetCallback(CallBackDelegate pCallback);

        //[DllImport("txmlconnector.dll", CallingConvention = CallingConvention.StdCall)]
        //private static extern bool SetCallbackEx(CallBackExDelegate pCallbackEx, IntPtr userData);

        [DllImport("txmlconnector.dll", CallingConvention = CallingConvention.StdCall)]
		private static extern IntPtr SendCommand(IntPtr pData);

        [DllImport("txmlconnector.dll", CallingConvention = CallingConvention.StdCall)]
		private static extern bool FreeMemory(IntPtr pData);

        [DllImport("TXmlConnector.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr Initialize(IntPtr pPath, Int32 logLevel);

        [DllImport("TXmlConnector.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr UnInitialize();

        [DllImport("TXmlConnector.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr SetLogLevel(Int32 logLevel);
        //--------------------------------------------------------------------------------
	}
	

	//================================================================================


}

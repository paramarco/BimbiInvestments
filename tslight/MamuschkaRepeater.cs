using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace tslight
{

    static class MamuschkaRepeater
    {
        public static NewStringDataHandler onMamushkaStatusResponse;
        public static Thread monitoringThread = null;

        public static void mamushkaStatusSubscribe(NewStringDataHandler callback)
        {
            onMamushkaStatusResponse = new NewStringDataHandler(callback);
        }

        public static void connect()
        {
            handleClient client = new handleClient();
            client.connectRequest();
        }
        public static void disconnect()
        {
            handleClient client = new handleClient();
            client.disconnectRequest();
        }
        public static void cancellAll()
        {
            handleClient client = new handleClient();
            client.cancellAllRequest();
        }
        public static void forwardPosition(Position currentPosition)
        {
            handleClient client = new handleClient();
            client.forwardPosition(currentPosition);
        }

        public static void monitorMamuschkaServer()
        {
            handleClient client = new handleClient();
            client.monitor();
        }
        public static void stopMonitoringMamuschkaServer()
        {
            monitoringThread.Abort();
            
        }


    }

    public class handleClient
    {
        Thread ctThread;
        Position currentPosition;
        
        public void connectRequest()
        {
            ctThread = new Thread(doConnectRequest);
            ctThread.Start();
        }
        private void doConnectRequest()
        {
            try
            {
                //TcpClient client = new TcpClient();
                //IPAddress ipAddress = Dns.GetHostEntry("www.instaltic.com").AddressList[0];
                //client.Connect(ipAddress, 13000);

                TcpClient client = new TcpClient("178.21.11.34", 13000);

                String message = "<connect>";

                NetworkStream stream = client.GetStream();
                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                writer.AutoFlush = false;
                writer.WriteLine(message);
                writer.Flush();
            }
            catch (SocketException e)
            {
                return;
            }
            catch (Exception)
            {
                return;
            }

        }

        public void disconnectRequest()
        {
            ctThread = new Thread(doDisconnectRequest);
            ctThread.Start();
        }
        private void doDisconnectRequest()
        {
            try
            {
                //TcpClient client = new TcpClient();
                //IPAddress ipAddress = Dns.GetHostEntry("www.instaltic.com").AddressList[0];
                //client.Connect(ipAddress, 13000);

                TcpClient client = new TcpClient("178.21.11.34", 13000);

                String message = "<disconnect>";

                NetworkStream stream = client.GetStream();
                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                writer.AutoFlush = false;
                writer.WriteLine(message);
                writer.Flush();
            }
            catch (Exception)
            {
                return;
            }

        }

        public void cancellAllRequest()
        {
            ctThread = new Thread(doCancellAllRequest);
            ctThread.Start();
        }
        private void doCancellAllRequest()
        {
            try
            {
                //TcpClient client = new TcpClient();
                //IPAddress ipAddress = Dns.GetHostEntry("www.instaltic.com").AddressList[0];
                //client.Connect(ipAddress, 13000);

                TcpClient client = new TcpClient("178.21.11.34", 13000);

                String message = "<cancelAll>";

                NetworkStream stream = client.GetStream();
                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                writer.AutoFlush = false;
                writer.WriteLine(message);
                writer.Flush();

            }
            catch (Exception)
            {
                return;
            }
        }

        public void forwardPosition(Position position2forward)
        {
            this.currentPosition = position2forward;
            ctThread = new Thread(doForwardPosition);
            ctThread.Start();
        }
        private void  doForwardPosition()
        {
            try
            {
                //TcpClient client = new TcpClient();
                //IPAddress ipAddress = Dns.GetHostEntry("www.instaltic.com").AddressList[0];
                //client.Connect(ipAddress, 13000);

                TcpClient client = new TcpClient("178.21.11.34", 13000);

                String message = this.currentPosition.toXML();


                NetworkStream stream = client.GetStream();
                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                writer.AutoFlush = false;
                writer.WriteLine(message);
                writer.Flush();
            }
            catch (Exception)
            {
                return;
            }
        }


        public void monitor()
        {            
            ctThread = new Thread(doMonitoring);
            MamuschkaRepeater.monitoringThread = ctThread;
            ctThread.IsBackground = true;
            ctThread.Start();
        }

        private void doMonitoring()
        {
            while (true) {                 
                try {
                    //TcpClient client = new TcpClient();
                    //IPAddress ipAddress = Dns.GetHostEntry("www.instaltic.com").AddressList[0];
                    //client.Connect(ipAddress, 13000);

                    TcpClient client = new TcpClient("178.21.11.34", 13000);

                    String message = "<statusCheck>";

                    NetworkStream stream = client.GetStream();
                    StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                    writer.AutoFlush = false;
                    writer.WriteLine(message);
                    writer.Flush();

                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    String response = reader.ReadLine();

                    MamuschkaRepeater.onMamushkaStatusResponse.BeginInvoke(response, null, null);

                    stream.Close();
                }
                catch (Exception)
                {
                    MamuschkaRepeater.onMamushkaStatusResponse.BeginInvoke("failed", null, null);
                }
                Thread.Sleep(10000);
            }
            
        }


    }
}

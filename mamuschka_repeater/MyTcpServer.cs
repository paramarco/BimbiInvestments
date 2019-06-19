using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.IO;
using tslight;
using System.Xml;
using System.Xml.Serialization;

namespace mamuschka_repeater
{
    class MyTcpServer
    {
        public void start()
        {
            TcpListener serverSocket = null;
            TcpClient clientSocket = null;
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("178.21.11.34");

            try
            {
                serverSocket = new TcpListener(localAddr, port);
                clientSocket = default(TcpClient);
                serverSocket.Start();
                Console.WriteLine(" >> " + "Server Started");

                while (true)
                {
                    clientSocket = serverSocket.AcceptTcpClient();
                    handleClient client = new handleClient();
                    client.startClient(clientSocket);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                clientSocket.Close();
                serverSocket.Stop();
                Console.WriteLine(" >> " + "exit");
                Console.ReadLine();

            }
            
        }
    }
    //Class to handle each client request separatly
    public class handleClient
    {
        TcpClient clientSocket;
        Thread ctThread;
        XmlSerializer serializer4Postion = new XmlSerializer(typeof(positionXML), new XmlRootAttribute { ElementName = "position" });


        public void startClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            ctThread = new Thread(doRequest);
            ctThread.Start();
        }
        private void doRequest()
        {
            try{
                NetworkStream ns = clientSocket.GetStream(); //networkstream is used to send/receive messages

                while (clientSocket.Connected)  //while the client is connected, we look for incoming messages
                {
                    String request = String.Empty;
                    StreamReader reader = new StreamReader(ns, Encoding.UTF8);
                    request = reader.ReadLine();

                    XmlReaderSettings xs = new XmlReaderSettings();
                    xs.IgnoreWhitespace = true;
                    xs.ConformanceLevel = ConformanceLevel.Fragment;
                    XmlReader xr = XmlReader.Create(new System.IO.StringReader(request), xs);

                    while (xr.Read())
                    {
                        if (xr.Depth == 0 && xr.NodeType == XmlNodeType.Element)
                        {
                            if (xr.Name == "connect")
                            {
                                Program.Transaq_Connect();
                                Console.WriteLine(request);

                            }
                            if (xr.Name == "disconnect")
                            {
                                Program.Transaq_Disconnect();
                                Console.WriteLine(request);

                            }
                            if (xr.Name == "cancelAll")
                            {
                                OportunityMonitor.sendCancelAll2Transaq();
                                Console.WriteLine(request);
                            }
                            if (xr.Name == "position")
                            {
                                Console.WriteLine(request);

                                positionXML receivedPosition = (positionXML)serializer4Postion.Deserialize(xr);
                                if (receivedPosition == null)
                                {
                                    Console.WriteLine("receivedPosition == null ... returning"); return;
                                }
                                client client = OportunityMonitor.clients.Find(c => c.market == receivedPosition.market);
                                if (client == null)
                                {
                                    Console.WriteLine("Uppsss there is no client for this Market  "); return;
                                }

                                Position position2forward = new Position(
                                    receivedPosition.board,
                                    receivedPosition.seccode,
                                    client.id,
                                    client.union,
                                    receivedPosition.price,
                                    receivedPosition.quantity,
                                    receivedPosition.buysell,
                                    receivedPosition.stopLoss,
                                    receivedPosition.takeProfit,
                                    receivedPosition.decimals
                                );

                                OportunityMonitor.sendOrder2Transaq(position2forward);

                            }
                            if (xr.Name == "statusCheck")
                            {
                                StreamWriter writer = new StreamWriter(ns, Encoding.UTF8);
                                writer.Flush();

                                if (Program.bConnected){
                                    writer.WriteLine("connected");                                    
                                }
                                else
                                {
                                    writer.WriteLine("disconnected");
                                }
                                writer.Flush();

                            }
                            xr.Close();
                        }
                    }
                    reader.Close();
                    clientSocket.Close();
                }
            }
            catch (global::System.Exception)
            {
                return;
            }
        }
    }
}

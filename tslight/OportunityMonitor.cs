using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace tslight
{
    delegate void quotationDelegate(double securityLastPrice);
    delegate void PositionDelegate(Position Position);

    public class Security
    {
        public string seccode;
        public string board;
        public double last;
        public int decimals, market;

        public Security(string seccode, string board, int decimals, int market)
        {
            this.seccode = seccode ?? throw new ArgumentNullException(nameof(seccode));
            this.board = board ?? throw new ArgumentNullException(nameof(board));
            this.decimals = decimals;
            this.market = market;
            this.last = 0;
        }
    }

    static class OportunityMonitor
    {

        public static String operationMode = "manual";
        public static String trend = "growing"; // trend := "growing" | "descending"

        public static List<Security> monitoredSecurities;
        public static Security monitoredSecurityOnHMI = new Security("", "",0,0);
        public static double deltaOnHMI = 0.01;
        public static double orderCoefficientOnHMI = 1;
        public static double takeProfitCoefficientOnHMI = 2;
        public static double stopLossCoefficientOnHMI = 2;
        public static int lotsOnHMI = 1;
        public static List<Position> monitoredPositions = new List<Position>();
        public static List<Order> monitoredOrders = new List<Order>();
        public static List<Stoporder> monitoredStopOrders = new List<Stoporder>();
        public static markets markets;
        public static List<client> clients = new List<client>();

        private static event NewStringDataHandler onNewQuotationEvent;
        private static event quotationDelegate onQuotation;
        private static event PositionDelegate onPositionPublisher;
        private static event NewStringDataHandler onOrdersPublished;
        private static event NewStringDataHandler onMarketsPublished;
        private static event NewStringDataHandler onClientPublished;
        

        public static XmlSerializer serializer4quotations;
        public static XmlSerializer serializer4orders;
        public static XmlSerializer serializer4results;
        public static XmlSerializer serializer4newStopOrders;
        public static XmlSerializer serializer4markets;
        public static XmlSerializer serializer4client;

        public static XmlSerializerNamespaces emptyNamespaces ;

        public static XmlWriterSettings settingsXmlWriter = new XmlWriterSettings();
        public static XmlReaderSettings xs;

        public static void init()
        {

            monitoredSecurities = new List<Security>();

            TXmlConnector.NewQuotationCallback(NewQuotationCall);
            TXmlConnector.OrdersSubscribe( OrdersSubscriber);
            TXmlConnector.MarketsSubscribe( MarketsSubscriber);
            TXmlConnector.ClientSubscribe( ClientSubscriber );


            onNewQuotationEvent += new NewStringDataHandler(processQuotationsDistribution);
            onOrdersPublished += new NewStringDataHandler( processOrdersDistribution);
            onMarketsPublished += new NewStringDataHandler(processMarketsDistribution);
            onClientPublished += new NewStringDataHandler(processClientDistribution);



            XmlRootAttribute rootNodeQuotations = new XmlRootAttribute { ElementName = "quotations"  };
            XmlRootAttribute rootNodeOrders = new XmlRootAttribute { ElementName = "orders"  };
            XmlRootAttribute rootNodeResult = new XmlRootAttribute
            {
                ElementName = "result"
            };
            XmlRootAttribute rootNodeMarkets = new XmlRootAttribute
            {
                ElementName = "markets"
            };
            XmlRootAttribute rootNodeClient = new XmlRootAttribute
            {
                ElementName = "client"
            };

            Type deserializeType = typeof(quotations);
            serializer4quotations = new XmlSerializer(deserializeType, rootNodeQuotations);
            deserializeType = typeof(orders);
            serializer4orders = new XmlSerializer(deserializeType, rootNodeOrders);
            deserializeType = typeof(result);
            serializer4results = new XmlSerializer(deserializeType, rootNodeResult);
            deserializeType = typeof( NewStopOrder);
            serializer4newStopOrders = new XmlSerializer(deserializeType);
            deserializeType = typeof(markets);
            serializer4markets = new XmlSerializer(deserializeType, rootNodeMarkets);
            deserializeType = typeof(client);
            serializer4client = new XmlSerializer(deserializeType, rootNodeClient);

            emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            settingsXmlWriter.Indent = true;
            settingsXmlWriter.OmitXmlDeclaration = true;

            xs = new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                ConformanceLevel = ConformanceLevel.Fragment,
                ProhibitDtd = false
            };

        }



        public static void PositionPublisherCallback(PositionDelegate callback)
        {
            onPositionPublisher += new PositionDelegate(callback);
        }

        public static void subscribeQuotationUpdate(quotationDelegate callback)
        {
            onQuotation += new quotationDelegate(callback);
        }

        public static void NewQuotationCall(string data)
        {
            onNewQuotationEvent.BeginInvoke(data, null, null);
        }

        public static void OrdersSubscriber(string data)
        {
            onOrdersPublished.BeginInvoke(data, null, null);
        }

        public static void MarketsSubscriber(string data)
        {
            onMarketsPublished.BeginInvoke(data, null, null);
        }
        public static void ClientSubscriber(string data)
        {
            onClientPublished.BeginInvoke(data, null, null);
        }


        public static void addSecurityForMonitoring(Security security)
        {
            foreach (Security sec in monitoredSecurities)
            {
                if (sec.seccode.Contains(security.seccode))
                    return;
            }
            monitoredSecurities.Add(security);
        }

        public static void setSecurityLastQuotation(string seccode, double last) {
            foreach (Security sec in monitoredSecurities) {
                if (sec.seccode.Contains(seccode)) {
                    sec.last = last;
                    return;
                }
            }
        }


        public static void processOrder( Order order ) {

            switch (order.status)  {
                case "matched":
                    Position monitoredPosition = monitoredPositions.Find(p => p.transactionid == order.transactionid);
                    if (monitoredPosition != null && monitoredPosition.stopOrderRequested == false) {
                        monitoredPosition.stopOrderRequested = true;
                        monitoredPosition.orderno = order.orderno;
                        monitoredPosition.secid = order.secid;
                        NewStopOrder stopOrder = new NewStopOrder(monitoredPosition);
                        sendNewStopOrder2Transaq(stopOrder);
                    }
                    monitoredPositions.RemoveAll(o => o.transactionid == order.transactionid);
                    break;
                case "none":
                case "active":
                case "forwarding":
                case "inactive":
                case "wait":
                case "watching":
                    if (!monitoredOrders.Exists(o => o.transactionid == order.transactionid)) {
                        monitoredOrders.Add(order);
                    }
                    break;
                case "cancelled":
                case "denied":
                case "disabled":
                case "expired":
                case "failed":
                case "refused":
                case "removed":
                case "rejected":
                    monitoredOrders.RemoveAll(o => o.transactionid == order.transactionid);
                    break;
                default:
                    break;
            }
        }

        public static void processStopOrder(Stoporder stopOrder) {

            switch (stopOrder.status) {
                
                case "linkwait":
                case "sl_forwarding":
                case "sl_guardtime":
                case "tp_correction":
                case "tp_correction_guardtime":
                case "watching":
                case "tp_forwarding":
                case "tp_guardtime":                    
                    if (!monitoredStopOrders.Exists(o => o.transactionid == stopOrder.transactionid))  {
                        monitoredStopOrders.Add(stopOrder);
                    }
                    break;
                case "cancelled":
                case "denied":
                case "disabled":
                case "expired":
                case "failed":
                case "rejected":
                case "sl_executed":
                case "tp_executed":
                    monitoredStopOrders.RemoveAll(o => o.transactionid == stopOrder.transactionid);
                    break;
                default:
                    break;
            }
        }

        public static void processOrdersDistribution(string data)  {

            XmlReader xr = XmlReader.Create(new StringReader(data), xs);
            orders orders = (orders)serializer4orders.Deserialize(xr);

            if (orders != null && orders.order != null) {            
                for (int i = 0; i < orders.order.Length; i++) {
                    processOrder( orders.order[i] );
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

        public static void processMarketsDistribution(string data)
        {

            XmlReader xr = XmlReader.Create(new StringReader(data), xs);
            markets receivedMarkets = (markets)serializer4markets.Deserialize(xr);
            if ( receivedMarkets != null)
            {
                markets = receivedMarkets;
            }          

            xr.Close();
        }
        public static void processClientDistribution(string data)
        {

            XmlReader xr = XmlReader.Create(new StringReader(data), xs);
            client client = (client)serializer4client.Deserialize(xr);
            if (client != null)
            {
                clients.Add(client);
            }

            xr.Close();
        }

        public static void processQuotationsDistribution(string data) {

            XmlReader xr = XmlReader.Create(new System.IO.StringReader(data), xs);
            quotations quotations = (quotations)serializer4quotations.Deserialize(xr);

            for (int i = 0; i < quotations.quotation.Length; i++)
            {
                quotationsQuotation quotation = quotations.quotation[i];

                if (quotation.seccode.Contains(monitoredSecurityOnHMI.seccode) &&
                    quotation.last != 0)
                {
                    setSecurityLastQuotation(quotation.seccode, quotation.last);
                    onQuotation.BeginInvoke(quotation.last, null, null);
                }
            }

            calculateOportunities();
            xr.Close();
        }

        public static Position getPositionAsDefinedOnHMI( Security sec ) {

            double dOrderPrice = 0, dTakeProfitPrice = 0, dStopLossPrice = 0;
            string buysell = "";

            if (trend == "descending")
            {
                buysell = "S";
                dOrderPrice = sec.last + ( orderCoefficientOnHMI * deltaOnHMI);
                dTakeProfitPrice = dOrderPrice - ( takeProfitCoefficientOnHMI * deltaOnHMI);
                dStopLossPrice = dOrderPrice + ( stopLossCoefficientOnHMI * deltaOnHMI);

            }
            if (trend == "growing")
            {
                buysell = "B";
                dOrderPrice = sec.last - ( orderCoefficientOnHMI * deltaOnHMI );
                dTakeProfitPrice = dOrderPrice + (takeProfitCoefficientOnHMI * deltaOnHMI );
                dStopLossPrice = dOrderPrice - ( stopLossCoefficientOnHMI * deltaOnHMI);
            }

            client client = clients.Find(c => c.market == sec.market);
            if (client == null) { throw new ArgumentNullException(nameof(client));  }

            Position position = new Position(   sec.board, 
                                                sec.seccode,
                                                client.id,
                                                client.union,
                                                dOrderPrice,
                                                lotsOnHMI,
                                                buysell,
                                                dStopLossPrice,
                                                dTakeProfitPrice,
                                                sec.decimals,
                                                sec.market );
            return position;
        }

        public static client getClientByMarketId ( int marketId )
        {            
            return clients.Find(c => c.market == marketId); 
        }

        public static void calculateOportunities() {

            if (operationMode == "manual"){

                foreach (Security sec in monitoredSecurities)
                {
                    if (sec.seccode == monitoredSecurityOnHMI.seccode)
                    {
                        Position position = getPositionAsDefinedOnHMI( sec );
                        onPositionPublisher.BeginInvoke(position, null, null );
                        return;
                    }
                }
            }                
        }

        public static void sendOrder2Transaq( Position position) {

            string cmd = position.getTakingPositionCommandXML();
                
            string res = TXmlConnector.ConnectorSendCommand(cmd);

            XmlReader xr = XmlReader.Create(new System.IO.StringReader(res), xs);
            result result = (result)serializer4results.Deserialize(xr);

            if ( result.success == true ) {
                position.transactionid = result.transactionid;
                monitoredPositions.Add( position );
            }
        }

        public static void sendNewStopOrder2Transaq( NewStopOrder stopOrder)
        {
            StringWriter stream = new StringWriter();
            XmlWriter writer = XmlWriter.Create(stream, settingsXmlWriter);

            serializer4newStopOrders.Serialize(writer, stopOrder, emptyNamespaces);          

            string cmd = stream.ToString();             
            string res = TXmlConnector.ConnectorSendCommand(cmd);
        }

        public static void sendCancelAll2Transaq()
        {
            foreach ( Order order in monitoredOrders) {

                string cmd = "<command id=\"cancelorder\">";
                cmd = cmd + "<transactionid>" + order.transactionid.ToString() + "</transactionid>";
                cmd = cmd + "</command>";

                string res = TXmlConnector.ConnectorSendCommand(cmd);
            }

            foreach (Stoporder stoporder in monitoredStopOrders) {

                string cmd = "<command id=\"cancelstoporder\">";
                cmd = cmd + "<transactionid>" + stoporder.transactionid.ToString() + "</transactionid>";
                cmd = cmd + "</command>";

                string res = TXmlConnector.ConnectorSendCommand(cmd);
            }
        }

    }
}
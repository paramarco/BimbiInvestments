using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace tslight
{
     [XmlRoot(ElementName = "command")]
    public class NewStopOrder
    {
        [XmlElement(ElementName = "buysell")]
        public string Buysell { get; set; }
        [XmlElement(ElementName = "client")]
        public string Client { get; set; }
        [XmlElement(ElementName = "expdate")]
        public string Expdate { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        //[XmlElement(ElementName = "linkedorderno")]
        //public string Linkedorderno { get; set; }
        [XmlElement(ElementName = "security")]
        public SecurityNewStopOrder Security { get; set; }
        [XmlElement(ElementName = "stoploss")]
        public Stoploss Stoploss { get; set; }
        [XmlElement(ElementName = "takeprofit")]
        public Takeprofit Takeprofit { get; set; }
        [XmlElement(ElementName = "union")]
        public string Union { get; set; }
        [XmlElement(ElementName = "validfor")]
        public string Validfor { get; set; }
        [XmlElement(ElementName = "secid")]
        public string secid { get; set; }

        public NewStopOrder() { }

        public NewStopOrder( Position position) {
            this.Id = "newstoporder";
            if (position.buysell.Contains("B")) {
                this.Buysell = "S";
            } else {
                this.Buysell = "B";
            }
            this.secid = position.secid;
            this.Security = new SecurityNewStopOrder();
            this.Security.Board = position.board;
            this.Security.Seccode = position.seccode;
            this.Client = position.client;
            this.Union = position.union;
            //this.Linkedorderno = position.orderno;
            this.Stoploss = new Stoploss();
            this.Stoploss.Activationprice = position.stopLoss;
            this.Stoploss.Orderprice = position.stopLoss;
            this.Stoploss.Quantity = position.quantity;
            //this.Stoploss.Guardtime = 
            this.Stoploss.Brokerref = position.brokerref;
            this.Takeprofit = new Takeprofit();
            this.Takeprofit.Activationprice = position.takeProfit;
            this.Takeprofit.Quantity = position.quantity;
            this.Takeprofit.Correction = 0;
            this.Takeprofit.Spread = 0;
        }
    }

    [XmlRoot(ElementName = "security")]
    public class SecurityNewStopOrder
    {
        [XmlElement(ElementName = "board")]
        public string Board { get; set; }
        [XmlElement(ElementName = "seccode")]
        public string Seccode { get; set; }
    }

    [XmlRoot(ElementName = "stoploss")]
    public class Stoploss
    {
        [XmlElement(ElementName = "activationprice")]
        public double Activationprice { get; set; }
        [XmlElement(ElementName = "brokerref")]
        public string Brokerref { get; set; }
        //[XmlElement(ElementName = "guardtime")]
        //public string Guardtime { get; set; }
        [XmlElement(ElementName = "orderprice")]
        public double Orderprice { get; set; }
        [XmlElement(ElementName = "quantity")]
        public int Quantity { get; set; }
    }

    [XmlRoot(ElementName = "takeprofit")]
    public class Takeprofit
    {
        [XmlElement(ElementName = "activationprice")]
        public double Activationprice { get; set; }
        [XmlElement(ElementName = "brokerref")]
        public string Brokerref { get; set; }
        [XmlElement(ElementName = "correction")]
        public double Correction { get; set; }
        //[XmlElement(ElementName = "guardtime")]
        //public string Guardtime { get; set; }
        [XmlElement(ElementName = "quantity")]
        public int Quantity { get; set; }
        [XmlElement(ElementName = "spread")]
        public double Spread { get; set; }
    }
}

using System;

namespace tslight
{
    public class Position
    {
        public string board;        // trade board identifier
        public string seccode;      // security code (instrument)
        public string client;       // client | идентификатор клиента
        public string union;        // union code | Код юниона 
        public double price;
        public string hidden;       // hidden quantity in lots
        public int quantity;     // quantity in lots
        public string buysell;      // ("B" - purchase, or "S" - sale)
        public string brokerref;    // note
        public string unfilled;     // PutInQueue (other possible values: FOK, IOC)
        public Boolean usecredit;
        public Boolean nosplit;
        public string expdate;      // expiration date(FORTS only) set in a format MM/DD/YYYY HH:MM:SS (optional)
        public double stopLoss;
        public double takeProfit;
        public Boolean stopOrderRequested;
        public String orderno;
        public int transactionid;
        public String secid;
        public int decimals;

        public Position(   string board, 
                        string seccode, 
                        string client, //7664sux
                        string union, //448573R4FN7
                        double price, 
                        int quantity, 
                        string buysell,
                        double stopLoss,
                        double takeProfit,
                        int decimals )
        {
            this.board = board ?? throw new ArgumentNullException(nameof(board));
            this.seccode = seccode ?? throw new ArgumentNullException(nameof(seccode));
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.union = union ?? throw new ArgumentNullException(nameof(union));
            this.price = Math.Round(price, decimals);
            this.hidden = "";
            this.quantity = quantity;
            this.buysell = buysell ?? throw new ArgumentNullException(nameof(buysell));
            this.decimals = decimals;
            this.brokerref = union ?? throw new ArgumentNullException(nameof(union));
            this.unfilled = "";
            this.usecredit = false;
            this.nosplit = true;
            this.expdate = "";
            this.stopOrderRequested = false;
            this.secid = "";
            this.takeProfit = Math.Round(takeProfit, decimals);
            this.stopLoss = Math.Round(stopLoss, decimals);

        }

        public string getTakingPositionCommandXML() {

            string sOrder = "<command id=\"neworder\">";
            sOrder += "<security>";
            sOrder += "<board>"+ board +"</board>";
            sOrder += "<seccode>" + seccode + "</seccode>";
            sOrder += "</security>";
            sOrder += "<client>" + client + "</client>";
            sOrder += "<union>" + union + "</union>";
            sOrder += "<price>" + price.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "</price>";
            sOrder += "<quantity>" + quantity.ToString() + "</quantity>";
            sOrder += "<buysell>" + buysell + "</buysell>";
            sOrder += "<brokerref>" + brokerref + "</brokerref>";
            sOrder += "</command>";

            return sOrder;
        }
    }
}

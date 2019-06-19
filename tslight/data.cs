using System;
using System.Data;


namespace tslight
{

	//================================================================================
	#region DataSet_tslight
	//--------------------------------------------------------------------------------
	public class DataSet_tslight : DataSet
	{
		public DataTable_security t_security;	
		public DataTable_timeframe t_timeframe;	
		public DataTable_candle t_candle;
        public DataTable_security t_my_securities;
        public DataTable_order t_my_takingPositions;
        public DataTable_stopOrder t_my_ClosingPositions;

        //--------------------------------------------------------------------------------
        public DataSet_tslight():
			base()
		{
			t_security = new DataTable_security();
			t_timeframe = new DataTable_timeframe();
			t_candle = new DataTable_candle();
            t_my_securities = new DataTable_security();
            t_my_takingPositions = new DataTable_order();
            t_my_ClosingPositions = new DataTable_stopOrder();
        }
		//--------------------------------------------------------------------------------
	}
	//--------------------------------------------------------------------------------
	#endregion
	//================================================================================
	#region Data_security
	//--------------------------------------------------------------------------------
	public class DataTable_security : DataTable
	{
		public DataColumn security_id;
		public DataColumn security_name;
		public DataColumn security_code;
		public DataColumn lotsize;
        public DataColumn decimals;
        public DataColumn market;
        public DataColumn board;


        //--------------------------------------------------------------------------------
        public DataTable_security()
		{
			TableName = "t_security";
			BeginInit();
			InitClass();
			EndInit();
		}
		//--------------------------------------------------------------------------------
		public int Count
		{
			get { return Rows.Count; }
		}

        //--------------------------------------------------------------------------------
        public void Add_Row(DataRow_security row)
		{
			Rows.Add(row);
		}
		//--------------------------------------------------------------------------------
		public void Remove_Row(DataRow_security row)
		{
			Rows.Remove(row);
		}
		//--------------------------------------------------------------------------------
		public DataRow_security Add_Row(int security_id, string security_name, string security_code, int lotsize, int decimals, int market, string board)
		{
			DataRow_security row = (DataRow_security)NewRow();
			object[] aValues = new object[]
			{
				security_id, security_name, security_code, lotsize, decimals, market, board
            };
			row.ItemArray = aValues;
			Rows.Add(row);
			return row;
		}
		//--------------------------------------------------------------------------------
		public DataRow_security New_Row()
		{
			return (DataRow_security)NewRow();
		}
		//--------------------------------------------------------------------------------
		protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder)
		{
			return new DataRow_security(builder);
		}
		//--------------------------------------------------------------------------------
		public DataRow FindByID(uint id)
		{
			return (DataRow_security)Rows.Find(new object[] {id} );
		}
		//--------------------------------------------------------------------------------
		internal void InitVars()
		{
			security_id = Columns["security_id"];
			security_name = Columns["security_name"];
			security_code = Columns["security_code"];
			lotsize = Columns["lotsize"];
            decimals = Columns["decimals"];
            market = Columns["market"];
            board = Columns["board"];
        }
		//--------------------------------------------------------------------------------
		internal void InitClass()
		{
			security_id = new DataColumn("security_id", typeof(int), null, MappingType.Element);
			Columns.Add(security_id);
			security_name = new DataColumn("security_name", typeof(string), null, MappingType.Element);
			Columns.Add(security_name);
			security_code = new DataColumn("security_code", typeof(string), null, MappingType.Element);
			Columns.Add(security_code);
			lotsize = new DataColumn("lotsize", typeof(int), null, MappingType.Element);
			Columns.Add(lotsize);
            decimals = new DataColumn("decimals", typeof(int), null, MappingType.Element);
            Columns.Add(decimals);
            market = new DataColumn("market", typeof(int), null, MappingType.Element);
            Columns.Add(market);
            board = new DataColumn("board", typeof(string), null, MappingType.Element);
            Columns.Add(board);

            PrimaryKey = new DataColumn[] { security_id };
			security_name.MaxLength = 50;
			security_code.MaxLength = 50;
            board.MaxLength = 20;

        }
		//--------------------------------------------------------------------------------
		protected override Type GetRowType()
		{
			return typeof(DataRow_security);
		}
		//--------------------------------------------------------------------------------
		public DataRow_security this[int index]
		{
			get { return (DataRow_security)Rows[index]; }
		}
		//--------------------------------------------------------------------------------
	}
	
	public partial class DataRow_security : global::System.Data.DataRow
	{
		private DataTable_security table;
		
		//--------------------------------------------------------------------------------
		internal DataRow_security(global::System.Data.DataRowBuilder rb):
			base(rb)
		{
			table = (DataTable_security)Table;
		}
		//--------------------------------------------------------------------------------
		public int security_id
		{
			get { return (int)this[table.security_id]; }
			set { this[table.security_id] = value; }
		}
		//--------------------------------------------------------------------------------
		public string security_name
		{
			get { return (string)this[table.security_name]; }
			set { this[table.security_name] = value; }
		}
		//--------------------------------------------------------------------------------
		public string security_code
		{
			get { return (string)this[table.security_code]; }
			set { this[table.security_code] = value; }
		}
		//--------------------------------------------------------------------------------
		public int lotsize
		{
			get { return (int)this[table.lotsize]; }
			set { this[table.lotsize] = value; }
		}
        //--------------------------------------------------------------------------------
        public int decimals
        {
            get { return (int)this[table.decimals]; }
            set { this[table.decimals] = value; }
        }
        //--------------------------------------------------------------------------------
        public int market
        {
            get { return (int)this[table.market]; }
            set { this[table.market] = value; }
        }
        //--------------------------------------------------------------------------------
        public string board
        {
            get { return (string)this[table.board]; }
            set { this[table.board] = value; }
        }
    }
    #endregion // Data_security
    //================================================================================
    #region Data_timeframe
    //--------------------------------------------------------------------------------
    public class DataTable_timeframe : DataTable
	{
		public DataColumn timeframe_id;
		public DataColumn timeframe_length;
		public DataColumn timeframe_name;
		
		//--------------------------------------------------------------------------------
		public DataTable_timeframe()
		{
			TableName = "t_timeframe";
			BeginInit();
			InitClass();
			EndInit();
		}
		//--------------------------------------------------------------------------------
		public int Count
		{
			get { return Rows.Count; }
		}
		//--------------------------------------------------------------------------------
		public void Add_Row(DataRow_timeframe row)
		{
			Rows.Add(row);
		}
		//--------------------------------------------------------------------------------
		public void Remove_Row(DataRow_timeframe row)
		{
			Rows.Remove(row);
		}
		//--------------------------------------------------------------------------------
		public DataRow_timeframe Add_Row(int timeframe_id, int timeframe_length, string timeframe_name)
		{
			DataRow_timeframe row = (DataRow_timeframe)NewRow();
			object[] aValues = new object[]
			{
				timeframe_id, timeframe_length, timeframe_name
			};
			row.ItemArray = aValues;
			Rows.Add(row);
			return row;
		}
		//--------------------------------------------------------------------------------
		public DataRow_timeframe New_Row()
		{
			return (DataRow_timeframe)NewRow();
		}
		//--------------------------------------------------------------------------------
		protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder)
		{
			return new DataRow_timeframe(builder);
		}
		//--------------------------------------------------------------------------------
		public DataRow FindByID(uint id)
		{
			return (DataRow_timeframe)Rows.Find(new object[] {id} );
		}
		//--------------------------------------------------------------------------------
		internal void InitVars()
		{
			timeframe_id = Columns["timeframe_id"];
			timeframe_length = Columns["timeframe_length"];
			timeframe_name = Columns["timeframe_name"];
		}
		//--------------------------------------------------------------------------------
		internal void InitClass()
		{
			timeframe_id = new DataColumn("timeframe_id", typeof(int), null, MappingType.Element);
			Columns.Add(timeframe_id);
			timeframe_length = new DataColumn("timeframe_length", typeof(int), null, MappingType.Element);
			Columns.Add(timeframe_length);
			timeframe_name = new DataColumn("timeframe_name", typeof(string), null, MappingType.Element);
			Columns.Add(timeframe_name);
			
			PrimaryKey = new DataColumn[] { timeframe_id };
			timeframe_name.MaxLength = 50;
		}
		//--------------------------------------------------------------------------------
		protected override Type GetRowType()
		{
			return typeof(DataRow_timeframe);
		}
		//--------------------------------------------------------------------------------
		public DataRow_timeframe this[int index]
		{
			get { return (DataRow_timeframe)Rows[index]; }
		}
		//--------------------------------------------------------------------------------
	}

	public partial class DataRow_timeframe : global::System.Data.DataRow
	{
		private DataTable_timeframe table;
		
		//--------------------------------------------------------------------------------
		internal DataRow_timeframe(global::System.Data.DataRowBuilder rb):
			base(rb)
		{
			table = (DataTable_timeframe)Table;
		}
		//--------------------------------------------------------------------------------
		public int timeframe_id
		{
			get { return (int)this[table.timeframe_id]; }
			set { this[table.timeframe_id] = value; }
		}
		//--------------------------------------------------------------------------------
		public int timeframe_length
		{
			get { return (int)this[table.timeframe_length]; }
			set { this[table.timeframe_length] = value; }
		}
		//--------------------------------------------------------------------------------
		public string timeframe_name
		{
			get { return (string)this[table.timeframe_name]; }
			set { this[table.timeframe_name] = value; }
		}
		//--------------------------------------------------------------------------------
	}
	#endregion // Data_timeframe
	//================================================================================
	#region Data_candle
	//--------------------------------------------------------------------------------
	public class DataTable_candle : DataTable
	{
		public DataColumn date;
		public DataColumn open;
		public DataColumn high;
		public DataColumn low;
		public DataColumn close;
		public DataColumn volume;
		
		//--------------------------------------------------------------------------------
		public DataTable_candle()
		{
			TableName = "t_candle";
			BeginInit();
			InitClass();
			EndInit();
		}
		//--------------------------------------------------------------------------------
		public int Count
		{
			get { return Rows.Count; }
		}
		//--------------------------------------------------------------------------------
		public void Add_Row(DataRow_candle row)
		{
			Rows.Add(row);
		}
		//--------------------------------------------------------------------------------
		public void Remove_Row(DataRow_candle row)
		{
			Rows.Remove(row);
		}
		//--------------------------------------------------------------------------------
		public DataRow_candle Add_Row(DateTime date, double open, double high, double low, double close, int volume)
		{
			DataRow_candle row = (DataRow_candle)NewRow();
			object[] aValues = new object[]
			{
				date, open, high, low, close, volume
			};
			row.ItemArray = aValues;
			Rows.Add(row);
			return row;
		}
		//--------------------------------------------------------------------------------
		public DataRow_candle New_Row()
		{
			return (DataRow_candle)NewRow();
		}
		//--------------------------------------------------------------------------------
		protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder)
		{
			return new DataRow_candle(builder);
		}
		//--------------------------------------------------------------------------------
		public DataRow FindByDT(DateTime dt)
		{
			return (DataRow_candle)Rows.Find(new object[] {dt} );
		}
		//--------------------------------------------------------------------------------
		internal void InitVars()
		{
			date = Columns["date"];
			open = Columns["open"];
			high = Columns["high"];
			low = Columns["low"];
			close = Columns["close"];
			volume = Columns["volume"];
		}
		//--------------------------------------------------------------------------------
		internal void InitClass()
		{
			date = new DataColumn("date", typeof(DateTime), null, MappingType.Element);
			Columns.Add(date);
			open = new DataColumn("open", typeof(double), null, MappingType.Element);
			Columns.Add(open);
			high = new DataColumn("high", typeof(double), null, MappingType.Element);
			Columns.Add(high);
			low = new DataColumn("low", typeof(double), null, MappingType.Element);
			Columns.Add(low);
			close = new DataColumn("close", typeof(double), null, MappingType.Element);
			Columns.Add(close);
			volume = new DataColumn("volume", typeof(int), null, MappingType.Element);
			Columns.Add(volume);
			
			//PrimaryKey = new DataColumn[] { date };
		}
		//--------------------------------------------------------------------------------
		protected override Type GetRowType()
		{
			return typeof(DataRow_candle);
		}
		//--------------------------------------------------------------------------------
		public DataRow_candle this[int index]
		{
			get { return (DataRow_candle)Rows[index]; }
		}
		//--------------------------------------------------------------------------------
	}

    public partial class DataRow_candle : global::System.Data.DataRow
	{
		private DataTable_candle table;
		
		//--------------------------------------------------------------------------------
		internal DataRow_candle(global::System.Data.DataRowBuilder rb):
			base(rb)
		{
			table = (DataTable_candle)Table;
		}
		//--------------------------------------------------------------------------------
		public DateTime date
		{
			get { return (DateTime)this[table.date]; }
			set { this[table.date] = value; }
		}
		//--------------------------------------------------------------------------------
		public double open
		{
			get { return (double)this[table.open]; }
			set { this[table.open] = value; }
		}
		//--------------------------------------------------------------------------------
		public double high
		{
			get { return (double)this[table.high]; }
			set { this[table.high] = value; }
		}
		//--------------------------------------------------------------------------------
		public double low
		{
			get { return (double)this[table.low]; }
			set { this[table.low] = value; }
		}
		//--------------------------------------------------------------------------------
		public double close
		{
			get { return (double)this[table.close]; }
			set { this[table.close] = value; }
		}
		//--------------------------------------------------------------------------------
		public int volume
		{
			get { return (int)this[table.volume]; }
			set { this[table.volume] = value; }
		}
		//--------------------------------------------------------------------------------
	}
    #endregion // Data_candle
    //================================================================================
    //================================================================================
    #region Data_order
    //--------------------------------------------------------------------------------
    public class DataTable_order : DataTable
    {
        public DataColumn security_code;
        public DataColumn buysell;
        public DataColumn price;
        public DataColumn status;
        public DataColumn transactionId;


        //--------------------------------------------------------------------------------
        public DataTable_order()
        {
            TableName = "t_orders";
            BeginInit();
            InitClass();
            EndInit();
        }
        //--------------------------------------------------------------------------------
        public int Count
        {
            get { return Rows.Count; }
        }

        //--------------------------------------------------------------------------------
        public void Add_Row(DataRow_order row)
        {
            Rows.Add(row);
        }
        //--------------------------------------------------------------------------------
        public void Remove_Row(DataRow_order row)
        {
            Rows.Remove(row);
        }
        //--------------------------------------------------------------------------------
        public DataRow_order Add_Row(string security_code, string buysell, double price, string status, int transactionId)
        {
            DataRow_order row = (DataRow_order)NewRow();
            object[] aValues = new object[]
            {
                security_code, buysell, price, status, transactionId
            };
            row.ItemArray = aValues;
            Rows.Add(row);
            return row;
        }
        //--------------------------------------------------------------------------------
        public DataRow_order New_Row()
        {
            return (DataRow_order)NewRow();
        }
        //--------------------------------------------------------------------------------
        protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder)
        {
            return new DataRow_order(builder);
        }
        //--------------------------------------------------------------------------------
        public DataRow FindByID(int id)
        {
            return (DataRow_order)Rows.Find(new object[] { id });
        }
        //--------------------------------------------------------------------------------
        internal void InitVars()
        {
            security_code = Columns["security_code"];
            buysell = Columns["buysell"];
            price = Columns["price"];
            status = Columns["status"];
            transactionId = Columns["transactionId"];            

        }
        //--------------------------------------------------------------------------------
        internal void InitClass()
        {
            security_code = new DataColumn("security_code", typeof(string), null, MappingType.Element);
            
            Columns.Add(security_code);
            buysell = new DataColumn("buysell", typeof(string), null, MappingType.Element);
            Columns.Add(buysell);
            price = new DataColumn("price", typeof(double), null, MappingType.Element);
            Columns.Add(price);
            status = new DataColumn("status", typeof(string), null, MappingType.Element);
            Columns.Add(status);
            transactionId = new DataColumn("transactionId", typeof(int), null, MappingType.Element);
            Columns.Add(transactionId);           

            PrimaryKey = new DataColumn[] { transactionId };
            security_code.MaxLength = 50;
            buysell.MaxLength = 2;
            status.MaxLength = 20;

        }
        //--------------------------------------------------------------------------------
        protected override Type GetRowType()
        {
            return typeof(DataRow_order);
        }
        //--------------------------------------------------------------------------------
        public DataRow_order this[int index]
        {
            get { return (DataRow_order)Rows[index]; }
        }
        //--------------------------------------------------------------------------------
    }

    public partial class DataRow_order : global::System.Data.DataRow
    {
        private DataTable_order table;

        //--------------------------------------------------------------------------------
        internal DataRow_order(global::System.Data.DataRowBuilder rb) :
            base(rb)
        {
            table = (DataTable_order)Table;
        }
        //--------------------------------------------------------------------------------
        public string security_code
        {
            get { return (string)this[table.security_code]; }
            set { this[table.security_code] = value; }
        }
        //--------------------------------------------------------------------------------
        public string buysell
        {
            get { return (string)this[table.buysell]; }
            set { this[table.buysell] = value; }
        }
        //--------------------------------------------------------------------------------
        public double price
        {
            get { return (double)this[table.price]; }
            set { this[table.price] = value; }
        }
        //--------------------------------------------------------------------------------
        public string status
        {
            get { return (string)this[table.status]; }
            set { this[table.status] = value; }
        }
        //--------------------------------------------------------------------------------
        public int transactionId
        {
            get { return (int)this[table.transactionId]; }
            set { this[table.transactionId] = value; }
        }
        //--------------------------------------------------------------------------------       
    }
    #endregion // Data_order

    //================================================================================
    #region stopOrder
    //--------------------------------------------------------------------------------
    public class DataTable_stopOrder : DataTable
    {
        public DataColumn security_code;
        public DataColumn buysell;
        public DataColumn stopLoss;
        public DataColumn takeProfit;
        public DataColumn status;
        public DataColumn transactionId;


        //--------------------------------------------------------------------------------
        public DataTable_stopOrder()
        {
            TableName = "t_stopOrders";
            BeginInit();
            InitClass();
            EndInit();
        }
        //--------------------------------------------------------------------------------
        public int Count
        {
            get { return Rows.Count; }
        }

        //--------------------------------------------------------------------------------
        public void Add_Row(DataRow_stopOrder row)
        {
            Rows.Add(row);
        }
        //--------------------------------------------------------------------------------
        public void Remove_Row(DataRow_stopOrder row)
        {
            Rows.Remove(row);
        }
        //--------------------------------------------------------------------------------
        public DataRow_stopOrder Add_Row(string security_code, string buysell, double stopLoss, double takeProfit, string status, int transactionId)
        {
            DataRow_stopOrder row = (DataRow_stopOrder)NewRow();
            object[] aValues = new object[]
            {
                security_code, buysell, stopLoss, takeProfit, status, transactionId
            };
            row.ItemArray = aValues;
            Rows.Add(row);
            return row;
        }
        //--------------------------------------------------------------------------------
        public DataRow_stopOrder New_Row()
        {
            return (DataRow_stopOrder)NewRow();
        }
        //--------------------------------------------------------------------------------
        protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder)
        {
            return new DataRow_stopOrder(builder);
        }
        //--------------------------------------------------------------------------------
        public DataRow FindByID(int id)
        {
            return (DataRow_stopOrder)Rows.Find(new object[] { id });
        }
        //--------------------------------------------------------------------------------
        internal void InitVars()
        {
            security_code = Columns["security_code"];
            buysell = Columns["buysell"];
            stopLoss = Columns["stopLoss"];
            takeProfit = Columns["takeProfit"];
            status = Columns["status"];
            transactionId = Columns["transactionId"];

        }
        //--------------------------------------------------------------------------------
        internal void InitClass()
        {
            security_code = new DataColumn("security_code", typeof(string), null, MappingType.Element);

            Columns.Add(security_code);
            buysell = new DataColumn("buysell", typeof(string), null, MappingType.Element);
            Columns.Add(buysell);
            stopLoss = new DataColumn("stopLoss", typeof(double), null, MappingType.Element);
            Columns.Add(stopLoss);
            takeProfit = new DataColumn("takeProfit", typeof(double), null, MappingType.Element);
            Columns.Add(takeProfit);
            status = new DataColumn("status", typeof(string), null, MappingType.Element);
            Columns.Add(status);
            transactionId = new DataColumn("transactionId", typeof(int), null, MappingType.Element);
            Columns.Add(transactionId);

            PrimaryKey = new DataColumn[] { transactionId };
            security_code.MaxLength = 50;
            buysell.MaxLength = 2;
            status.MaxLength = 20;

        }
        //--------------------------------------------------------------------------------
        protected override Type GetRowType()
        {
            return typeof(DataRow_stopOrder);
        }
        //--------------------------------------------------------------------------------
        public DataRow_stopOrder this[int index]
        {
            get { return (DataRow_stopOrder)Rows[index]; }
        }
        //--------------------------------------------------------------------------------
    }

    public partial class DataRow_stopOrder : global::System.Data.DataRow
    {
        private DataTable_stopOrder table;

        //--------------------------------------------------------------------------------
        internal DataRow_stopOrder(global::System.Data.DataRowBuilder rb) :
            base(rb)
        {
            table = (DataTable_stopOrder)Table;
        }
        //--------------------------------------------------------------------------------
        public string security_code
        {
            get { return (string)this[table.security_code]; }
            set { this[table.security_code] = value; }
        }
        //--------------------------------------------------------------------------------
        public string buysell
        {
            get { return (string)this[table.buysell]; }
            set { this[table.buysell] = value; }
        }
        //--------------------------------------------------------------------------------
        public double stopLoss
        {
            get { return (double)this[table.stopLoss]; }
            set { this[table.stopLoss] = value; }
        }
        //--------------------------------------------------------------------------------
        public double takeProfit
        {
            get { return (double)this[table.takeProfit]; }
            set { this[table.takeProfit] = value; }
        }
        //--------------------------------------------------------------------------------
        public string status
        {
            get { return (string)this[table.status]; }
            set { this[table.status] = value; }
        }
        //--------------------------------------------------------------------------------
        public int transactionId
        {
            get { return (int)this[table.transactionId]; }
            set { this[table.transactionId] = value; }
        }
        //--------------------------------------------------------------------------------       
    }
    #endregion // stopOrder

}

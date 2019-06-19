
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class orders
{

    private Order[] orderField;

    private Stoporder[] stoporderField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("order")]
    public Order[] order
    {
        get
        {
            return this.orderField;
        }
        set
        {
            this.orderField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("stoporder")]
    public Stoporder[] stoporder
    {
        get
        {
            return this.stoporderField;
        }
        set
        {
            this.stoporderField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class Order
{

    private string ordernoField;

    private string secidField;

    private string unionField;

    private string boardField;

    private string seccodeField;

    private string clientField;

    private string statusField;

    private string buysellField;

    private string timeField;

    private string brokerrefField;

    private double valueField;

    private double accruedintField;

    private string settlecodeField;

    private int balanceField;

    private double priceField;

    private int quantityField;

    private int hiddenField;

    private string yieldField;

    private string withdrawtimeField;

    private string conditionField;

    private string maxcomissionField;

    private string resultField;

    private int transactionidField;

    /// <remarks/>
    public string orderno
    {
        get
        {
            return this.ordernoField;
        }
        set
        {
            this.ordernoField = value;
        }
    }

    /// <remarks/>
    public string secid
    {
        get
        {
            return this.secidField;
        }
        set
        {
            this.secidField = value;
        }
    }

    /// <remarks/>
    public string union
    {
        get
        {
            return this.unionField;
        }
        set
        {
            this.unionField = value;
        }
    }

    /// <remarks/>
    public string board
    {
        get
        {
            return this.boardField;
        }
        set
        {
            this.boardField = value;
        }
    }

    /// <remarks/>
    public string seccode
    {
        get
        {
            return this.seccodeField;
        }
        set
        {
            this.seccodeField = value;
        }
    }

    /// <remarks/>
    public string client
    {
        get
        {
            return this.clientField;
        }
        set
        {
            this.clientField = value;
        }
    }

    /// <remarks/>
    public string status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }

    /// <remarks/>
    public string buysell
    {
        get
        {
            return this.buysellField;
        }
        set
        {
            this.buysellField = value;
        }
    }

    /// <remarks/>
    public string time
    {
        get
        {
            return this.timeField;
        }
        set
        {
            this.timeField = value;
        }
    }

    /// <remarks/>
    public string brokerref
    {
        get
        {
            return this.brokerrefField;
        }
        set
        {
            this.brokerrefField = value;
        }
    }

    /// <remarks/>
    public double value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }

    /// <remarks/>
    public double accruedint
    {
        get
        {
            return this.accruedintField;
        }
        set
        {
            this.accruedintField = value;
        }
    }

    /// <remarks/>
    public string settlecode
    {
        get
        {
            return this.settlecodeField;
        }
        set
        {
            this.settlecodeField = value;
        }
    }

    /// <remarks/>
    public int balance
    {
        get
        {
            return this.balanceField;
        }
        set
        {
            this.balanceField = value;
        }
    }

    /// <remarks/>
    public double price
    {
        get
        {
            return this.priceField;
        }
        set
        {
            this.priceField = value;
        }
    }

    /// <remarks/>
    public int quantity
    {
        get
        {
            return this.quantityField;
        }
        set
        {
            this.quantityField = value;
        }
    }

    /// <remarks/>
    public int hidden
    {
        get
        {
            return this.hiddenField;
        }
        set
        {
            this.hiddenField = value;
        }
    }

    /// <remarks/>
    public string yield
    {
        get
        {
            return this.yieldField;
        }
        set
        {
            this.yieldField = value;
        }
    }

    /// <remarks/>
    public string withdrawtime
    {
        get
        {
            return this.withdrawtimeField;
        }
        set
        {
            this.withdrawtimeField = value;
        }
    }

    /// <remarks/>
    public string condition
    {
        get
        {
            return this.conditionField;
        }
        set
        {
            this.conditionField = value;
        }
    }

    /// <remarks/>
    public string maxcomission
    {
        get
        {
            return this.maxcomissionField;
        }
        set
        {
            this.maxcomissionField = value;
        }
    }

    /// <remarks/>
    public string result
    {
        get
        {
            return this.resultField;
        }
        set
        {
            this.resultField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int transactionid
    {
        get
        {
            return this.transactionidField;
        }
        set
        {
            this.transactionidField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class Stoporder
{

    private string activeordernoField;

    private bool activeordernoFieldSpecified;

    private string secidField;

    private string unionField;

    private string boardField;

    private string seccodeField;

    private string clientField;

    private string buysellField;

    private string alltradenoField;

    private bool alltradenoFieldSpecified;

    private string authorField;

    private string accepttimeField;

    private string statusField;

    private ordersStoporderStoploss stoplossField;

    private ordersStoporderTakeprofit takeprofitField;

    private string withdrawtimeField;

    private string resultField;

    private int transactionidField;

    /// <remarks/>
    public string activeorderno
    {
        get
        {
            return this.activeordernoField;
        }
        set
        {
            this.activeordernoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool activeordernoSpecified
    {
        get
        {
            return this.activeordernoFieldSpecified;
        }
        set
        {
            this.activeordernoFieldSpecified = value;
        }
    }

    /// <remarks/>
    public string secid
    {
        get
        {
            return this.secidField;
        }
        set
        {
            this.secidField = value;
        }
    }

    /// <remarks/>
    public string union
    {
        get
        {
            return this.unionField;
        }
        set
        {
            this.unionField = value;
        }
    }

    /// <remarks/>
    public string board
    {
        get
        {
            return this.boardField;
        }
        set
        {
            this.boardField = value;
        }
    }

    /// <remarks/>
    public string seccode
    {
        get
        {
            return this.seccodeField;
        }
        set
        {
            this.seccodeField = value;
        }
    }

    /// <remarks/>
    public string client
    {
        get
        {
            return this.clientField;
        }
        set
        {
            this.clientField = value;
        }
    }

    /// <remarks/>
    public string buysell
    {
        get
        {
            return this.buysellField;
        }
        set
        {
            this.buysellField = value;
        }
    }

    /// <remarks/>
    public string alltradeno
    {
        get
        {
            return this.alltradenoField;
        }
        set
        {
            this.alltradenoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool alltradenoSpecified
    {
        get
        {
            return this.alltradenoFieldSpecified;
        }
        set
        {
            this.alltradenoFieldSpecified = value;
        }
    }

    /// <remarks/>
    public string author
    {
        get
        {
            return this.authorField;
        }
        set
        {
            this.authorField = value;
        }
    }

    /// <remarks/>
    public string accepttime
    {
        get
        {
            return this.accepttimeField;
        }
        set
        {
            this.accepttimeField = value;
        }
    }

    /// <remarks/>
    public string status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }

    /// <remarks/>
    public ordersStoporderStoploss stoploss
    {
        get
        {
            return this.stoplossField;
        }
        set
        {
            this.stoplossField = value;
        }
    }

    /// <remarks/>
    public ordersStoporderTakeprofit takeprofit
    {
        get
        {
            return this.takeprofitField;
        }
        set
        {
            this.takeprofitField = value;
        }
    }

    /// <remarks/>
    public string withdrawtime
    {
        get
        {
            return this.withdrawtimeField;
        }
        set
        {
            this.withdrawtimeField = value;
        }
    }

    /// <remarks/>
    public string result
    {
        get
        {
            return this.resultField;
        }
        set
        {
            this.resultField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int transactionid
    {
        get
        {
            return this.transactionidField;
        }
        set
        {
            this.transactionidField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ordersStoporderStoploss
{

    private double activationpriceField;

    private string brokerrefField;

    private int quantityField;

    private double orderpriceField;

    private string usecreditField;

    /// <remarks/>
    public double activationprice
    {
        get
        {
            return this.activationpriceField;
        }
        set
        {
            this.activationpriceField = value;
        }
    }

    /// <remarks/>
    public string brokerref
    {
        get
        {
            return this.brokerrefField;
        }
        set
        {
            this.brokerrefField = value;
        }
    }

    /// <remarks/>
    public int quantity
    {
        get
        {
            return this.quantityField;
        }
        set
        {
            this.quantityField = value;
        }
    }

    /// <remarks/>
    public double orderprice
    {
        get
        {
            return this.orderpriceField;
        }
        set
        {
            this.orderpriceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string usecredit
    {
        get
        {
            return this.usecreditField;
        }
        set
        {
            this.usecreditField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class ordersStoporderTakeprofit
{

    private double activationpriceField;

    private int quantityField;

    private double correctionField;

    /// <remarks/>
    public double activationprice
    {
        get
        {
            return this.activationpriceField;
        }
        set
        {
            this.activationpriceField = value;
        }
    }

    /// <remarks/>
    public int quantity
    {
        get
        {
            return this.quantityField;
        }
        set
        {
            this.quantityField = value;
        }
    }

    /// <remarks/>
    public double correction
    {
        get
        {
            return this.correctionField;
        }
        set
        {
            this.correctionField = value;
        }
    }
}


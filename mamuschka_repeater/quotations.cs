
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class quotations
{

    private quotationsQuotation[] quotationField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("quotation")]
    public quotationsQuotation[] quotation
    {
        get
        {
            return this.quotationField;
        }
        set
        {
            this.quotationField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class quotationsQuotation
{

    private string boardField;

    private string seccodeField;

    private double lastField;

    private string quantityField;

    private string timeField;

    private double changeField;

    private double priceminusprevwapriceField;

    private double biddepthField;

    private double biddepthtField;

    private string offerdepthField;

    private double offerdepthtField;

    private double numoffersField;

    private double voltodayField;

    private double numtradesField;

    private double valtodayField;

    private double openpositionsField;

    private double deltapositionsField;

    private double secidField;

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
    public double last
    {
        get
        {
            return this.lastField;
        }
        set
        {
            this.lastField = value;
        }
    }

    /// <remarks/>
    public string quantity
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
    public double change
    {
        get
        {
            return this.changeField;
        }
        set
        {
            this.changeField = value;
        }
    }

    /// <remarks/>
    public double priceminusprevwaprice
    {
        get
        {
            return this.priceminusprevwapriceField;
        }
        set
        {
            this.priceminusprevwapriceField = value;
        }
    }

    /// <remarks/>
    public double biddepth
    {
        get
        {
            return this.biddepthField;
        }
        set
        {
            this.biddepthField = value;
        }
    }

    /// <remarks/>
    public double biddeptht
    {
        get
        {
            return this.biddepthtField;
        }
        set
        {
            this.biddepthtField = value;
        }
    }

    /// <remarks/>
    public string offerdepth
    {
        get
        {
            return this.offerdepthField;
        }
        set
        {
            this.offerdepthField = value;
        }
    }

    /// <remarks/>
    public double offerdeptht
    {
        get
        {
            return this.offerdepthtField;
        }
        set
        {
            this.offerdepthtField = value;
        }
    }

    /// <remarks/>
    public double numoffers
    {
        get
        {
            return this.numoffersField;
        }
        set
        {
            this.numoffersField = value;
        }
    }

    /// <remarks/>
    public double voltoday
    {
        get
        {
            return this.voltodayField;
        }
        set
        {
            this.voltodayField = value;
        }
    }

    /// <remarks/>
    public double numtrades
    {
        get
        {
            return this.numtradesField;
        }
        set
        {
            this.numtradesField = value;
        }
    }

    /// <remarks/>
    public double valtoday
    {
        get
        {
            return this.valtodayField;
        }
        set
        {
            this.valtodayField = value;
        }
    }

    /// <remarks/>
    public double openpositions
    {
        get
        {
            return this.openpositionsField;
        }
        set
        {
            this.openpositionsField = value;
        }
    }

    /// <remarks/>
    public double deltapositions
    {
        get
        {
            return this.deltapositionsField;
        }
        set
        {
            this.deltapositionsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public double secid
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
}


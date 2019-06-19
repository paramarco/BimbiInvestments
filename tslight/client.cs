
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class client
{

    private int marketField;

    private string currencyField;

    private string typeField;

    private string unionField;

    private string idField;

    private bool removeField;

    /// <remarks/>
    public int market
    {
        get
        {
            return this.marketField;
        }
        set
        {
            this.marketField = value;
        }
    }

    /// <remarks/>
    public string currency
    {
        get
        {
            return this.currencyField;
        }
        set
        {
            this.currencyField = value;
        }
    }

    /// <remarks/>
    public string type
    {
        get
        {
            return this.typeField;
        }
        set
        {
            this.typeField = value;
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
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool remove
    {
        get
        {
            return this.removeField;
        }
        set
        {
            this.removeField = value;
        }
    }
}


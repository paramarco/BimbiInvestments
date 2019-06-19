
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class result
{

    private bool successField;

    private int transactionidField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool success
    {
        get
        {
            return this.successField;
        }
        set
        {
            this.successField = value;
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


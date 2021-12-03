using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Users")]
    public class UserRootDto
    {
        [XmlElement("count")]
        public string Count { get; set; }

        [XmlArray("users")]
        public ExportUserWithProductsDto[] Users { get; set; }
    }
}

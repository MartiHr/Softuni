using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
    public class ExportUserWithProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public string Age { get; set; }

        [XmlElement("SoldProducts")]
        public ExportSoldProductDto SoldProducts { get; set; }
    }
}

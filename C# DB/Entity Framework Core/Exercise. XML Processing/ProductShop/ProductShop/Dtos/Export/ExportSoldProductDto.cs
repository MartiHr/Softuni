using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("SoldProducts")]
    public class ExportSoldProductDto 
    {
        [XmlElement("count")]
        public string Count { get; set; }

        [XmlArray("products")]
        public SoldProductDto[] SoldProducts { get; set; }
    }
}

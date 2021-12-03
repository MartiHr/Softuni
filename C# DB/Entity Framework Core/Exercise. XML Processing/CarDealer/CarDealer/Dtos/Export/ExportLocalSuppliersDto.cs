using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("suplier")]
    public class ExportLocalSuppliersDto
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public string PartsCount { get; set; }
    }
}

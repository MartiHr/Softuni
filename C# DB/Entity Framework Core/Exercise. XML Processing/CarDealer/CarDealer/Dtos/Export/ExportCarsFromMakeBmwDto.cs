using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("car")]
    public class ExportCarsFromMakeBmwDto
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }


        [XmlAttribute("travelled-distance")]
        public string TravelledDistance { get; set; }
    }
}

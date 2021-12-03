using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportTaskDto
    {
        [Required]
        [XmlElement("Name")]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [Required]
        [Range(0, 3)]
        [XmlElement("ExecutionType")]
        public int ExecutionType { get; set; }

        [Required]
        [Range(0, 4)]
        [XmlElement("LabelType")]
        public int LabelType { get; set; }
    }
}

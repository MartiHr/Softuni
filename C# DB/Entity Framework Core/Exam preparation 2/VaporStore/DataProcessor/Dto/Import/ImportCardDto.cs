using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"^\d{4} \d{4} \d{4} \d{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}

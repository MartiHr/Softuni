using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    class ImportEmployeeDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"^[a-z]+\d*|[A-Z]+\d*$")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        [Required]
        public string Phone { get; set; }

        [Required]
        public int[] Tasks { get; set; }
    }
}

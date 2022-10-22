using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel : BaseBookModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; } = null!;
    }
}

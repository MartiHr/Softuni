using Library.Data.Models;

namespace Library.Models
{
    public class AddBookViewModel : BaseBookModel
    {
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}

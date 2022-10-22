using System.ComponentModel.DataAnnotations;

namespace Watchlist.Models
{
    public class MovieViewModel : BaseMovieModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Genre { get; set; } = null!;
    }
}

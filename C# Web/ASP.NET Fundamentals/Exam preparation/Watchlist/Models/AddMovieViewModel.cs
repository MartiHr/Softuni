using Watchlist.Data.Models;

namespace Watchlist.Models
{
    public class AddMovieViewModel : BaseMovieModel
    {
        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}

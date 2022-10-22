using System.ComponentModel.DataAnnotations.Schema;

namespace Watchlist.Data.Models
{
    public class UserMovie
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}

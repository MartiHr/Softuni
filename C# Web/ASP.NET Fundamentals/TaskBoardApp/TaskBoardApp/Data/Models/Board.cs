using System.ComponentModel.DataAnnotations;

using static TaskBoardApp.Constants.DataConstants.Board;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxBoardName)]
        public string Name { get; set; }

        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}

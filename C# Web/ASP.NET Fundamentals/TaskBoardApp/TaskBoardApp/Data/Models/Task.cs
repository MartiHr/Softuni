using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Data.Models.Account;
using static TaskBoardApp.Constants.DataConstants.Task;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTaskTitle)]
        public string Title { get; set; }

        [Required]
        [MaxLength(MaxTaskDescription)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }
        public Board Board { get; init; }

        [Required]
        public string OwnerId { get; set; }
        public User Owner { get; init; }
    }
}

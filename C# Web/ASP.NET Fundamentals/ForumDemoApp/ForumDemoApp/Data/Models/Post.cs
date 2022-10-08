using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ForumDemoApp.Constants.DataConstants.Post;

namespace ForumDemoApp.Data.Models
{
    [Comment("Published posts")]
    public class Post
    {
        [Key]
        [Comment("Post identifier")]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        [Comment("Post title")]
        public string Title { get; set; } = null!;
        
        [Required]
        [StringLength(ContentMaxLength)]
        [Comment("Post content")]
        public string Content { get; set; } = null!;
        
        [Required]
        [Comment("Marks record as deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

using static TaskBoardApp.Constants.DataConstants.User;

namespace TaskBoardApp.Data.Models.Account
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(MaxUserFirstName)]
        public string FirstName { get; init; }
        
        [Required]
        [MaxLength(MaxUserLastName)]
        public string LastName { get; init; }
    }
}

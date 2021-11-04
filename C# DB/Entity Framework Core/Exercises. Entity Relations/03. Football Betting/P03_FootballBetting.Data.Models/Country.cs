using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_FootballBetting.Data.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; } = new HashSet<Town>();
    }
}

﻿using MusicHub.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ProducerNameMaxLength)]
        public string Name { get; set; }

        public string Pseudonym  { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Album> Albums { get; set; } = new HashSet<Album>();
    }
}

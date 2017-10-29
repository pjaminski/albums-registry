﻿using System.ComponentModel.DataAnnotations;

namespace AlbumsRegistry.Model
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string City { get; set; }
    }
}

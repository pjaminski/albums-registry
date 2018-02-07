using System;

namespace AlbumsRegistry.Core.Models
{
    public class AdminMode
    {
        public int Id { get; set; }

        public string PasswordCore { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ActiveSinceDate { get; set; }
    }
}
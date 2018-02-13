using System;
using AlbumsRegistry.Core.Services;

namespace AlbumsRegistry.Core.Models
{
    public class AdminMode
    {
        public int Id { get; set; }

        public string PasswordCore { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ActiveSinceDate { get; set; }

        public string GetCleanPassword()
        {
            return $"{Cipher.Decrypt(PasswordCore)}{GetPasswordSuffix()}";
        }

        private static string GetPasswordSuffix()
        {
            return (DateTime.UtcNow.Day * DateTime.UtcNow.Month).ToString();
        }
    }
}
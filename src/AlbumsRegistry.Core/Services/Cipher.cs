using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AlbumsRegistry.Core.Services
{
    public class Cipher
    {
        private static string _key = "13022018";
        private static string _vector = "albums-registry";

        public static string Encrypt(string value)
        {
            var buffer = Encoding.Unicode.GetBytes(value);
            var ms = GetMemoryStream(buffer, true);

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string value)
        {
            var buffer = Convert.FromBase64String(value);
            var ms = GetMemoryStream(buffer, false);

            return Encoding.Unicode.GetString(ms.ToArray(), 0, ms.ToArray().Length);
        }

        private static MemoryStream GetMemoryStream(byte[] buffer, bool encrypt)
        {
            var rijndael = Rijndael.Create();
            rijndael.Key = GetKey();
            rijndael.IV = GetIv();

            var ms = new MemoryStream();

            var cryptoTransform = encrypt ? rijndael.CreateEncryptor() : rijndael.CreateDecryptor();

            using (var cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
                cs.Dispose();
            }

            return ms;
        }

        private static byte[] GetKey()
        {
            if (_key.Length > 16)
            {
                _key = _key.Substring(1, 16);
            }
            
            while (_key.Length < 16)
            {
                _key = $"{_key}0";
            }

            return Encoding.Unicode.GetBytes(_key);
        }

        private static byte[] GetIv()
        {
            if (_vector.Length > 8)
            {
                _vector = _vector.Substring(1, 8);
            }

            while (_vector.Length < 8)
            {
                _vector = $"{_vector}0";
            }

            return Encoding.Unicode.GetBytes(_vector);
        }
    }
}
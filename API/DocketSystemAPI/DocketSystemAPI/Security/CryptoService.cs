using System;
using System.Security.Cryptography;
using System.Text;

namespace Security
{
    public class CryptoService : ICryptoService
    {
        public string CreateSalt()
        {
            var data = new byte[0x10];
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                cryptoServiceProvider.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }

        public string HashText(string text, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedText = string.Format("{0}{1}", salt, text);
                byte[] saltedTextAsBytes = Encoding.UTF8.GetBytes(saltedText);
                return Convert.ToBase64String(sha256.ComputeHash(saltedTextAsBytes));
            }
        }
    }
}

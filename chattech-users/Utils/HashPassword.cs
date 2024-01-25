using System.Text;
using Konscious.Security.Cryptography;

namespace chattech_users.Utils
{
    public class PasswordManager
    {
        public static string HashPassword(string password)
        {
            byte[] salt = GenerateSalt();

            var hasher = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                MemorySize = 65536,
                Iterations = 4
            };
            return Convert.ToBase64String(hasher.GetBytes(64)) + ":" + Convert.ToBase64String(salt);
        }

        private static byte[] GenerateSalt()
        {
            var salt = new byte[16];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
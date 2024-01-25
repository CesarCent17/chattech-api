using Konscious.Security.Cryptography;
using System.Text;

namespace chattech_auth.Utils
{
    public class PasswordManager
    {
        public static (string Hash, string Salt) HashPassword(string password)
        {
            byte[] salt = GenerateSalt();

            var hasher = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                MemorySize = 65536,
                Iterations = 4
            };

            string hashedPassword = Convert.ToBase64String(hasher.GetBytes(64));

            return (hashedPassword, Convert.ToBase64String(salt));
        }

        public static bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            string[] parts = hashedPassword.Split(':');
            if (parts.Length != 2)
            {
                return false;  
            }

            string storedHash = parts[0];
            string storedSalt = parts[1];

            var hasher = new Argon2id(Encoding.UTF8.GetBytes(inputPassword))
            {
                Salt = Convert.FromBase64String(storedSalt),
                DegreeOfParallelism = 8,
                MemorySize = 65536,
                Iterations = 4
            };

            string inputHashedPassword = Convert.ToBase64String(hasher.GetBytes(64));
            return inputHashedPassword == storedHash;
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

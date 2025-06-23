using System.Security.Cryptography;

namespace CalendarPetProject.BusinessLogic.Security.Password
{
    internal class PasswordHasher
    {
        private const int SALT_SIZE = 16;
        private const int HASH_SIZE = 20;
        private const int ITERATIONS = 10000;

        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }

            byte[] salt = new byte[SALT_SIZE];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, ITERATIONS, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(HASH_SIZE);

            byte[] hashBytes = new byte[SALT_SIZE + HASH_SIZE];
            Array.Copy(salt, 0, hashBytes, 0, SALT_SIZE);
            Array.Copy(hash, 0, hashBytes, SALT_SIZE, HASH_SIZE);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(enteredPassword))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(enteredPassword));
            }

            if (string.IsNullOrWhiteSpace(storedHash))
            {
                throw new ArgumentException("Stored hash cannot be null or empty.", nameof(storedHash));
            }
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            byte[] salt = new byte[SALT_SIZE];
            Array.Copy(hashBytes, 0, salt, 0, SALT_SIZE);

            byte[] storedHashPart = new byte[HASH_SIZE];
            Array.Copy(hashBytes, SALT_SIZE, storedHashPart, 0, HASH_SIZE);

            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, ITERATIONS, HashAlgorithmName.SHA256);
            byte[] enteredPasswordHash = pbkdf2.GetBytes(HASH_SIZE);

            for (int i = 0; i < HASH_SIZE; i++)
            {
                if (storedHashPart[i] != enteredPasswordHash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

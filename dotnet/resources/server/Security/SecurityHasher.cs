using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace server.Security {
    public static class SecurityHasher {
        private static readonly RandomNumberGenerator Rng = new RNGCryptoServiceProvider();
        private static readonly KeyDerivationPrf pbkdf2Prf = KeyDerivationPrf.HMACSHA1;
        private static readonly int pbkdf2IterCount = 1000; // default for Rfc2898DeriveBytes
        private static readonly int pbkdf2SubkeyLength = 256 / 8; // 256 bits
        private static readonly int saltSize = 128 / 8; // 128 bits
        public static string HashPassword(string password) {
            return Convert.ToBase64String(Pbkdf2PrfPasswordHasher(password));
        }

        private static byte[] Pbkdf2PrfPasswordHasher(string password) {  var salt = new byte[saltSize];
            Rng.GetBytes(salt);
            byte[] subkey = KeyDerivation.Pbkdf2(password, salt, pbkdf2Prf, pbkdf2IterCount, pbkdf2SubkeyLength);
            var outputBytes = new byte[1 + saltSize + pbkdf2SubkeyLength];
            outputBytes[0] = 0x00; // format marker
            Buffer.BlockCopy(salt, 0, outputBytes, 1, saltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + saltSize, pbkdf2SubkeyLength);
            return outputBytes;
        }

        public static bool VerifyHashedPassword(byte[] decodedHashPassword, string password) {
            if (decodedHashPassword.Length != 1 + saltSize + pbkdf2SubkeyLength)
            {
                return false; // bad size
            }

            byte[] salt = new byte[saltSize];
            Buffer.BlockCopy(decodedHashPassword, 1, salt, 0, salt.Length);

            byte[] expectedSubkey = new byte[pbkdf2SubkeyLength];
            Buffer.BlockCopy(decodedHashPassword, 1 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

            byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, pbkdf2Prf, pbkdf2IterCount, pbkdf2SubkeyLength);

            return ByteArraysEqual(expectedSubkey, actualSubkey);
        }

        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            return a.SequenceEqual(b);
        }
    }
}
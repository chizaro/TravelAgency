using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace TravelAgency.Business.Security
{
    public class Hashing
    {
        public string HashCode { get; private set; }

        private static byte[] GenerateRandom(int size)
        {
            byte[] random = new byte[size];
            RandomNumberGenerator.Create().GetBytes(random);
            return random;
        }

        public void GenerateHash(string password)
        {
            byte[] data;
            using (var hash = SHA256.Create())
            {
                data = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            var resultHash = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                resultHash.Append(data[i].ToString("x2"));
            HashCode = resultHash.ToString();
        }

        public bool VerifyHash(string hash)
        {
            var comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Equals(HashCode, hash);
        }
    }
}

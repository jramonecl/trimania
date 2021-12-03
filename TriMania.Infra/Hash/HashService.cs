using System;
using System.Security.Cryptography;
using System.Text;
using TriMania.Domain;
using TriMania.Domain.User.Services;

namespace TriMania.Infra.Hash
{
    public class HashService : IHashService
    {
        public string ComputeHash(string message)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(message));
            return ToHex(hashedBytes);
        }

        public string ToHex(byte[] x)
        {
            return BitConverter.ToString(x).Replace("-", "").ToLower();
        }
    }
}
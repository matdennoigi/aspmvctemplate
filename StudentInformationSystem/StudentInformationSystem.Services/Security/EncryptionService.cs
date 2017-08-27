using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services.Security
{
    public class EncryptionService : IEncryptionService
    {
        public string CreateHash(byte[] data)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(data);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public string CreateHashPassword(string password)
        {
            return CreateHash(Encoding.ASCII.GetBytes(password));
        }
    }
}

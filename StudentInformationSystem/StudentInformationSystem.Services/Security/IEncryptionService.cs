using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services.Security
{
    public interface IEncryptionService
    {
        string CreateHashPassword(string password);
        string CreateHash(byte[] data);
    }
}

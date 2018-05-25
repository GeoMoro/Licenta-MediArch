using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediArch.Services.Interfaces
{
    public interface ICryptoService
    {
        string Encrypt(string input);
        string Decrypt(string input);
    }
}

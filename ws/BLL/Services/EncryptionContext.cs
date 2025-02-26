using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ServicesContracts;

namespace BLL.Services
{
    public class EncryptionContext
    {
        private IEncryption _strategy;

        public void SetStrategy(IEncryption strategy)
        {
            _strategy = strategy;
        }

        public string EncryptPassword(string password)
        {
            return _strategy.Encrypt(password);
        }

        public string DecryptPassword(string encryptedPassword)
        {
            return _strategy.Decrypt(encryptedPassword);
        }
    }
}

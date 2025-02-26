﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServicesContracts
{
    public interface IEncryption
    {
        string Encrypt(string plainText);
        string Decrypt(string encryptedText);
    }
}

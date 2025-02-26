using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    using System.Security.Cryptography;

    namespace BLL.Services.Encryption
    {
        /// <summary>
        /// Classe utilitaire pour générer des clés RSA
        /// </summary>
        public static class RSAKeyGenerator
        {
            public static (string publicKey, string privateKey) GenerateKeyPair()
            {
                using (RSA rsa = RSA.Create())
                {
                    // Taille de la clé: 2048 bits (recommandée)
                    rsa.KeySize = 2048;

                    // Exporter les clés au format XML
                    string publicKey = rsa.ToXmlString(false);  // Clé publique uniquement
                    string privateKey = rsa.ToXmlString(true);  // Clé privée (inclut la clé publique)

                    return (publicKey, privateKey);
                }
            }
        }
    }
}

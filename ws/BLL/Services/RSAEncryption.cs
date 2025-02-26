using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BLL.ServicesContracts;

namespace BLL.Services
{
    public class RSAEncryption : IEncryption
    {
        private readonly RSA _privateKey;
        private readonly RSA _publicKey;

        public RSAEncryption(string publicKeyXml, string privateKeyXml)
        {
            try
            {
                _publicKey = RSA.Create();
                _privateKey = RSA.Create();

                // Vérifiez que les clés ne sont pas vides et sont au format correct
                if (string.IsNullOrEmpty(publicKeyXml) || string.IsNullOrEmpty(privateKeyXml))
                    throw new ArgumentException("Les clés RSA ne peuvent pas être nulles ou vides");

                _publicKey.FromXmlString(publicKeyXml);
                _privateKey.FromXmlString(privateKeyXml);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erreur lors de l'initialisation des clés RSA: {ex.Message}", ex);
            }
        }

        public string Encrypt(string plainText)
        {
            try
            {
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedData = _publicKey.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA256);
                return Convert.ToBase64String(encryptedData);
            }
            catch (Exception ex)
            {
                throw new CryptographicException($"Erreur lors du chiffrement RSA: {ex.Message}", ex);
            }
        }

        public string Decrypt(string encryptedText)
        {
            try
            {
                byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);
                byte[] decryptedData = _privateKey.Decrypt(dataToDecrypt, RSAEncryptionPadding.OaepSHA256);
                return Encoding.UTF8.GetString(decryptedData);
            }
            catch (Exception ex)
            {
                throw new CryptographicException($"Erreur lors du déchiffrement RSA: {ex.Message}", ex);
            }
        }
    }
}

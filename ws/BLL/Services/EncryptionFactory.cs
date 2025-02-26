using BLL.DTOs;
using DAL.Entities;
using Microsoft.Extensions.Configuration;
using BLL.ServicesContracts;

namespace BLL.Services.Encryption
{
    public class EncryptionFactory
    {
        private readonly IConfiguration _configuration;

        public EncryptionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEncryption CreateStrategy(ApplicationType applicationType)
        {
            switch (applicationType)
            {
                case ApplicationType.PublicApplication:
                    return new AESEncryption(
                        _configuration["Encryption:AES:Key"],
                        _configuration["Encryption:AES:IV"]);

                case ApplicationType.ProfessionalApplication:
                    return new RSAEncryption(
                        _configuration["Encryption:RSA:PublicKey"],
                        _configuration["Encryption:RSA:PrivateKey"]);

                default:
                    throw new System.ArgumentException("Invalid application type");
            }
        }
    }
}
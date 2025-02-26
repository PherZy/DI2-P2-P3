using BLL.DTOs;
using BLL.Services.Encryption;
using BLL.ServicesContracts;
using DAL.Entities;
using DAL.RepositoriesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _passwordRepository;
        private readonly IApplicationRepository _applicationRepository;
        private readonly EncryptionFactory _encryptionFactory;
        private readonly EncryptionContext _encryptionContext;

        public PasswordService(
            IPasswordRepository passwordRepository,
            IApplicationRepository applicationRepository,
            EncryptionFactory encryptionFactory)
        {
            _passwordRepository = passwordRepository;
            _applicationRepository = applicationRepository;
            _encryptionFactory = encryptionFactory;
            _encryptionContext = new EncryptionContext();
        }

        public async Task<IEnumerable<PasswordDto>> GetAllPasswordsAsync()
        {
            var passwords = await _passwordRepository.GetPasswordsWithApplicationsAsync();
            var passwordDtos = new List<PasswordDto>();

            foreach (var password in passwords)
            {
                var strategy = _encryptionFactory.CreateStrategy(password.Application.Type);
                _encryptionContext.SetStrategy(strategy);

                passwordDtos.Add(new PasswordDto
                {
                    Id = password.Id,
                    Username = password.Username,
                    Password = _encryptionContext.DecryptPassword(password.EncryptedPassword),
                    Notes = password.Notes,
                    ApplicationId = password.ApplicationId,
                    ApplicationName = password.Application.Name
                });
            }

            return passwordDtos;
        }

        public async Task<PasswordDto> GetPasswordByIdAsync(int id)
        {
            var password = await _passwordRepository.GetPasswordByIdWithApplicationAsync(id);

            if (password == null)
                return null;

            var strategy = _encryptionFactory.CreateStrategy(password.Application.Type);
            _encryptionContext.SetStrategy(strategy);

            return new PasswordDto
            {
                Id = password.Id,
                Username = password.Username,
                Password = _encryptionContext.DecryptPassword(password.EncryptedPassword),
                Notes = password.Notes,
                ApplicationId = password.ApplicationId,
                ApplicationName = password.Application.Name
            };
        }

        public async Task<PasswordDto> CreatePasswordAsync(CreatePasswordDto createPasswordDto)
        {
            var application = await _applicationRepository.GetByIdAsync(createPasswordDto.ApplicationId);

            if (application == null)
                throw new ArgumentException("Application not found");

            var strategy = _encryptionFactory.CreateStrategy(application.Type);
            _encryptionContext.SetStrategy(strategy);

            var encryptedPassword = _encryptionContext.EncryptPassword(createPasswordDto.Password);

            var password = new Password
            {
                Username = createPasswordDto.Username,
                EncryptedPassword = encryptedPassword,
                Notes = createPasswordDto.Notes,
                ApplicationId = createPasswordDto.ApplicationId,
                CreatedAt = DateTime.UtcNow
            };

            await _passwordRepository.AddAsync(password);
            await _passwordRepository.SaveChangesAsync();

            return new PasswordDto
            {
                Id = password.Id,
                Username = password.Username,
                Password = createPasswordDto.Password,
                Notes = password.Notes,
                ApplicationId = password.ApplicationId,
                ApplicationName = application.Name
            };
        }

        public async Task<bool> DeletePasswordAsync(int id)
        {
            var password = await _passwordRepository.GetByIdAsync(id);

            if (password == null)
                return false;

            await _passwordRepository.RemoveAsync(password);
            await _passwordRepository.SaveChangesAsync();

            return true;
        }
    }
}

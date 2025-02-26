using BLL.DTOs;
using BLL.ServicesContracts;
using DAL.RepositoriesContracts;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<IEnumerable<ApplicationDto>> GetAllApplicationsAsync()
        {
            var applications = await _applicationRepository.GetAllAsync();
            return applications.Select(a => new ApplicationDto
            {
                Id = a.Id,
                Name = a.Name,
                Type = a.Type
            });
        }

        public async Task<ApplicationDto> GetApplicationByIdAsync(int id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);

            if (application == null)
                return null;

            return new ApplicationDto
            {
                Id = application.Id,
                Name = application.Name,
                Type = application.Type
            };
        }

        public async Task<ApplicationDto> CreateApplicationAsync(CreateApplicationDto createApplicationDto)
        {
            var application = new Application
            {
                Name = createApplicationDto.Name,
                Type = createApplicationDto.Type,
                CreatedAt = DateTime.UtcNow
            };

            await _applicationRepository.AddAsync(application);
            await _applicationRepository.SaveChangesAsync();

            return new ApplicationDto
            {
                Id = application.Id,
                Name = application.Name,
                Type = application.Type
            };
        }
    }
}

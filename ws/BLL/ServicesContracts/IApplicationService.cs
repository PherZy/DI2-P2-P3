using BLL.DTOs;


namespace BLL.ServicesContracts
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationDto>> GetAllApplicationsAsync();
        Task<ApplicationDto> GetApplicationByIdAsync(int id);
        Task<ApplicationDto> CreateApplicationAsync(CreateApplicationDto createApplicationDto);
    }
}

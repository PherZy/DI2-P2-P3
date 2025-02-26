using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoriesContracts
{
    public interface IApplicationRepository : IRepository<Application>
    {
        Task<IEnumerable<Application>> GetApplicationsWithPasswordsAsync();
        Task<Application> GetApplicationByIdWithPasswordsAsync(int id);
    }
}

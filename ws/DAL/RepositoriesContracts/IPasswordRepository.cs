using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoriesContracts
{
    public interface IPasswordRepository : IRepository<Password>
    {
        Task<IEnumerable<Password>> GetPasswordsWithApplicationsAsync();
        Task<Password> GetPasswordByIdWithApplicationAsync(int id);
    }
}

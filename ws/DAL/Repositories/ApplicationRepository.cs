using DAL.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        public ApplicationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Application>> GetApplicationsWithPasswordsAsync()
        {
            return await _dbSet
                .Include(a => a.Passwords)
                .ToListAsync();
        }

        public async Task<Application> GetApplicationByIdWithPasswordsAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Passwords)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}

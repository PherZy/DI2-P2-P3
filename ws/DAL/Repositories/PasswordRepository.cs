using DAL.Entities;
using DAL.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PasswordRepository : Repository<Password>, IPasswordRepository
    {
        public PasswordRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Password>> GetPasswordsWithApplicationsAsync()
        {
            return await _dbSet
                .Include(p => p.Application)
                .ToListAsync();
        }

        public async Task<Password> GetPasswordByIdWithApplicationAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Application)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

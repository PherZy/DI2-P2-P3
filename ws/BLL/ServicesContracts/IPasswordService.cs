using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServicesContracts
{
    public interface IPasswordService
    {
        Task<IEnumerable<PasswordDto>> GetAllPasswordsAsync();
        Task<PasswordDto> GetPasswordByIdAsync(int id);
        Task<PasswordDto> CreatePasswordAsync(CreatePasswordDto createPasswordDto);
        Task<bool> DeletePasswordAsync(int id);
    }
}

using Microsoft.AspNetCore.Mvc;
using BLL.ServicesContracts;
using BLL.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordsController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordsController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPasswords()
        {
            var passwords = await _passwordService.GetAllPasswordsAsync();
            return Ok(passwords);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPasswordById(int id)
        {
            var password = await _passwordService.GetPasswordByIdAsync(id);

            if (password == null)
                return NotFound();

            return Ok(password);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePassword([FromBody] CreatePasswordDto createPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var password = await _passwordService.CreatePasswordAsync(createPasswordDto);
                return CreatedAtAction(nameof(GetPasswordById), new { id = password.Id }, password);
            }
            catch (System.ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassword(int id)
        {
            var result = await _passwordService.DeletePasswordAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}

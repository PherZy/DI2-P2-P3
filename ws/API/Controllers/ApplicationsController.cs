using BLL.DTOs;
using BLL.ServicesContracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApplications()
        {
            var applications = await _applicationService.GetAllApplicationsAsync();
            return Ok(applications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);

            if (application == null)
                return NotFound();

            return Ok(application);
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication([FromBody] CreateApplicationDto createApplicationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var application = await _applicationService.CreateApplicationAsync(createApplicationDto);
            return CreatedAtAction(nameof(GetApplicationById), new { id = application.Id }, application);
        }
    }
}

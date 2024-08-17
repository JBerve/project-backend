using Continuum.Application.Interfaces;
using Continuum.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Continuum.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetConfigurationByClientId(int clientId)
        {
            var configuration = await _configurationService.GetConfigurationByClientIdAsync(clientId);
            if (configuration == null)
            {
                return NotFound();
            }
            return Ok(configuration);
        }

        [HttpPost]
        public async Task<IActionResult> AddConfiguration(Configuration configuration)
        {
            await _configurationService.AddConfigurationAsync(configuration);
            return CreatedAtAction(nameof(GetConfigurationByClientId), new { clientId = configuration.ClientId }, configuration);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConfiguration(int id, Configuration configuration)
        {
            if (id != configuration.Id)
            {
                return BadRequest();
            }

            try
            {
                await _configurationService.UpdateConfigurationAsync(configuration);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiguration(int id)
        {
            try
            {
                await _configurationService.DeleteConfigurationAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
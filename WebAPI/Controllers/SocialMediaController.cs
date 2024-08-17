using Continuum.Application.Interfaces;
using Continuum.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Continuum.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var socialMedia = await _socialMediaService.GetSocialMediaByIdAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }
            return Ok(socialMedia);
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetAllSocialMedia(int clientId)
        {
            var socialMedia = await _socialMediaService.GetAllSocialMediaAsync(clientId);
            return Ok(socialMedia);
        }

        [HttpPost]
        public async Task<IActionResult> AddSocialMedia(SocialMedia socialMedia)
        {
            await _socialMediaService.AddSocialMediaAsync(socialMedia);
            return CreatedAtAction(nameof(GetSocialMediaById), new { id = socialMedia.Id }, socialMedia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSocialMedia(int id, SocialMedia socialMedia)
        {
            if (id != socialMedia.Id)
            {
                return BadRequest();
            }

            try
            {
                await _socialMediaService.UpdateSocialMediaAsync(socialMedia);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            try
            {
                await _socialMediaService.DeleteSocialMediaAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
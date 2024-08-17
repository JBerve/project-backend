using Continuum.Application.Interfaces;
using Continuum.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Continuum.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaContentController : ControllerBase
    {
        private readonly IMediaContentService _mediaContentService;

        public MediaContentController(IMediaContentService mediaContentService)
        {
            _mediaContentService = mediaContentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMediaContentById(int id)
        {
            var mediaContent = await _mediaContentService.GetMediaContentByIdAsync(id);
            if (mediaContent == null)
            {
                return NotFound();
            }
            return Ok(mediaContent);
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetAllMediaContents(int clientId)
        {
            var mediaContents = await _mediaContentService.GetAllMediaContentsAsync(clientId);
            return Ok(mediaContents);
        }

        [HttpPost]
        public async Task<IActionResult> AddMediaContent(MediaContent mediaContent)
        {
            await _mediaContentService.AddMediaContentAsync(mediaContent);
            return CreatedAtAction(nameof(GetMediaContentById), new { id = mediaContent.Id }, mediaContent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMediaContent(int id, MediaContent mediaContent)
        {
            if (id != mediaContent.Id)
            {
                return BadRequest();
            }

            try
            {
                await _mediaContentService.UpdateMediaContentAsync(mediaContent);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediaContent(int id)
        {
            try
            {
                await _mediaContentService.DeleteMediaContentAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
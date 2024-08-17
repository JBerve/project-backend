using Continuum.Application.Interfaces;
using Continuum.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Continuum.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentBlockController : ControllerBase
    {
        private readonly IContentBlockService _contentBlockService;

        public ContentBlockController(IContentBlockService contentBlockService)
        {
            _contentBlockService = contentBlockService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContentBlockById(int id)
        {
            var contentBlock = await _contentBlockService.GetContentBlockByIdAsync(id);
            if (contentBlock == null)
            {
                return NotFound();
            }
            return Ok(contentBlock);
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetAllContentBlocks(int clientId)
        {
            var contentBlocks = await _contentBlockService.GetAllContentBlocksAsync(clientId);
            return Ok(contentBlocks);
        }

        [HttpPost]
        public async Task<IActionResult> AddContentBlock(ContentBlock contentBlock)
        {
            await _contentBlockService.AddContentBlockAsync(contentBlock);
            return CreatedAtAction(nameof(GetContentBlockById), new { id = contentBlock.Id }, contentBlock);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContentBlock(int id, ContentBlock contentBlock)
        {
            if (id != contentBlock.Id)
            {
                return BadRequest();
            }

            try
            {
                await _contentBlockService.UpdateContentBlockAsync(contentBlock);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentBlock(int id)
        {
            try
            {
                await _contentBlockService.DeleteContentBlockAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
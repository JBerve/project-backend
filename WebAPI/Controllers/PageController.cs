using Continuum.Application.Interfaces;
using Continuum.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Continuum.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PageController : ControllerBase
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPageById(int id)
        {
            var page = await _pageService.GetPageByIdAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            return Ok(page);
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetAllPages(int clientId)
        {
            var pages = await _pageService.GetAllPagesAsync(clientId);
            return Ok(pages);
        }

        [HttpPost]
        public async Task<IActionResult> AddPage(Page page)
        {
            await _pageService.AddPageAsync(page);
            return CreatedAtAction(nameof(GetPageById), new { id = page.Id }, page);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePage(int id, Page page)
        {
            if (id != page.Id)
            {
                return BadRequest();
            }

            try
            {
                await _pageService.UpdatePageAsync(page);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePage(int id)
        {
            try
            {
                await _pageService.DeletePageAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
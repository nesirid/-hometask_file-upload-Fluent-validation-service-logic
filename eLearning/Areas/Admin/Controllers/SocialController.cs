using AutoMapper;
using eLearning.DTOs.Socials;
using eLearning.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Areas.Admin.Controllers
{
    public class SocialController : BaseController
    {
        private readonly ISocialService _socialService;
        private readonly IMapper _mapper;

        public SocialController(ISocialService socialService, IMapper mapper)
        {
            _socialService = socialService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var socials = await _socialService.GetAllAsync();
            return Ok(socials);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var social = await _socialService.GetByIdAsync(id);
            if (social == null) return NotFound();

            return Ok(social);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SocialCreateDto socialCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdSocial = await _socialService.CreateAsync(socialCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = createdSocial.Id }, createdSocial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] SocialEditDto socialEditDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingSocial = await _socialService.GetByIdAsync(id);
            if (existingSocial == null) return NotFound();

            await _socialService.UpdateAsync(id, socialEditDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingSocial = await _socialService.GetByIdAsync(id);
            if (existingSocial == null) return NotFound();

            await _socialService.DeleteAsync(id);
            return NoContent();
        }
    }
}

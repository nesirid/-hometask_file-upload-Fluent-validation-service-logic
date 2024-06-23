using AutoMapper;
using eLearning.DTOs.InformationIcons;
using eLearning.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Areas.Admin.Controllers
{
    public class InformationIconController : BaseController
    {
        private readonly IInformationIconService _informationIconService;
        private readonly IMapper _mapper;

        public InformationIconController(IInformationIconService informationIconService, IMapper mapper)
        {
            _informationIconService = informationIconService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var informationIcons = await _informationIconService.GetAllAsync();
            return Ok(informationIcons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var informationIcon = await _informationIconService.GetByIdAsync(id);
            if (informationIcon == null) return NotFound();

            return Ok(informationIcon);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] InformationIconCreateDto informationIconCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _informationIconService.CreateAsync(informationIconCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = informationIconCreateDto }, informationIconCreateDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] InformationIconEditDto informationIconEditDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingInformationIcon = await _informationIconService.GetByIdAsync(id);
            if (existingInformationIcon == null) return NotFound();

            await _informationIconService.UpdateAsync(id, informationIconEditDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingInformationIcon = await _informationIconService.GetByIdAsync(id);
            if (existingInformationIcon == null) return NotFound();

            await _informationIconService.DeleteAsync(id);
            return NoContent();
        }
    }
}

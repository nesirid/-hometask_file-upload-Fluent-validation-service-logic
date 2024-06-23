using AutoMapper;
using eLearning.DTOs.Instructors;
using eLearning.Models;
using eLearning.Services;
using eLearning.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Areas.Admin.Controllers
{
    public class InstructorController : BaseController
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;

        public InstructorController(IInstructorService instructorService, IMapper mapper)
        {
            _instructorService = instructorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var instructors = await _instructorService.GetAllAsync();
            return Ok(instructors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var instructor = await _instructorService.GetByIdAsync(id);
            if (instructor == null) return NotFound();

            return Ok(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] InstructorCreateDto instructorCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var instructor = _mapper.Map<Instructor>(instructorCreateDto);
            await _instructorService.CreateAsync(instructorCreateDto);

            return CreatedAtAction(nameof(GetById), new { id = instructor.Id }, _mapper.Map<InstructorDto>(instructor));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] InstructorEditDto instructorEditDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _instructorService.UpdateAsync(id, instructorEditDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingInstructor = await _instructorService.GetByIdAsync(id);
            if (existingInstructor == null) return NotFound();

            await _instructorService.DeleteAsync(id);
            return NoContent();
        }
    }
}

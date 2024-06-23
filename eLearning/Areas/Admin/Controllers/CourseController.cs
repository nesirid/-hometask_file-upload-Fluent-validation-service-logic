using AutoMapper;
using eLearning.DTOs.Courses;
using eLearning.Models;
using eLearning.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Areas.Admin.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null) return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CourseCreateDto courseCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = _mapper.Map<Course>(courseCreateDto);
            await _courseService.CreateAsync(courseCreateDto);

            return CreatedAtAction(nameof(GetById), new { id = course.Id }, _mapper.Map<CourseDto>(course));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] CourseEditDto courseEditDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _courseService.UpdateAsync(id, courseEditDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCourse = await _courseService.GetByIdAsync(id);
            if (existingCourse == null) return NotFound();

            await _courseService.DeleteAsync(id);
            return NoContent();
        }
    }
}

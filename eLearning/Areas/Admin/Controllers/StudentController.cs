using AutoMapper;
using eLearning.DTOs.Students;
using eLearning.Models;
using eLearning.Services;
using eLearning.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Areas.Admin.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StudentCreateDto studentCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _mapper.Map<Student>(studentCreateDto);
            await _studentService.CreateAsync(studentCreateDto);

            return CreatedAtAction(nameof(GetById), new { id = student.Id }, _mapper.Map<StudentDto>(student));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] StudentEditDto studentEditDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _studentService.UpdateAsync(id, studentEditDto);

            return NoContent();
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var existingStudent = await _studentService.GetByIdAsync(id);
            if (existingStudent == null) return NotFound();

            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}

using AutoMapper;
using eLearning.Data;
using eLearning.DTOs.Students;
using eLearning.Models;
using eLearning.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _context.Students.Include(s => s.CourseStudents).ThenInclude(cs => cs.Course).ToListAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await _context.Students.Include(s => s.CourseStudents).ThenInclude(cs => cs.Course).FirstOrDefaultAsync(s => s.Id == id);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task CreateAsync(StudentCreateDto studentCreateDto)
        {
            var student = _mapper.Map<Student>(studentCreateDto);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, StudentEditDto studentEditDto)
        {
            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            _mapper.Map(studentEditDto, existingStudent);
            _context.Students.Update(existingStudent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}

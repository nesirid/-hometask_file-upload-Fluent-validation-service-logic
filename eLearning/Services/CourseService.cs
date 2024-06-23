using AutoMapper;
using eLearning.Data;
using eLearning.DTOs.Courses;
using eLearning.Models;
using eLearning.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CourseService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var courses = await _context.Courses.Include(c => c.Category).Include(c => c.Instructor).ToListAsync();
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await _context.Courses.Include(c => c.Category).Include(c => c.Instructor).FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CourseDto>(course);
        }

        public async Task CreateAsync(CourseCreateDto courseCreateDto)
        {
            var course = _mapper.Map<Course>(courseCreateDto);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CourseEditDto courseEditDto)
        {
            var existingCourse = await _context.Courses.FindAsync(id);
            if (existingCourse == null)
            {
                throw new KeyNotFoundException("Course not found");
            }

            _mapper.Map(courseEditDto, existingCourse);
            _context.Courses.Update(existingCourse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                throw new KeyNotFoundException("Course not found");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}

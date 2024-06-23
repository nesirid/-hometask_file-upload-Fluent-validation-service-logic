using AutoMapper;
using eLearning.DTOs.Instructors;
using eLearning.Models;
using Microsoft.EntityFrameworkCore;
using eLearning.Data;
using eLearning.Services.Interfaces;

namespace eLearning.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InstructorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstructorDto>> GetAllAsync()
        {
            var instructors = await _context.Instructors.Include(i => i.Courses).ToListAsync();
            return _mapper.Map<IEnumerable<InstructorDto>>(instructors);
        }

        public async Task<InstructorDto> GetByIdAsync(int id)
        {
            var instructor = await _context.Instructors.Include(i => i.Courses).FirstOrDefaultAsync(i => i.Id == id);
            return _mapper.Map<InstructorDto>(instructor);
        }

        public async Task CreateAsync(InstructorCreateDto instructorCreateDto)
        {
            var instructor = _mapper.Map<Instructor>(instructorCreateDto);

            if (instructorCreateDto.Images != null && instructorCreateDto.Images.Count > 0)
            {
                foreach (var image in instructorCreateDto.Images)
                {
                    var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(image.FileName)}";
                    var filePath = Path.Combine("wwwroot/images", uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    instructor.Image = uniqueFileName;
                }
            }

            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, InstructorEditDto instructorEditDto)
        {
            var existingInstructor = await _context.Instructors.FindAsync(id);
            if (existingInstructor == null)
            {
                throw new KeyNotFoundException("Instructor not found");
            }

            if (instructorEditDto.Images != null && instructorEditDto.Images.Count > 0)
            {
                foreach (var image in instructorEditDto.Images)
                {
                    var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(image.FileName)}";
                    var filePath = Path.Combine("wwwroot/images", uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    existingInstructor.Image = uniqueFileName; 
                }
            }
            _mapper.Map(instructorEditDto, existingInstructor);
            _context.Instructors.Update(existingInstructor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                throw new KeyNotFoundException("Instructor not found");
            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
        }
    }
}

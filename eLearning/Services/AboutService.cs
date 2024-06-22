using AutoMapper;
using eLearning.Data;
using eLearning.DTOs.Abouts;
using eLearning.Models;
using eLearning.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AboutService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AboutDto>> GetAllAsync()
        {
            var abouts = await _context.Abouts.ToListAsync();
            return _mapper.Map<IEnumerable<AboutDto>>(abouts);
        }

        public async Task<AboutDto> GetByIdAsync(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            return _mapper.Map<AboutDto>(about);
        }

        public async Task CreateAsync(AboutCreateDto aboutCreateDto)
        {
            var about = _mapper.Map<About>(aboutCreateDto);
            _context.Abouts.Add(about);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, AboutDto aboutDto)
        {
            var existingAbout = await _context.Abouts.FindAsync(id);
            if (existingAbout == null)
            {
                throw new KeyNotFoundException("About not found");
            }

            _mapper.Map(aboutDto, existingAbout);
            _context.Abouts.Update(existingAbout);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            if (about == null)
            {
                throw new KeyNotFoundException("About not found");
            }

            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();
        }
    }
}

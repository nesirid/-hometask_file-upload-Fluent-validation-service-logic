using AutoMapper;
using eLearning.Data;
using eLearning.DTOs.Socials;
using eLearning.Models;
using eLearning.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Services
{
    public class SocialService : ISocialService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SocialService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SocialDto>> GetAllAsync()
        {
            var socials = await _context.Socials.ToListAsync();
            return _mapper.Map<IEnumerable<SocialDto>>(socials);
        }

        public async Task<SocialDto> GetByIdAsync(int id)
        {
            var social = await _context.Socials.FindAsync(id);
            return _mapper.Map<SocialDto>(social);
        }

        public async Task<SocialDto> CreateAsync(SocialCreateDto socialCreateDto)
        {
            var social = _mapper.Map<Social>(socialCreateDto);
            _context.Socials.Add(social);
            await _context.SaveChangesAsync();
            return _mapper.Map<SocialDto>(social);
        }

        public async Task UpdateAsync(int id, SocialEditDto socialEditDto)
        {
            var existingSocial = await _context.Socials.FindAsync(id);
            if (existingSocial == null)
            {
                throw new KeyNotFoundException("Social not found");
            }

            _mapper.Map(socialEditDto, existingSocial);
            _context.Socials.Update(existingSocial);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var social = await _context.Socials.FindAsync(id);
            if (social == null)
            {
                throw new KeyNotFoundException("Social not found");
            }

            _context.Socials.Remove(social);
            await _context.SaveChangesAsync();
        }

    }
}

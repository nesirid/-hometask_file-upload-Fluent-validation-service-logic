using AutoMapper;
using eLearning.Data;
using eLearning.DTOs.InformationIcons;
using eLearning.Models;
using eLearning.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Services
{
    public class InformationIconService : IInformationIconService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InformationIconService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InformationIconDto>> GetAllAsync()
        {
            var informationIcons = await _context.InformationIcons.ToListAsync();
            return _mapper.Map<IEnumerable<InformationIconDto>>(informationIcons);
        }

        public async Task<InformationIconDto> GetByIdAsync(int id)
        {
            var informationIcon = await _context.InformationIcons.FindAsync(id);
            return _mapper.Map<InformationIconDto>(informationIcon);
        }

        public async Task CreateAsync(InformationIconCreateDto informationIconCreateDto)
        {
            var informationIcon = _mapper.Map<InformationIcon>(informationIconCreateDto);
            _context.InformationIcons.Add(informationIcon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, InformationIconEditDto informationIconEditDto)
        {
            var existingInformationIcon = await _context.InformationIcons.FindAsync(id);
            if (existingInformationIcon == null)
            {
                throw new KeyNotFoundException("InformationIcon not found");
            }

            _mapper.Map(informationIconEditDto, existingInformationIcon);
            _context.InformationIcons.Update(existingInformationIcon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var informationIcon = await _context.InformationIcons.FindAsync(id);
            if (informationIcon == null)
            {
                throw new KeyNotFoundException("InformationIcon not found");
            }

            _context.InformationIcons.Remove(informationIcon);
            await _context.SaveChangesAsync();
        }

    }
}

using AutoMapper;
using eLearning.Data;
using eLearning.DTOs.Sliders;
using eLearning.Models;
using eLearning.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SliderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SliderDto>> GetAllAsync()
        {
            var sliders = await _context.Sliders.ToListAsync();
            return _mapper.Map<IEnumerable<SliderDto>>(sliders);
        }

        public async Task<SliderDto> GetByIdAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            return _mapper.Map<SliderDto>(slider);
        }

        public async Task CreateAsync(SliderDto sliderDto)
        {
            var slider = _mapper.Map<Slider>(sliderDto);
            _context.Sliders.Add(slider);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, SliderDto sliderDto)
        {
            var existingSlider = await _context.Sliders.FindAsync(id);
            if (existingSlider == null)
            {
                throw new KeyNotFoundException("Slider not found");
            }

            _mapper.Map(sliderDto, existingSlider);
            _context.Sliders.Update(existingSlider);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null)
            {
                throw new KeyNotFoundException("Slider not found");
            }

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }
    }
}

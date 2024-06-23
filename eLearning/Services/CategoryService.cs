using AutoMapper;
using eLearning.Data;
using eLearning.DTOs.Categories;
using eLearning.Models;
using eLearning.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories.Include(c => c.Courses).ToListAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _context.Categories.Include(c => c.Courses).FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            var category = _mapper.Map<Category>(categoryCreateDto);

            if (categoryCreateDto.Image != null)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(categoryCreateDto.Image.FileName)}";
                var filePath = Path.Combine("wwwroot/images", uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await categoryCreateDto.Image.CopyToAsync(stream);
                }
                category.Image = uniqueFileName;
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CategoryDto categoryDto)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            _mapper.Map(categoryDto, existingCategory);
            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}

using AutoMapper;
using eLearning.DTOs.Categories;
using eLearning.Models;
using eLearning.Services;
using eLearning.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto categoryCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = _mapper.Map<Category>(categoryCreateDto);

            if (categoryCreateDto.Image != null)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(categoryCreateDto.Image.FileName)}";
                var filePath = Path.Combine("wwwroot/images/", uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await categoryCreateDto.Image.CopyToAsync(stream);
                }
                category.Image = Path.Combine("images", uniqueFileName);
            }
            await _categoryService.CreateAsync(categoryCreateDto);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, _mapper.Map<CategoryDto>(category));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] CategoryEditDto categoryEditDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingCategory = await _categoryService.GetByIdAsync(id);
            if (existingCategory == null) return NotFound();

            var imagePaths = existingCategory.Image?.Split(",").ToList() ?? new List<string>();
            if (categoryEditDto.ImagesToRemove != null && categoryEditDto.ImagesToRemove.Count > 0)
            {
                foreach (var imageToRemove in categoryEditDto.ImagesToRemove)
                {
                    var fullPath = Path.Combine("wwwroot", imageToRemove);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    imagePaths.Remove(imageToRemove);
                }
            }

            if (categoryEditDto.Images != null && categoryEditDto.Images.Count > 0)
            {
                foreach (var image in categoryEditDto.Images)
                {
                    if (!image.ContentType.StartsWith("image/"))
                    {
                        ModelState.AddModelError("Images", "Input can accept only image format");
                        return BadRequest(ModelState);
                    }
                    if (image.Length > 500 * 1024)
                    {
                        ModelState.AddModelError("Images", "Image size must be max 500 KB");
                        return BadRequest(ModelState);
                    }
                    var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(image.FileName)}";
                    var filePath = Path.Combine("wwwroot/images/", uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    imagePaths.Add(Path.Combine("images", uniqueFileName));
                }
            }

            var updatedCategory = _mapper.Map(categoryEditDto, existingCategory);
            updatedCategory.Image = string.Join(",", imagePaths);

            await _categoryService.UpdateAsync(id, _mapper.Map<CategoryDto>(updatedCategory));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCategory = await _categoryService.GetByIdAsync(id);
            if (existingCategory == null) return NotFound();

            await _categoryService.DeleteAsync(id);
            return Ok();
        }
    }
}

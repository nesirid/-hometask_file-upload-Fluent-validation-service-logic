using AutoMapper;
using eLearning.DTOs.Abouts;
using eLearning.Models;
using eLearning.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Areas.Admin.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var abouts = await _aboutService.GetAllAsync();
            return Ok(abouts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            if (about == null) return NotFound();

            return Ok(about);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AboutCreateDto aboutCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imagePaths = new List<string>();
            if (aboutCreateDto.Images != null && aboutCreateDto.Images.Count > 0)
            {
                foreach (var image in aboutCreateDto.Images)
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

            var about = _mapper.Map<About>(aboutCreateDto);
            about.Image = string.Join(",", imagePaths);

            await _aboutService.CreateAsync(_mapper.Map<AboutCreateDto>(about));

            return CreatedAtAction(nameof(GetById), new { id = about.Id }, _mapper.Map<AboutDto>(about));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] AboutEditDto aboutEditDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingAbout = await _aboutService.GetByIdAsync(id);
            if (existingAbout == null) return NotFound();

            var imagePaths = existingAbout.Image?.Split(",").ToList() ?? new List<string>();
            if (aboutEditDto.ImagesToRemove != null && aboutEditDto.ImagesToRemove.Count > 0)
            {
                foreach (var imageToRemove in aboutEditDto.ImagesToRemove)
                {
                    var fullPath = Path.Combine("wwwroot", imageToRemove);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    imagePaths.Remove(imageToRemove);
                }
            }

            if (aboutEditDto.Images != null && aboutEditDto.Images.Count > 0)
            {
                foreach (var image in aboutEditDto.Images)
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

            var updatedAbout = _mapper.Map(aboutEditDto, existingAbout);
            updatedAbout.Image = string.Join(",", imagePaths);

            await _aboutService.UpdateAsync(id, _mapper.Map<AboutDto>(updatedAbout));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _aboutService.DeleteAsync(id);
            return NoContent();
        }
    }
}

using AutoMapper;
using eLearning.DTOs.Sliders;
using eLearning.Models;
using eLearning.Services;
using eLearning.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Areas.Admin.Controllers
{
    public class SliderController : BaseController
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sliders = await _sliderService.GetAllAsync();
            return Ok(sliders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var slider = await _sliderService.GetByIdAsync(id);
            if (slider == null) return NotFound();

            return Ok(slider);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SliderCreateDto sliderCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imagePaths = new List<string>();
            if (sliderCreateDto.Images != null && sliderCreateDto.Images.Count > 0)
            {
                foreach (var image in sliderCreateDto.Images)
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

            var slider = _mapper.Map<Slider>(sliderCreateDto);
            slider.Image = string.Join(",", imagePaths);

            await _sliderService.CreateAsync(_mapper.Map<SliderDto>(slider));

            return CreatedAtAction(nameof(GetById), new { id = slider.Id }, _mapper.Map<SliderDto>(slider));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] SliderEditDto sliderEditDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingSlider = await _sliderService.GetByIdAsync(id);
            if (existingSlider == null) return NotFound();

            var imagePaths = existingSlider.Image?.Split(",").ToList() ?? new List<string>();
            if (sliderEditDto.ImagesToRemove != null && sliderEditDto.ImagesToRemove.Count > 0)
            {
                foreach (var imageToRemove in sliderEditDto.ImagesToRemove)
                {
                    var fullPath = Path.Combine("wwwroot", imageToRemove);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    imagePaths.Remove(imageToRemove);
                }
            }

            if (sliderEditDto.Images != null && sliderEditDto.Images.Count > 0)
            {
                foreach (var image in sliderEditDto.Images)
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

            var updatedSlider = _mapper.Map(sliderEditDto, existingSlider);
            updatedSlider.Image = string.Join(",", imagePaths);

            await _sliderService.UpdateAsync(id, _mapper.Map<SliderDto>(updatedSlider));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingSlider = await _sliderService.GetByIdAsync(id);
            if (existingSlider == null) return NotFound();

            await _sliderService.DeleteAsync(id);
            return NoContent();
        }
    }
}

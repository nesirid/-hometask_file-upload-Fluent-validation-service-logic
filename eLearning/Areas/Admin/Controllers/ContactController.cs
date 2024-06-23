using AutoMapper;
using eLearning.DTOs.Contacts;
using eLearning.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactService.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            if (contact == null) return NotFound();

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ContactCreateDto contactCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactService.CreateAsync(contactCreateDto);
            var createdContact = await _contactService.GetByIdAsync(contactCreateDto.Id);
            return CreatedAtAction(nameof(GetById), new { id = createdContact.Id }, createdContact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromForm] ContactEditDto contactEditDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingContact = await _contactService.GetByIdAsync(id);
            if (existingContact == null) return NotFound();

            await _contactService.UpdateAsync(id, contactEditDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingContact = await _contactService.GetByIdAsync(id);
            if (existingContact == null) return NotFound();

            await _contactService.DeleteAsync(id);
            return NoContent();
        }
    }
}

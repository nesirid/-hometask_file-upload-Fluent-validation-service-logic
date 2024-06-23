using AutoMapper;
using eLearning.Data;
using eLearning.DTOs.Contacts;
using eLearning.Models;
using eLearning.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eLearning.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ContactService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> GetAllAsync()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return _mapper.Map<IEnumerable<ContactDto>>(contacts);
        }

        public async Task<ContactDto> GetByIdAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task CreateAsync(ContactCreateDto contactCreateDto)
        {
            var contact = _mapper.Map<Contact>(contactCreateDto);
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ContactEditDto contactEditDto)
        {
            var existingContact = await _context.Contacts.FindAsync(id);
            if (existingContact == null)
            {
                throw new KeyNotFoundException("Contact not found");
            }

            _mapper.Map(contactEditDto, existingContact);
            _context.Contacts.Update(existingContact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                throw new KeyNotFoundException("Contact not found");
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}

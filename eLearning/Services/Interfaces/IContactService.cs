using eLearning.DTOs.Contacts;

namespace eLearning.Services.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>> GetAllAsync();
        Task<ContactDto> GetByIdAsync(int id);
        Task CreateAsync(ContactCreateDto contactCreateDto);
        Task UpdateAsync(int id, ContactEditDto contactEditDto);
        Task DeleteAsync(int id);
    }
}

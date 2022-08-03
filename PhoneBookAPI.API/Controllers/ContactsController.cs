using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookAPI.Application.Repositories;
using PhoneBookAPI.Domain.Entities;

namespace PhoneBookAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        readonly private IContactWriteRepository _contactWriteRepository;
        readonly private IContactReadRepository _contactReadRepository;
        readonly private ICommunicationReadRepository _communicationReadRepository;

        public ContactsController(IContactReadRepository contactReadRepository,IContactWriteRepository contactWriteRepository, ICommunicationReadRepository communicationReadRepository)
        {
            _contactReadRepository = contactReadRepository;
            _contactWriteRepository = contactWriteRepository;
            _communicationReadRepository = communicationReadRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(_contactReadRepository.GetAll(false));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            Contact contact = await _contactReadRepository.GetByIdAsync(id, false);     
            contact.Communications = (ICollection<Communication>)_communicationReadRepository.GetWhere( x => x.Contact.Id == contact.Id);
            return Ok(contact);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Contact model)
        {
            await _contactWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Surname = model.Surname,
                Company = model.Company
            });
            await _contactWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _contactWriteRepository.RemoveAsync(id);
            await _contactWriteRepository.SaveAsync();

            return Ok();
        }
    }
}

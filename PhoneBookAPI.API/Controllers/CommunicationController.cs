using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookAPI.Application.Repositories;
using PhoneBookAPI.Domain.Entities;
using PhoneBookAPI.Persistence.Repositories;

namespace PhoneBookAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ICommunicationReadRepository _communicationReadRepository;
        private readonly ICommunicationWriteRepository _communicationWriteRepository;
        readonly private IContactReadRepository _contactReadRepository;

        public CommunicationController(CommunicationReadRepository communicationReadRepository,CommunicationWriteRepository communicationWriteRepository, IContactReadRepository contactReadRepository)
        {
            _communicationReadRepository = communicationReadRepository;
            _communicationWriteRepository = communicationWriteRepository;
            _contactReadRepository = contactReadRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Communication model,string id)
        {

            Contact contact = await _contactReadRepository.GetByIdAsync(id);

            await _communicationWriteRepository.AddAsync(new()
            {
                Contact = contact,
                Email = model.Email,
                Information = model.Information,
                PhoneNumber = model.PhoneNumber,
                Location = model.Location,
         
            });
            await _communicationWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {

            await _communicationWriteRepository.RemoveAsync(id);
            await _communicationWriteRepository.SaveAsync();

            return Ok();
        }
    }
}

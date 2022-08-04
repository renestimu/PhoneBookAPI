using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookAPI.Application.Repositories;
using PhoneBookAPI.Persistence.Repositories;

namespace PhoneBookAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        readonly private IReportWriteRepository _reportWriteRepository;
        readonly private IReportReadRepository _reportReadRepository;

        public ReportController(ReportWriteRepository reportWriteRepository,ReportReadRepository reportReadRepository)
        {
            _reportWriteRepository = reportWriteRepository;
            _reportReadRepository = reportReadRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(_reportReadRepository.GetAll(false));
        }
    }
}

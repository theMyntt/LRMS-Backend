using lrms.Application.DTOs;
using lrms.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lrms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpPost("new")]
        public async Task<IActionResult> Insert([FromBody] ClientInsertDTO dTO)
        {
            var result = await _service.Insert(dTO);

            return StatusCode(result.StatusCode, result);
        }
    }
}

using lrms.Application.DTOs;
using lrms.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lrms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService _service)
        {
            this._service = _service;
        }

        [HttpPost("login")]
        [Tags("User Auth")]
        public async Task<ActionResult<LoginOutputDTO>> Login([FromBody] LoginInputDTO dto)
        {
            var response = await _service.Login(dto);

            if (response == null)
                return NotFound(new
                {
                    message = "No user found",
                    statusCode = 404
                });

            return Ok(response);
        }

        [HttpPost("new")]
        [Tags("User Management")]
        public async Task<IActionResult> Create([FromBody] UserInsertDTO dto)
        {
            var response = await _service.Insert(dto);

            if (response == null)
                return BadRequest(new
                {
                    message = "We cant create this user",
                    statusCode = 400
                });

            return StatusCode(201, response);
        }
    }
}

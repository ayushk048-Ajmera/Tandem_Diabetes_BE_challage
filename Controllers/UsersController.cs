using Microsoft.AspNetCore.Mvc;
using Tandem_Diabetes_BE_challenge.Entities;
using Tandem_Diabetes_BE_challenge.DTOs;
using Tandem_Diabetes_BE_challenge.Services;

namespace Tandem_Diabetes_BE_challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) => _userService = userService;
        

        [HttpGet]
        public async Task<ActionResult> GetUser(string? email)
        {
            if(email == null)
            {
                IEnumerable<UserResponseDTO> users = await _userService.getAllUsers();
                return Ok(users);
            } else
            {
                IEnumerable<UserResponseDTO> users = await _userService.getUserByEmail(email);
                if(users.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(users);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] UserDTO body) {
            await _userService.createUser(body);
            return Created("user",body);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Tandem_Diabetes_BE_challenge.Entities;
using Tandem_Diabetes_BE_challenge.Repository;

namespace Tandem_Diabetes_BE_challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(string? email)
        {
            if(email == null)
            {
                IEnumerable<User> enumerable = await _userRepository.getAllUsers();
                return Ok(enumerable);
            } else
            {
                IEnumerable<User> enumerable = await _userRepository.getUserByEmail(email);
                return Ok(enumerable);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User body) {
            await _userRepository.createUser(body);
            return Ok();
        }


    }
}

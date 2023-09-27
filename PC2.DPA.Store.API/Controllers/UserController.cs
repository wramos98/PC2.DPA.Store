using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC2.DPA.Store.DOMAIN.Core.Entities;
using PC2.DPA.Store.DOMAIN.Core.Interfaces;

namespace PC2.DPA.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userRepository.GetUsers();
            return Ok(user);
        }

        [HttpGet("Login")]
        public async Task<IActionResult> GetUserByEmailAndPassword([FromQuery] String email, String password)
        {
            var user = await _userRepository.GetUser(email, password);
            return Ok(user);
        }

        [HttpPost("Sing Up")]

        public async Task<IActionResult> Insert(User user)
        {
            var result = await _userRepository.Insert(user);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userRepository.Delete(id);
            return Ok(result);
        }












    }
}

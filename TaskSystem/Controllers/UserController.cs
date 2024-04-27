using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
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
        public async Task<ActionResult<List<UserModel>>> FindAll()
        {
            List<UserModel> users = await _userRepository.FindAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> FindById(int id)
        {
            UserModel users = await _userRepository.FindById(id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Create([FromBody] UserModel user)
        {
            UserModel newUser = await _userRepository.Add(user);
            return Ok(newUser);
        }
    }
}

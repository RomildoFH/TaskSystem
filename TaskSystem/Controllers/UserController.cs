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

        [HttpPatch("{id}")]
        public async Task<ActionResult<UserModel>> UpdateOne([FromBody] UserModel user, int id)
        {
            UserModel existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
            {
                return NotFound("Usuário não encontrado com o ID informado.");
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            await _userRepository.Update(existingUser, id);

            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteOne(int id)
        {
            UserModel existingUser = await _userRepository.FindById(id);

            if (existingUser == null)
            {
                return NotFound("Usuário não encontrado com o ID informado.");
            }

            await _userRepository.Delete(id);

            return Ok($"Usuário ID {id} deletado com sucesso");
        }
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> NameContaing([FromQuery] string name, [FromQuery] string email) 
        {
            List<UserModel> users = await _userRepository.FindAllUsers();

            if(!string.IsNullOrEmpty(name))
            {
                users = users.Where(u => u.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(email))
            {
                users = users.Where(u => u.Email.Contains(email));
            }

            return Ok(users);
        }
    }
}

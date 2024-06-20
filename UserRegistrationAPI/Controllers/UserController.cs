using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistrationAPI.Data;
using UserRegistrationAPI.DTOs;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        public UserController(UserContext context) 
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (user == null)
            {
                return BadRequest("Usuário nulo");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id inválido");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _context.Users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Password = u.Password
                });
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            if (userDto == null || id <= 0)
            {
                return BadRequest("IDs não correspondem ou são inválidos");
            }

            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
            {
                return NotFound("Usuário não encontrado");
            }

            // Aplicando atualizações apenas para as propriedades que foram fornecidas
            // Podendo receber nulo ou vazio
            // ***** Buscar uma forma melhor de tratar isso *****
            if (!string.IsNullOrEmpty(userDto.FirstName))
            {
                existingUser.FirstName = userDto.FirstName;
            }

            if (!string.IsNullOrEmpty(userDto.LastName))
            {
                existingUser.LastName = userDto.LastName;
            }

            if (!string.IsNullOrEmpty(userDto.Email))
            {
                existingUser.Email = userDto.Email;
            }

            if (!string.IsNullOrEmpty(userDto.Password))
            {
                existingUser.Password = userDto.Password;
            }

            try
            {
                _context.Users.Update(existingUser);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

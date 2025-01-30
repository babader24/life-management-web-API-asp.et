using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_managemant_web_API.Data;
using Task_managemant_web_API.DTOs;
using Task_managemant_web_API.Models;
using Task_managemant_web_API.Repository.Base;

namespace Task_managemant_web_API.Controllers
{
	[Route("api/Users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IRepository<User> _UserRepository;

        public UsersController(IRepository<User> UserRepository)
        {
			_UserRepository = UserRepository;
        }

		[HttpGet]
		public async Task<IActionResult> Users()
		{
			var Users = await _UserRepository.GetAllAsync();

			return Ok(Users);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]

		public async Task<IActionResult> GetUserById(int id)
		{
			if (id < 0)
			{
				return BadRequest($"Not Accepted ID {id}");
			}

			var User = await _UserRepository.GetByIdAsync(id);
			if (User != null)
			{
				return Ok(User);
			}
			return NotFound($"User {id} Not Found");
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateUserDto user)
		{
			var UserEntity = new User()
			{
				UserName = user.UserName,
				Email = user.Email,
				Password = user.Password,
				Image = user.Image,
				
				
			};
			var craetedUser = await _UserRepository.AddAsync(UserEntity);
			return CreatedAtAction(nameof(GetUserById), new { Id = craetedUser.Id }, craetedUser);
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] User user)
		{
			var UserEntity = await _UserRepository.GetByIdAsync(id);
			if (UserEntity == null)
			{
				return NotFound();
			}
			UserEntity.UserName = user.UserName;
			UserEntity.Email = user.Email;
			UserEntity.Password = user.Password;
			UserEntity.Image = user.Image;

			await _UserRepository.UpdateAsync(UserEntity);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var user = await _UserRepository.GetByIdAsync(id);
			if(user == null)
			{
				return NotFound();
			}
			await _UserRepository.DeleteAsync(user);
			return NoContent();
		}

	}
}

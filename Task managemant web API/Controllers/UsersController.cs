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
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Users()
		{
			var allUsers = await _UserRepository.GetAllAsync();

			if (allUsers == null || !allUsers.Any())
			{
				return NotFound("No users found.");
			}

			var users = allUsers.Select(user => new
			{
				UserId = user.Id,
				UserName = user.UserName,
				Email = user.Email,
				Image = user.Image
			}).ToList();

			return Ok(users);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]

		public async Task<IActionResult> GetUserById(int id)
		{
			if (id <= 0)
			{
				return BadRequest($"Invalid ID: {id}");
			}

			var userEntity = await _UserRepository.GetByIdAsync(id);
			if (userEntity == null)
			{
				return NotFound($"User with ID {id} not found.");

			}
			var user = new ShowUserDto()
			{
				UserId = id,
				UserName = userEntity.UserName,
				Email = userEntity.Email,
				Image = userEntity.Image,
			};

			return Ok(user);

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
		public async Task<IActionResult> Put(int id, [FromBody] CreateUserDto user)
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

		[HttpGet("AllUserInfo/{id}")]
		public async Task<IActionResult> GetAllUserInfo(int id)
		{
			if (id < 0)
			{
				return BadRequest($"Not Accepted ID {id}");
			}

			var User = await _UserRepository.GetAllUserInfoByIdAsync(id);
			if (User != null)
			{
				
				return Ok(User);
			}
			return NotFound($"User {id} Not Found");

		}
	}
}

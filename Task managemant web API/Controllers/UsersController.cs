using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_managemant_web_API.Data;
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

		[HttpGet("{Id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]

		public async Task<IActionResult> User(int Id)
		{
			if (Id < 0)
			{
				return BadRequest($"Not Accepted ID {Id}");
			}

			var User = await _UserRepository.GetByIdAsync(Id);
			if (User == null)
			{
				return NotFound($"User {Id} Not Found");
			}
			return Ok(User);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] User user)
		{
			var UserEntity = new User()
			{
				UserName = user.UserName,
				Email = user.Email,
				Password = user.Password,
				Image = user.Image
			};
			var craetedUser = await _UserRepository.AddAsync(UserEntity);
			return CreatedAtAction(nameof(User), new { Id = craetedUser.Id }, craetedUser);
		}
		[HttpPut("{Id}")]
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

		[HttpDelete("{Id}")]
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

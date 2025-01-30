using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_managemant_web_API.Data;

namespace Task_managemant_web_API.Controllers
{
	[Route("api/Users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly AppDbContext _db;

        public UsersController(AppDbContext db)
        {
            _db = db;
        }

		[HttpGet]
		public async Task<IActionResult> Users()
		{
			var Users = await _db.Users.ToListAsync();


			return Ok(Users);
		}

    }
}

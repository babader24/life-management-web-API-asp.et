using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.DTOs
{
	public class  CreateUserDto
	{
		public int UserId { get; set; }
		public string UserName { get; set; }

		public string Password { get; set; }

		public string? Email { get; set; }
		public string? Image { get; set; }


	}

}

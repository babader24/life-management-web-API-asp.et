using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_managemant_web_API.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public string? Email { get; set; }

		public string? Image { get; set; }

		public ICollection<StickyNote>? stickyNotes { get; set; } = new List<StickyNote>();

		public ICollection<Tasks>? Tasks { get; set; } = new List<Tasks>();

		public ICollection<NoteBook>? Notebooks { get; set; } = new List<NoteBook>();

		public ICollection<Habit>? habits { get; set; } = new List<Habit>();
	}

}

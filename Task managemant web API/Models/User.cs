using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task_managemant_web_API.Models
{
	public class User
	{
	
		public int Id { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public string? Email { get; set; }

		public string? Image { get; set; }
		public virtual ICollection<StickyNote>? stickyNotes { get; set; } = new List<StickyNote>();
		public virtual ICollection<Tasks>? Tasks { get; set; } = new List<Tasks>();
		public virtual ICollection<NoteBook>? Notebooks { get; set; } = new List<NoteBook>();
		public virtual ICollection<Habit>? habits { get; set; } = new List<Habit>();
	}

}

using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.DTOs
{
	public class UserDto
	{
		public string UserName { get; set; }

		public string? Email { get; set; }
		public string? Image { get; set; }

		public ICollection<StickyNoteDto>? stickyNotes { get; set; } = new List<StickyNoteDto>();

		public ICollection<TasksDto>? Tasks { get; set; } = new List<TasksDto>();

		public ICollection<NoteBookDto>? Notebooks { get; set; } = new List<NoteBookDto>();

		public ICollection<HabitDtos>? habits { get; set; } = new List<HabitDtos>();
	}

}

namespace Task_managemant_web_API.DTOs
{
	public class StickyNoteDto
	{

		public string? NoteDescription { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public int UserID { get; set; }
		public int ColorID { get; set; }
	}
}

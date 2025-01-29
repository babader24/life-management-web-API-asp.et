namespace Task_managemant_web_API.Models
{
	public class StickyNote
	{
		public int Id { get; set; }

		public string? NoteDescription { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public int UserID { get; set; }
		public User User { get; set; }	

		public int ColorID { get; set; }
		public Color Color { get; set; }
		
	}


}

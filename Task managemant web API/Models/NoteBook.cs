namespace Task_managemant_web_API.Models
{
	public class NoteBook
	{
        public int Id { get; set; }

		public string? NoteBookTitle { get; set; }

		public string? NoteBookDescription { get; set; }

		public int UserID { get; set; }
		public User User { get; set; }

    }
}

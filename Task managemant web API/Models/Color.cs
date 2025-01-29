namespace Task_managemant_web_API.Models
{
	public class Color
	{
		public int Id { get; set; }
		public  string ColorCode { get; set; }

		public StickyNote? StickyNote { get; set; }
	}
}

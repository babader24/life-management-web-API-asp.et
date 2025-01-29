namespace Task_managemant_web_API.Models
{
	public class DaysOfWeek
	{
		public int Id { get; set; }

		public short DayNumber { get; set; }		

		public ICollection<Tasks>? Tasks { get; set; } = new List<Tasks>();
	}


}

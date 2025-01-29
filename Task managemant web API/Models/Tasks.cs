namespace Task_managemant_web_API.Models
{
	public class Tasks
	{
		public int Id { get; set; }
		
		public string? TaskDescription { get; set; }

		public bool IsDone { get; set; }


		public int UserID { get; set; }
		public User User { get; set; }

		public int PriorityId { get; set; }
		public Priority	Priority { get; set; }

		public int DayId { get; set; }

		public DaysOfWeek DayOfWeek { get; set; }



	}


}

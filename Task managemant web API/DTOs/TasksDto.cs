namespace Task_managemant_web_API.DTOs
{
	public class TasksDto
	{
		public int Id { get; set; }

		public string? TaskDescription { get; set; }

		public bool IsDone { get; set; }


		public int UserID { get; set; }

		public int PriorityId { get; set; }

		public int DayId { get; set; }

	}
}

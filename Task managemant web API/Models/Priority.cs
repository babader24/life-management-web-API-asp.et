namespace Task_managemant_web_API.Models
{
	public class Priority
	{
		public int Id { get; set; }

		public short PriorityType { get; set; }

		public Tasks? Tasks { get; set; }

		public ICollection<Task>? TasksList { get; set; }  = new List<Task>();
	}


}

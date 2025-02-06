namespace Task_managemant_web_API.Models
{
	public class Priority
	{
		public int Id { get; set; }

		public short PriorityType { get; set; }

		//public Tasks Tasks { get; set; }

		public virtual ICollection<Tasks> Tasks { get; set; }  = new List<Tasks>();
	}


}

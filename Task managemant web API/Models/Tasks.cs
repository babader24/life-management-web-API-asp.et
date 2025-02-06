using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task_managemant_web_API.Models
{
	public class Tasks
	{
		
		public int Id { get; set; }
		
		public string? TaskDescription { get; set; }

		public bool IsDone { get; set; }


		public int UserID { get; set; }
		[JsonIgnore]
		public virtual User User { get; set; }

		public int PriorityId { get; set; }
		[JsonIgnore]
		public virtual Priority	Priority { get; set; }

		public int DayId { get; set; }
		[JsonIgnore]
		public virtual DaysOfWeek DayOfWeek { get; set; }



	}


}

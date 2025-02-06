using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task_managemant_web_API.Models
{
	public class Habit
	{
	
		public int Id { get; set; }

		public string HabitName { get; set; }

		public bool Sat {  get; set; }

		public bool Sun { get; set; }

		public bool Mon {  get; set; }

		public bool Tue { get; set; }

		public bool Wed { get; set; }

		public bool Thu { get; set; }

		public bool Fri { get; set; }

		public int UserId { get; set; }
		[JsonIgnore]
		public virtual User User { get; set; }
    }
}

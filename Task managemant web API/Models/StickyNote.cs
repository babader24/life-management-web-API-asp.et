using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task_managemant_web_API.Models
{
	public class StickyNote
	{

		public int Id { get; set; }

		public string? NoteDescription { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public int UserID { get; set; }
		[JsonIgnore]
		public virtual User User { get; set; }	

		public int ColorID { get; set; }
		[JsonIgnore]
		public virtual Color Color { get; set; }
		
	}


}

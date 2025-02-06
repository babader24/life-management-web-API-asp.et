using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task_managemant_web_API.Models
{
	public class NoteBook
	{
		public int Id { get; set; }

		public string? NoteBookTitle { get; set; }

		public string? NoteBookDescription { get; set; }

		public int UserID { get; set; }
		[JsonIgnore]
		public virtual User User { get; set; }

    }
}

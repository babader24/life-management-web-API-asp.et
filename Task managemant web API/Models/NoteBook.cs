using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_managemant_web_API.Models
{
	public class NoteBook
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string? NoteBookTitle { get; set; }

		public string? NoteBookDescription { get; set; }

		public int UserID { get; set; }
		public User User { get; set; }

    }
}

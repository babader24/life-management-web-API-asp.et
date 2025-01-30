using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_managemant_web_API.Models
{
	public class Color
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public  string ColorCode { get; set; }

		public StickyNote? StickyNote { get; set; }
	}
}

﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_managemant_web_API.Models
{
	public class Color
	{

		public int Id { get; set; }
		public  string ColorCode { get; set; }

		public virtual ICollection<StickyNote>? StickyNotes { get; set; } = new List<StickyNote>();
	}
}

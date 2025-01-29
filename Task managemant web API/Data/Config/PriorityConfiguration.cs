using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.Data.Config
{
	public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
	{
		public void Configure(EntityTypeBuilder<Priority> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever()
				.IsRequired();

			builder.Property(x=>x.PriorityType)
				.IsRequired();

			builder.ToTable("Priorities");

			builder.HasData(LoadPriorities());
				
		}

		private static List<Priority> LoadPriorities()
		{
			return new List<Priority>()
			{
				new Priority { Id = 1, PriorityType = 1},
				new Priority { Id = 2, PriorityType = 2},
				new Priority { Id = 3, PriorityType = 3},
			};
		}
	}

	
}

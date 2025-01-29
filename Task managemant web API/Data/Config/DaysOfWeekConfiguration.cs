using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.Data.Config
{
	public class DaysOfWeekConfiguration : IEntityTypeConfiguration<DaysOfWeek>
	{
		public void Configure(EntityTypeBuilder<DaysOfWeek> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever()
				.IsRequired();

			builder.Property(x => x.DayNumber)
				.IsRequired();

			builder.ToTable("Priorities");

			builder.HasData(LoadDaysOfWeek());

		}

		private static List<DaysOfWeek> LoadDaysOfWeek()
		{
			return new List<DaysOfWeek>()
			{
				new DaysOfWeek { Id = 1, DayNumber = 1},
				new DaysOfWeek { Id = 2, DayNumber = 2},
				new DaysOfWeek { Id = 3, DayNumber = 3},
				new DaysOfWeek { Id = 4, DayNumber = 4},
				new DaysOfWeek { Id = 5, DayNumber = 5},
				new DaysOfWeek { Id = 6, DayNumber = 6},
				new DaysOfWeek { Id = 7, DayNumber = 7},
			};
		}
	}
}

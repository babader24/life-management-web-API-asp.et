using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.Data.Config
{
	public class HabitConfiguration : IEntityTypeConfiguration<Habit>
	{
		public void Configure(EntityTypeBuilder<Habit> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever()
				.IsRequired();

			builder.Property(x=>x.HabitName).HasMaxLength(50)
				.IsRequired();


			builder.Property(x=>x.Sat).IsRequired();
			builder.Property(x=>x.Sun).IsRequired();
			builder.Property(x=>x.Mon).IsRequired();
			builder.Property(x=>x.Tue).IsRequired();
			builder.Property(x=>x.Wed).IsRequired();
			builder.Property(x=>x.Thu).IsRequired();
			builder.Property(x=>x.Fri).IsRequired();


			builder.HasOne(x => x.User)
				.WithMany(x => x.habits)
				.HasForeignKey(x => x.Id)
				.IsRequired();

			builder.ToTable("Habits");

			builder.HasData(
				new List<Habit>()
				{
					new Habit { Id = 1, HabitName = "Eat breakfast", Sat = true,Sun = false,Mon = true,Tue = false,Wed = false,Thu = true,
					Fri = false,UserId = 1}
				});
		}
	}
}

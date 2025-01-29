using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.Data.Config
{
	public class TasksConfiguration : IEntityTypeConfiguration<Tasks>
	{
		public void Configure(EntityTypeBuilder<Tasks> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever()
				.IsRequired();

			builder.Property(x => x.TaskDescription).HasMaxLength(255)
				.IsRequired();

			builder.Property(x => x.IsDone)
				.IsRequired();

			builder.HasOne(x => x.Priority)
				.WithOne(x => x.Tasks)
				.HasForeignKey<Tasks>(x => x.PriorityId)
				.IsRequired();

			builder.HasOne(x => x.DayOfWeek)
				.WithMany(x=> x.Tasks)
				.HasForeignKey(x => x.DayId)
				.IsRequired(false);

			builder.HasOne(x => x.User)
				.WithMany(x=> x.Tasks)
				.HasForeignKey(x=> x.UserID)
				.IsRequired(false);


			builder.ToTable("Tasks");

			builder.HasData(LoadTasks());
		}

		private static List<Tasks> LoadTasks()
		{
			return new List<Tasks>()
			{
				new Tasks {Id = 1, TaskDescription =  "i love Football", PriorityId = 1 , DayId = 1, IsDone = false, UserID = 1 }
			

			};
		}
	}
}

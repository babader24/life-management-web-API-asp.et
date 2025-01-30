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
			builder.Property(x => x.Id).ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(x => x.TaskDescription).HasMaxLength(255)
				.IsRequired();

			builder.Property(x => x.IsDone)
				.IsRequired();


			builder.HasOne(x => x.Priority)
				.WithMany(x => x.Tasks) 
				.HasForeignKey(x => x.PriorityId)
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
				new Tasks { Id=1,TaskDescription =  "i love Football", PriorityId = 1 , DayId = 1, IsDone = false, UserID = 1 },
				new Tasks {Id=2, TaskDescription =  "i love Moon", PriorityId = 2 , DayId = 4, IsDone = false, UserID = 1 },
				new Tasks { Id=3,TaskDescription =  "i love Study", PriorityId = 1 , DayId = 3, IsDone = false, UserID = 1 },
			

			};
		}
	}
}

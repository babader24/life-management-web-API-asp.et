using Microsoft.EntityFrameworkCore;
using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
		{

		}

		public DbSet<User> Users { get; set; }
		public DbSet<StickyNote> stickyNotes { get; set; }
		public DbSet<Color> Colors { get; set; }
		public DbSet<Tasks> Tasks { get; set; }
		public DbSet<Priority> priorities { get; set; }
		public DbSet<DaysOfWeek> DaysOfWeeks { get; set; }
		public DbSet<NoteBook> Notebooks { get; set; }
		public DbSet<Habit> Habits { get; set; }


		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	base.OnConfiguring(optionsBuilder);

		//	var onConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json")
		//		.Build();

		//	var connectionString = onConfig.GetSection("constr").Value;

		//	optionsBuilder.UseSqlServer(connectionString);
		//}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
	}
}

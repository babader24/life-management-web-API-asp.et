using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.Data.Config
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever()
				.IsRequired();

			builder.Property(x => x.UserName).HasMaxLength(255)
				.IsRequired();

			builder.Property(x => x.Password).HasMaxLength(50)
				.IsRequired();

			builder.Property(x => x.Email).HasMaxLength(50)
				.IsRequired();

			builder.Property(x => x.Image).HasMaxLength(255)
				.IsRequired();


			builder.ToTable("Users");

			builder.HasData(LoadUsers());

		}

		private static List<User> LoadUsers()
		{
			return new List<User>()
			{
				new User {Id =1 , UserName = "Ahmed Babder", Password = "123", Email = "ahmed@gmail.com", Image = "asfjhkjnbvm"},
			};
		}
	}
}

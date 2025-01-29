using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.Data.Config
{
	public class ColorConfiguration : IEntityTypeConfiguration<Color>
	{
		public void Configure(EntityTypeBuilder<Color> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever()
				.IsRequired();

			builder.Property(x => x.ColorCode).HasMaxLength(255);

			builder.HasOne(x => x.StickyNote)
				.WithOne(x => x.Color)
				.HasForeignKey<StickyNote>(x => x.ColorID)
				.IsRequired();

			builder.ToTable("Colors");

			builder.HasData(LoadColors());
		}

		private static List<Color> LoadColors()
		{
			return new List<Color>()
			{
				new Color{Id= 1, ColorCode = "#FF6B6B"},
				new Color{Id= 2, ColorCode = "#4ECDC4"},
				new Color{Id= 3, ColorCode = "#96CEB4"},
				new Color{Id= 4, ColorCode = "#FFEEAD"},
				new Color{Id= 5, ColorCode = "#D4A5A5"},
		
			};
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.Data.Config
{
	public class StickyNoteConfiguration : IEntityTypeConfiguration<StickyNote>
	{
		public void Configure(EntityTypeBuilder<StickyNote> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd()
				.IsRequired();
				

			builder.Property(x => x.NoteDescription).HasMaxLength(255)
				.IsRequired();

			builder.Property(x=>x.CreatedAt).IsRequired();

			builder.HasOne(x => x.User)
				.WithMany(x => x.stickyNotes)
				.HasForeignKey(x => x.UserID)
				.IsRequired();



			builder.ToTable("StickyNotes");

			builder.HasData(LoadStickyNotes());
				
		}

		private static List<StickyNote> LoadStickyNotes()
		{
			return new List<StickyNote>()
			{
				new StickyNote {Id=1,NoteDescription = "I am Jose Morinho", CreatedAt = Convert.ToDateTime("2025/01/20") , ColorID = 1, UserID = 1},
				new StickyNote {Id=2,NoteDescription = "I am Ahmed Babader", CreatedAt = Convert.ToDateTime("2025/01/20"), ColorID = 2, UserID = 1},
				new StickyNote {Id=3,NoteDescription = "I am Salim Mohammed", CreatedAt = Convert.ToDateTime("2025/01/20"), ColorID = 3, UserID = 1},
				new StickyNote {Id=4,NoteDescription = "I am Ali Ammar", CreatedAt = Convert.ToDateTime("2025/01/20"), ColorID = 4, UserID = 1},
			};
		}
	}
}

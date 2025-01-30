using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_managemant_web_API.Models;

namespace Task_managemant_web_API.Data.Config
{
	public class NoteBookConfiguration : IEntityTypeConfiguration<NoteBook>
	{
		public void Configure(EntityTypeBuilder<NoteBook> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever()
				.IsRequired();

			builder.Property(x => x.NoteBookTitle).HasMaxLength(50)
				.IsRequired();

			builder.Property(x=>x.NoteBookDescription).HasMaxLength(255)
				.IsRequired();

			builder.HasOne(x => x.User)
				.WithMany(x => x.Notebooks)
				.HasForeignKey(x => x.UserID)
				.IsRequired();

			builder.ToTable("Notebooks");

			builder.HasData(loadNoteBooks());
		}

		private static List<NoteBook> loadNoteBooks()
		{
			return new List<NoteBook>()
			{
				new NoteBook() {Id = 1, NoteBookTitle = "Sport", NoteBookDescription = "I Should Run 3KM", UserID =1},
				new NoteBook() {Id = 2, NoteBookTitle = "LifeStyle", NoteBookDescription = "Get Some Mobility Excercises ", UserID =1},
			};
		}
	}
}

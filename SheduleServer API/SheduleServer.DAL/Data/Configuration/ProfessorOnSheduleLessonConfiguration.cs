using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SheduleServer.Domain.Entity.Shedule;

namespace SheduleServer.DAL.Data.Configuration
{
	public class ProfessorOnSheduleLessonConfiguration : IEntityTypeConfiguration<SheduleLessonProfessor>
	{
		public void Configure(EntityTypeBuilder<SheduleLessonProfessor> builder)
		{
			builder.HasKey(lp => new { lp.ProfessorId, lp.SheduleLessonId });

			builder.HasOne(lp => lp.Professor)
				.WithMany()
				.HasForeignKey(lp => lp.ProfessorId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(lp => lp.SheduleLesson)
				.WithMany()
				.HasForeignKey(lp => lp.SheduleLessonId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}

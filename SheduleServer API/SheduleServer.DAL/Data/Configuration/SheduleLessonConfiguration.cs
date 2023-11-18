using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SheduleServer.Domain.Entity.Shedule;

namespace SheduleServer.DAL.Data.Configuration
{
	public class SheduleLessonConfiguration : IEntityTypeConfiguration<SheduleLesson>
	{
		public void Configure(EntityTypeBuilder<SheduleLesson> builder)
		{
			builder.HasOne(l => l.LessonTime)
				.WithMany()
				.HasForeignKey(l => l.LessonTimeId);

			builder.HasOne(l => l.Lesson)
				.WithMany()
				.HasForeignKey(l => l.LessonId);
		}
	}
}

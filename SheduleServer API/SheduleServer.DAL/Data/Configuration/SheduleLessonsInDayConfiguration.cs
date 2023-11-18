using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SheduleServer.Domain.Entity.Shedule;

namespace SheduleServer.DAL.Data.Configuration
{
	public class SheduleLessonsInDayConfiguration : IEntityTypeConfiguration<SheduleLessonsInDay>
	{
		public void Configure(EntityTypeBuilder<SheduleLessonsInDay> builder)
		{
			builder.HasKey(e => new { e.SheduleDayId, e.SheduleLessonId });
			
			builder.HasOne(e => e.SheduleLesson)
				.WithMany(l => l.SheduleLessonsInDays)
				.HasForeignKey(e => e.SheduleLessonId);

			builder.HasOne(e => e.SheduleDay)
				.WithMany(d => d.SheduleLessonsInDays)
				.HasForeignKey(e => e.SheduleDayId);
		}
	}
}

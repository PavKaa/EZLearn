using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SheduleServer.Domain.Entity.Shedule;

namespace SheduleServer.DAL.Data.Configuration
{
	public class UniversityConfiguration : IEntityTypeConfiguration<University>
	{
		public void Configure(EntityTypeBuilder<University> builder)
		{
			builder.HasMany(b => b.Groups)
				.WithOne()
				.HasForeignKey(g => g.UniversityId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}

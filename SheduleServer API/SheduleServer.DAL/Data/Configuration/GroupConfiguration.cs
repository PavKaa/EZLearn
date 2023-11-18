using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SheduleServer.Domain.Entity.Shedule;

namespace SheduleServer.DAL.Data.Configuration
{
	internal class GroupConfiguration : IEntityTypeConfiguration<Group>
	{
		public void Configure(EntityTypeBuilder<Group> builder)
		{
			builder.HasMany(g => g.SheduleTemplates)
				.WithOne()
				.HasForeignKey(t => t.GroupId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SheduleServer.Domain.Entity.Shedule;

namespace SheduleServer.DAL.Data.Configuration
{
	public class SheduleTemplateConfiguration : IEntityTypeConfiguration<SheduleTemplate>
	{
		public void Configure(EntityTypeBuilder<SheduleTemplate> builder)
		{
			builder.HasMany(t => t.SheduleDays)
				.WithOne()
				.HasForeignKey(d => d.SheduleTemplateId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}

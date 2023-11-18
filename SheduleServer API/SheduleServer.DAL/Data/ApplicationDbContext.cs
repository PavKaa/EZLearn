using Microsoft.EntityFrameworkCore;
using SheduleServer.DAL.Data.Configuration;
using SheduleServer.Domain.Entity.Shedule;

namespace SheduleServer.DAL.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Group> Groups { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<LessonTime> LessonTimes { get; set; }
		public DbSet<Professor> Professors { get; set; }
		public DbSet<SheduleLesson> SheduleLessons { get; set; }
		public DbSet<SheduleDay> SheduleDays { get; set; }
		public DbSet<SheduleTemplate> SheduleTemplates { get; set; }
		public DbSet<University> Universities { get; set; }

		public DbSet<SheduleLessonProfessor> ProfessorsOnLesson { get; private set; }
		public DbSet<SheduleLessonProfessor> SheduleLessonsInDay { get; private set; }

		public ApplicationDbContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EzLearnDb;User Id=postgres;Password=123456");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UniversityConfiguration());
			modelBuilder.ApplyConfiguration(new GroupConfiguration());
			modelBuilder.ApplyConfiguration(new SheduleTemplateConfiguration());
			modelBuilder.ApplyConfiguration(new SheduleLessonsInDayConfiguration());
			modelBuilder.ApplyConfiguration(new ProfessorOnSheduleLessonConfiguration());
			modelBuilder.ApplyConfiguration(new SheduleLessonConfiguration());

			SaveChanges();
			base.OnModelCreating(modelBuilder);
		}
	}
}

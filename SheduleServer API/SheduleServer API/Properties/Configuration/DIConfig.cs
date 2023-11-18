using SheduleServer.DAL.Data;
using SheduleServer.Service.Implementation;
using SheduleServer.Service.Interface;

namespace SheduleServer_API.Properties.Configuration
{
	public class DIConfig
	{
		public static void RegisterServeces(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>();

			services.AddScoped<IGroupService, GroupService>();
			services.AddScoped<ILessonService, LessonService>();
			services.AddScoped<ILessonTimeService, LessonTimeService>();
			services.AddScoped<IProfessorService, ProfessorService>();
			services.AddScoped<ISheduleDayService, SheduleDayService>();
			services.AddScoped<ISheduleLessonService, SheduleLessonService>();
			services.AddScoped<ISheduleTemplateService, SheduleTemplateService>();
			services.AddScoped<IUniversityService, UniversityService>();
		}
	}
}

using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.SheduleLesson;

namespace SheduleServer.Service.Interface
{
	public interface ISheduleLessonService
	{
		public Task<IBaseResponse<SheduleLesson>> CreateSheduleLessonAsync(SheduleLessonCreateModelDto model);

		public Task<IBaseResponse<SheduleLesson>> DeleteSheduleLessonAsync(SheduleLessonDeleteModelDto model);

		public Task<IBaseResponse<SheduleLesson>> UpdateSheduleLessonAsync(SheduleLessonUpdateModelDto model);

		public Task<IBaseResponse<SheduleLesson>> GetSheduleLessonById(int id);

		public Task<IBaseResponse<IEnumerable<SheduleLesson>>> GetAllSheduleLessonsAsync();
	}
}

using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.LessonTime;

namespace SheduleServer.Service.Interface
{
	public interface ILessonTimeService
	{

		public Task<IBaseResponse<LessonTime>> CreateLessonTimeAsync(LessonTimeCreateModelDto model);

		public Task<IBaseResponse<LessonTime>> DeleteLessonTimeAsync(LessonTimeDeleteModelDto model);

		public Task<IBaseResponse<LessonTime>> UpdateLessonTimeAsync(LessonTimeUpdateModelDto model);

		public Task<IBaseResponse<LessonTime>> GetLessonTimeById(int id);

		public Task<IBaseResponse<IEnumerable<LessonTime>>> GetAllLessonTimesAsync();
	}
}
﻿using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.Group;
using SheduleServer.Service.Dto.Lesson;

namespace SheduleServer.Service.Interface
{
	public interface ILessonService
	{
		public Task<IBaseResponse<Lesson>> CreateLessonAsync(LessonCreateModelDto model);

		public Task<IBaseResponse<Lesson>> DeleteLessonAsync(string id);

		public Task<IBaseResponse<Lesson>> UpdateLessonAsync(LessonUpdateModelDto model);

		public Task<IBaseResponse<Lesson>> GetLessonById(string id);

		public Task<IBaseResponse<IEnumerable<Lesson>>> GetAllLessonsAsync();
	}
}

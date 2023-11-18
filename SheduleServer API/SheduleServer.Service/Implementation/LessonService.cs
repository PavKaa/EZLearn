using Microsoft.EntityFrameworkCore;
using SheduleServer.DAL.Data;
using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.Lesson;
using SheduleServer.Service.Interface;


namespace SheduleServer.Service.Implementation
{
	public class LessonService : ILessonService
	{
		private readonly ApplicationDbContext context;

		public LessonService(ApplicationDbContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			this.context = context;
		}

		public async Task<IBaseResponse<Lesson>> CreateLessonAsync(LessonCreateModelDto model)
		{
			var response = new BaseResponse<Lesson>();

			try
			{ 
				var lesson = new Lesson
				{
					Title = model.Title
				};

				await context.Lessons.AddAsync(lesson);
				await context.SaveChangesAsync();

				response.StatusCode = 200;
				response.Data = lesson;
				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<Lesson>> DeleteLessonAsync(LessonDeleteModelDto model)
		{
			var response = new BaseResponse<Lesson>();

			try
			{
				var lesson = await context.Lessons.Where(l => l.Id == model.Id).FirstOrDefaultAsync();

				if (lesson == null)
				{
					response.Description = "Lesson with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				context.Lessons.Remove(lesson);
				await context.SaveChangesAsync();

				response.Description = "Lesson was successfully deleted";
				response.StatusCode = 200;
				response.Data = lesson;

				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<IEnumerable<Lesson>>> GetAllLessonsAsync()
		{
			var response = new BaseResponse<IEnumerable<Lesson>>();

			try
			{
				response.Data = await context.Lessons.ToListAsync();
				response.StatusCode = 200;

				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<Lesson>> GetLessonById(int id)
		{
			var response = new BaseResponse<Lesson>();

			try
			{
				var lesson = await context.Lessons.Where(l => l.Id == id).FirstOrDefaultAsync();

				if (lesson == null)
				{
					response.Description = "Lesson with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				response.Data = lesson;
				response.StatusCode = 200;

				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<Lesson>> UpdateLessonAsync(LessonUpdateModelDto model)
		{
			var response = new BaseResponse<Lesson>();

			try
			{
				var lesson = await context.Lessons.Where(u => u.Id == model.Id).FirstOrDefaultAsync();

				if (lesson == null)
				{
					response.Description = "Lesson with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				lesson.Title = model.Title;

				context.Lessons.Update(lesson);
				await context.SaveChangesAsync();

				response.Data = lesson;
				response.StatusCode = 200;

				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}
	}
}

using Microsoft.EntityFrameworkCore;
using SheduleServer.DAL.Data;
using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.SheduleLesson;
using SheduleServer.Service.Instruments;
using SheduleServer.Service.Interface;

namespace SheduleServer.Service.Implementation
{
	public class SheduleLessonService : ISheduleLessonService
	{
		private readonly ApplicationDbContext context;

		public SheduleLessonService(ApplicationDbContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			this.context = context;
		}

		public async Task<IBaseResponse<SheduleLesson>> CreateSheduleLessonAsync(SheduleLessonCreateModelDto model)
		{
			var response = new BaseResponse<SheduleLesson>();

			try
			{
				if(!Enum.TryParse<LessonType>(model.Type, out var lesonType))
				{
					response.Description = $"ErrorMessage: Invalid enum value";
					response.StatusCode = 500;
					return response;
				}

				var sheduleLesson = new SheduleLesson
				{
					Id = RandomIdGenerator.GenerateRandomId(),
					Type = lesonType,
					LessonId = model.LessonId,
					LessonTimeId = model.LessonTimeId
				};

				await context.SheduleLessons.AddAsync(sheduleLesson);
				await context.SaveChangesAsync();

				response.StatusCode = 200;
				response.Data = sheduleLesson;
				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<SheduleLesson>> DeleteSheduleLessonAsync(string id)
		{
			var response = new BaseResponse<SheduleLesson>();

			try
			{
				var sheduleLesson = await context.SheduleLessons.Where(sl => sl.Id == id).FirstOrDefaultAsync();

				if (sheduleLesson == null)
				{
					response.Description = "SheduleLesson with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				context.SheduleLessons.Remove(sheduleLesson);
				await context.SaveChangesAsync();

				response.Description = "SheduleLesson was successfully deleted";
				response.StatusCode = 200;
				response.Data = sheduleLesson;

				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<IEnumerable<SheduleLesson>>> GetAllSheduleLessonsAsync()
		{
			var response = new BaseResponse<IEnumerable<SheduleLesson>>();

			try
			{
				response.Data = await context.SheduleLessons.ToListAsync();
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

		public async Task<IBaseResponse<SheduleLesson>> GetSheduleLessonById(string id)
		{
			var response = new BaseResponse<SheduleLesson>();

			try
			{
				var sheduleLesson = await context.SheduleLessons.Where(sl => sl.Id == id).FirstOrDefaultAsync();

				if (sheduleLesson == null)
				{
					response.Description = "SheduleLesson with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				response.Data = sheduleLesson;
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

		public async Task<IBaseResponse<SheduleLesson>> UpdateSheduleLessonAsync(SheduleLessonUpdateModelDto model)
		{
			var response = new BaseResponse<SheduleLesson>();

			try
			{
				var sheduleLesson = await context.SheduleLessons.Where(sl => sl.Id == model.Id).FirstOrDefaultAsync();

				if (sheduleLesson == null)
				{
					response.Description = "SheduleLesson with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				sheduleLesson.Type = (LessonType)model.Type;

				context.SheduleLessons.Update(sheduleLesson);
				await context.SaveChangesAsync();

				response.Data = sheduleLesson;
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

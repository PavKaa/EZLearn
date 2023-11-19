using Microsoft.EntityFrameworkCore;
using SheduleServer.DAL.Data;
using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.LessonTime;
using SheduleServer.Service.Instruments;
using SheduleServer.Service.Interface;
using System.Globalization;

namespace SheduleServer.Service.Implementation
{
	public class LessonTimeService : ILessonTimeService
	{
		private readonly ApplicationDbContext context;

		public LessonTimeService(ApplicationDbContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			this.context = context;
		}

		public async Task<IBaseResponse<LessonTime>> CreateLessonTimeAsync(LessonTimeCreateModelDto model)
		{
			var response = new BaseResponse<LessonTime>();

			try
			{
				DateTime timeStart, timeEnd;

				if(!DateTime.TryParseExact(model.TimeStart, "HH:mm", CultureInfo.InvariantCulture, 
										  DateTimeStyles.None, out timeStart))
				{
					throw new ArgumentException("The start time of the lesson is incorrect.");
				}

				if (!DateTime.TryParseExact(model.TimeEnd, "HH:mm", CultureInfo.InvariantCulture,
										  DateTimeStyles.None, out timeEnd))
				{
					throw new ArgumentException("The end time of the lesson is incorrect.");
				}

				var lessonTime = new LessonTime
				{
					Id = RandomIdGenerator.GenerateRandomId(),
					Order = model.Order,
					TimeStart = timeStart,
					TimeEnd = timeEnd
				};

				await context.LessonTimes.AddAsync(lessonTime);
				await context.SaveChangesAsync();

				response.StatusCode = 200;
				response.Data = lessonTime;
				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<LessonTime>> DeleteLessonTimeAsync(string id)
		{
			var response = new BaseResponse<LessonTime>();

			try
			{
				var lessonTime = await context.LessonTimes.Where(l => l.Id == id).FirstOrDefaultAsync();

				if (lessonTime == null)
				{
					response.Description = "LessonTime with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				context.LessonTimes.Remove(lessonTime);
				await context.SaveChangesAsync();

				response.Description = "LessonTime was successfully deleted";
				response.StatusCode = 200;
				response.Data = lessonTime;

				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<IEnumerable<LessonTime>>> GetAllLessonTimesAsync()
		{
			var response = new BaseResponse<IEnumerable<LessonTime>>();

			try
			{
				response.Data = await context.LessonTimes.ToListAsync();
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

		public async Task<IBaseResponse<LessonTime>> GetLessonTimeById(string id)
		{
			var response = new BaseResponse<LessonTime>();

			try
			{
				var lessonTime = await context.LessonTimes.Where(l => l.Id == id).FirstOrDefaultAsync();

				if (lessonTime == null)
				{
					response.Description = "LessonTime with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				response.Data = lessonTime;
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

		public async Task<IBaseResponse<LessonTime>> UpdateLessonTimeAsync(LessonTimeUpdateModelDto model)
		{
			var response = new BaseResponse<LessonTime>();

			try
			{
				var lessonTime = await context.LessonTimes.Where(l => l.Id == model.Id).FirstOrDefaultAsync();

				if (lessonTime == null)
				{
					response.Description = "LessonTime with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				DateTime timeStart, timeEnd;

				if (!DateTime.TryParseExact(model.TimeStart, "HH:mm", CultureInfo.InvariantCulture, 
											DateTimeStyles.None, out timeStart))
				{
					throw new ArgumentException("The start time of the lesson is incorrect.");
				}	
				
				if (!DateTime.TryParseExact(model.TimeEnd, "HH:mm", CultureInfo.InvariantCulture, 
											DateTimeStyles.None, out timeEnd))
				{
					throw new ArgumentException("The end time of the lesson is incorrect.");
				}

				lessonTime.Order = model.Order;
				lessonTime.TimeStart = timeStart;
				lessonTime.TimeEnd = timeEnd;

				context.LessonTimes.Update(lessonTime);
				await context.SaveChangesAsync();

				response.Data = lessonTime;
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

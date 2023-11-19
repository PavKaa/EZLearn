using Microsoft.EntityFrameworkCore;
using SheduleServer.DAL.Data;
using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.SheduleDay;
using SheduleServer.Service.Instruments;
using SheduleServer.Service.Interface;

namespace SheduleServer.Service.Implementation
{
	public class SheduleDayService : ISheduleDayService
	{
		private readonly ApplicationDbContext context;

		public SheduleDayService(ApplicationDbContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			this.context = context;
		}

		public async Task<IBaseResponse<SheduleDay>> CreateSheduleDayAsync(SheduleDayCreateModelDto model)
		{
			var response = new BaseResponse<SheduleDay>();

			try
			{
				if(!Enum.TryParse<DayType>(model.DayType, out var dayType) ||
					!Enum.TryParse<Parity>(model.Parity, out var parityType))
				{
					response.Description = $"ErrorMessage: Invalid enum value";
					response.StatusCode = 500;
					return response;
				}

				var sheduleDay = new SheduleDay
				{
					Id = RandomIdGenerator.GenerateRandomId(),
					DayType = dayType,
					Parity = parityType,
					SheduleTemplateId = model.SheduleTemplateId
				};

				await context.SheduleDays.AddAsync(sheduleDay);
				await context.SaveChangesAsync();

				response.StatusCode = 200;
				response.Data = sheduleDay;
				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<SheduleDay>> DeleteSheduleDayAsync(string id)
		{
			var response = new BaseResponse<SheduleDay>();

			try
			{
				var sheduleDay = await context.SheduleDays.Where(s => s.Id == id).FirstOrDefaultAsync();

				if (sheduleDay == null)
				{
					response.Description = "SheduleDay with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				context.SheduleDays.Remove(sheduleDay);
				await context.SaveChangesAsync();

				response.Description = "SheduleDay was successfully deleted";
				response.StatusCode = 200;
				response.Data = sheduleDay;

				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<IEnumerable<SheduleDay>>> GetAllSheduleDaysAsync()
		{
			var response = new BaseResponse<IEnumerable<SheduleDay>>();

			try
			{
				response.Data = await context.SheduleDays.ToListAsync();
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

		public async Task<IBaseResponse<SheduleDay>> GetSheduleDayById(string id)
		{
			var response = new BaseResponse<SheduleDay>();

			try
			{
				var sheduleDay = await context.SheduleDays.Where(u => u.Id == id).FirstOrDefaultAsync();

				if (sheduleDay == null)
				{
					response.Description = "SheduleDay with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				response.Data = sheduleDay;
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

		public async Task<IBaseResponse<SheduleDay>> UpdateSheduleDayAsync(SheduleDayUpdateModelDto model)
		{
			var response = new BaseResponse<SheduleDay>();

			try
			{
				var sheduleDay = await context.SheduleDays.Where(u => u.Id == model.Id).FirstOrDefaultAsync();

				if (sheduleDay == null)
				{
					response.Description = "SheduleDay with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				if (!Enum.TryParse<Parity>(model.Parity, out var parityType))
				{
					response.Description = $"ErrorMessage: Invalid enum value";
					response.StatusCode = 500;
					return response;
				}

				sheduleDay.Parity = parityType;

				context.SheduleDays.Update(sheduleDay);
				await context.SaveChangesAsync();

				response.Data = sheduleDay;
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

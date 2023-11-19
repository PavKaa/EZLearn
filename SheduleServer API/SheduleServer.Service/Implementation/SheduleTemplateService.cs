using Microsoft.EntityFrameworkCore;
using SheduleServer.DAL.Data;
using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.SheduleTemplate;
using SheduleServer.Service.Instruments;
using SheduleServer.Service.Interface;

namespace SheduleServer.Service.Implementation
{
	public class SheduleTemplateService : ISheduleTemplateService
	{
		private readonly ApplicationDbContext context;

		public SheduleTemplateService(ApplicationDbContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			this.context = context;
		}

		public async Task<IBaseResponse<SheduleTemplate>> CreateSheduleTemplateAsync(SheduleTemplateCreateModelDto model)
		{
			var response = new BaseResponse<SheduleTemplate>();

			try
			{
				var sheduleTemplate = new SheduleTemplate
				{
					Id = RandomIdGenerator.GenerateRandomId(),
					Title = model.Title,
					GroupId = model.GroupId
				};

				await context.SheduleTemplates.AddAsync(sheduleTemplate);
				await context.SaveChangesAsync();

				response.StatusCode = 200;
				response.Data = sheduleTemplate;
				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<SheduleTemplate>> DeleteSheduleTemplateAsync(string id)
		{
			var response = new BaseResponse<SheduleTemplate>();

			try
			{
				var sheduleTemplate = await context.SheduleTemplates.Where(st => st.Id == id).FirstOrDefaultAsync();

				if (sheduleTemplate == null)
				{
					response.Description = "SheduleTemplate with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				context.SheduleTemplates.Remove(sheduleTemplate);
				await context.SaveChangesAsync();

				response.Description = "SheduleTemplate was successfully deleted";
				response.StatusCode = 200;
				response.Data = sheduleTemplate;

				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<IEnumerable<SheduleTemplate>>> GetAllSheduleTemplatesAsync()
		{
			var response = new BaseResponse<IEnumerable<SheduleTemplate>>();

			try
			{
				response.Data = await context.SheduleTemplates.ToListAsync();
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

		public async Task<IBaseResponse<SheduleTemplate>> GetSheduleTemplateById(string id)
		{
			var response = new BaseResponse<SheduleTemplate>();

			try
			{
				var sheduleTemplate = await context.SheduleTemplates.Where(u => u.Id == id).FirstOrDefaultAsync();

				if (sheduleTemplate == null)
				{
					response.Description = "SheduleTemplate with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				response.Data = sheduleTemplate;
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

		public async Task<IBaseResponse<SheduleTemplate>> UpdateSheduleTemplateAsync(SheduleTemplateUpdateModelDto model)
		{
			var response = new BaseResponse<SheduleTemplate>();

			try
			{
				var sheduleTemplate = await context.SheduleTemplates.Where(u => u.Id == model.Id).FirstOrDefaultAsync();

				if (sheduleTemplate == null)
				{
					response.Description = "SheduleTemplate with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				sheduleTemplate.Title = model.Title;

				context.SheduleTemplates.Update(sheduleTemplate);
				await context.SaveChangesAsync();

				response.Data = sheduleTemplate;
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

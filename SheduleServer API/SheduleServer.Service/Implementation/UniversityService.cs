using Microsoft.EntityFrameworkCore;
using SheduleServer.DAL.Data;
using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.University;
using SheduleServer.Service.Interface;

namespace SheduleServer.Service.Implementation
{
	public class UniversityService : IUniversityService
	{
		private readonly ApplicationDbContext context;

        public UniversityService(ApplicationDbContext context)
        {
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

            this.context = context;
        }
		
        public async Task<IBaseResponse<University>> CreateUniversityAsync(UniversityCreateModelDto model)
		{
			var response = new BaseResponse<University>();

			try
			{
				var university = await context.Universities.Where(u => u.Title == model.Title).FirstOrDefaultAsync();

				if(university != null) 
				{
					response.Description = "University with this title already exist in database";
					response.StatusCode = 409;

					return response;
				}

				university = new University
				{
					Title = model.Title
				};

				await context.Universities.AddAsync(university);
				await context.SaveChangesAsync();

				response.StatusCode = 200;
				response.Data = university;
				return response;
			}
			catch(Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<University>> DeleteUniversityAsync(UniversityDeleteModelDto model)
		{
			var response = new BaseResponse<University>();

			try
			{
				var university = await context.Universities.Where(u => u.Id == model.Id).FirstOrDefaultAsync();

				if (university == null)
				{
					response.Description = "University with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				context.Universities.Remove(university);
				await context.SaveChangesAsync();

				response.Description = "University was successfully deleted";
				response.StatusCode = 200;
				response.Data = university;

				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<IEnumerable<University>>> GetAllUniversitysAsync()
		{
			var response = new BaseResponse<IEnumerable<University>>();

			try
			{
				response.Data = await context.Universities.ToListAsync();
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

		public async Task<IBaseResponse<University>> GetUniversityById(int id)
		{
			var response = new BaseResponse<University>();

			try
			{
				var university = await context.Universities.Where(u => u.Id == id).FirstOrDefaultAsync();

				if (university == null)
				{
					response.Description = "University with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				response.Data = university;
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

		public async Task<IBaseResponse<University>> UpdateUniversityAsync(UniversityUpdateModelDto model)
		{
			var response = new BaseResponse<University>();

			try
			{
				var university = await context.Universities.Where(u => u.Id == model.Id).FirstOrDefaultAsync();

				if (university == null)
				{
					response.Description = "University with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				university.Title = model.Title;

				context.Universities.Update(university);
				await context.SaveChangesAsync();

				response.Data = university;
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

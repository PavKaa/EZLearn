using Microsoft.EntityFrameworkCore;
using SheduleServer.DAL.Data;
using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.Professor;
using SheduleServer.Service.Instruments;
using SheduleServer.Service.Interface;

namespace SheduleServer.Service.Implementation
{
	public class ProfessorService : IProfessorService
	{
		private readonly ApplicationDbContext context;

		public ProfessorService(ApplicationDbContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			this.context = context;
		}

		public async Task<IBaseResponse<Professor>> CreateProfessorAsync(ProfessorCreateModelDto model)
		{
			var response = new BaseResponse<Professor>();

			try
			{	
				var professor = new Professor
				{
					Id = RandomIdGenerator.GenerateRandomId(),
					LastName = model.LastName,
					FirstName = model.FirstName,
					MiddleName = model.MiddleName
				};

				await context.Professors.AddAsync(professor);
				await context.SaveChangesAsync();

				response.StatusCode = 200;
				response.Data = professor;
				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<Professor>> DeleteProfessorAsync(string id)
		{
			var response = new BaseResponse<Professor>();

			try
			{
				var professor = await context.Professors.Where(p => p.Id == id).FirstOrDefaultAsync();

				if (professor == null)
				{
					response.Description = "Professor with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				context.Professors.Remove(professor);
				await context.SaveChangesAsync();

				response.Description = "Professor was successfully deleted";
				response.StatusCode = 200;
				response.Data = professor;

				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<IEnumerable<Professor>>> GetAllProfessorsAsync()
		{
			var response = new BaseResponse<IEnumerable<Professor>>();

			try
			{
				response.Data = await context.Professors.ToListAsync();
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

		public async Task<IBaseResponse<Professor>> GetProfessorById(string id)
		{
			var response = new BaseResponse<Professor>();

			try
			{
				var professor = await context.Professors.Where(p => p.Id == id).FirstOrDefaultAsync();

				if (professor == null)
				{
					response.Description = "Professor with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				response.Data = professor;
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

		public async Task<IBaseResponse<Professor>> UpdateProfessorAsync(ProfessorUpdateModelDto model)
		{
			var response = new BaseResponse<Professor>();

			try
			{
				var professor = await context.Professors.Where(p => p.Id == model.Id).FirstOrDefaultAsync();

				if (professor == null)
				{
					response.Description = "Professor with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				string[] nameParts = model.FullName.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

				professor.LastName = nameParts[0];
				professor.FirstName = nameParts[1];
				professor.MiddleName = nameParts[2];

				context.Professors.Update(professor);
				await context.SaveChangesAsync();

				response.Data = professor;
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

using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.Professor;

namespace SheduleServer.Service.Interface
{
	public interface IProfessorService
	{
		public Task<IBaseResponse<Professor>> CreateProfessorAsync(ProfessorCreateModelDto model);

		public Task<IBaseResponse<Professor>> DeleteProfessorAsync(string id);

		public Task<IBaseResponse<Professor>> UpdateProfessorAsync(ProfessorUpdateModelDto model);

		public Task<IBaseResponse<Professor>> GetProfessorById(string id);

		public Task<IBaseResponse<IEnumerable<Professor>>> GetAllProfessorsAsync();
	}
}

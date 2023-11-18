using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.SheduleTemplate;

namespace SheduleServer.Service.Interface
{
	public interface ISheduleTemplateService
	{
		public Task<IBaseResponse<SheduleTemplate>> CreateSheduleTemplateAsync(SheduleTemplateCreateModelDto model);

		public Task<IBaseResponse<SheduleTemplate>> DeleteSheduleTemplateAsync(SheduleTemplateDeleteModelDto model);

		public Task<IBaseResponse<SheduleTemplate>> UpdateSheduleTemplateAsync(SheduleTemplateUpdateModelDto model);

		public Task<IBaseResponse<SheduleTemplate>> GetSheduleTemplateById(int id);

		public Task<IBaseResponse<IEnumerable<SheduleTemplate>>> GetAllSheduleTemplatesAsync();
	}
}
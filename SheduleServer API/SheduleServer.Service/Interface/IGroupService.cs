using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.Group;

namespace SheduleServer.Service.Interface
{
	public interface IGroupService
	{
		public Task<IBaseResponse<Group>> CreateGroupAsync(GroupCreateModelDto model);

		public Task<IBaseResponse<Group>> DeleteGroupAsync(GroupDeleteModelDto model);

		public Task<IBaseResponse<Group>> UpdateGroupAsync(GroupUpdateModelDto model);

		public Task<IBaseResponse<Group>> GetGroupById(int id);

		public Task<IBaseResponse<IEnumerable<Group>>> GetAllGroupsAsync();
	}
}

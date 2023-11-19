using Microsoft.EntityFrameworkCore;
using SheduleServer.DAL.Data;
using SheduleServer.Domain.Entity.Shedule;
using SheduleServer.Domain.Response;
using SheduleServer.Service.Dto.Group;
using SheduleServer.Service.Instruments;
using SheduleServer.Service.Interface;

namespace SheduleServer.Service.Implementation
{
	public class GroupService : IGroupService
	{
		private readonly ApplicationDbContext context;

		public GroupService(ApplicationDbContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			this.context = context;
		}

		public async Task<IBaseResponse<Group>> CreateGroupAsync(GroupCreateModelDto model)
		{
			var response = new BaseResponse<Group>();

			try
			{
				var group = new Group
				{
					Id = RandomIdGenerator.GenerateRandomId(),
					Number = model.Number,
					UniversityId = model.UniversityId
				};

				await context.Groups.AddAsync(group);
				await context.SaveChangesAsync();

				response.StatusCode = 200;
				response.Data = group;
				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<Group>> DeleteGroupAsync(string id)
		{
			var response = new BaseResponse<Group>();

			try
			{
				var group = await context.Groups.Where(g => g.Id == id).FirstOrDefaultAsync();

				if (group == null)
				{
					response.Description = "Group with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				context.Groups.Remove(group);
				await context.SaveChangesAsync();

				response.Description = "Group was successfully deleted";
				response.StatusCode = 200;
				response.Data = group;

				return response;
			}
			catch (Exception ex)
			{
				response.Description = $"ErrorMessage: {ex.Message}";
				response.StatusCode = 500;
				return response;
			}
		}

		public async Task<IBaseResponse<IEnumerable<Group>>> GetAllGroupsAsync()
		{
			var response = new BaseResponse<IEnumerable<Group>>();

			try
			{
				response.Data = await context.Groups.ToListAsync();
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

		public async Task<IBaseResponse<Group>> GetGroupById(string id)
		{
			var response = new BaseResponse<Group>();

			try
			{
				var group = await context.Groups.Where(u => u.Id == id).FirstOrDefaultAsync();

				if (group == null)
				{
					response.Description = "Group with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				response.Data = group;
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

		public async Task<IBaseResponse<Group>> UpdateGroupAsync(GroupUpdateModelDto model)
		{
			var response = new BaseResponse<Group>();

			try
			{
				var group = await context.Groups.Where(u => u.Id == model.Id).FirstOrDefaultAsync();

				if (group == null)
				{
					response.Description = "Group with this id doesn't exist in database";
					response.StatusCode = 500;

					return response;
				}

				group.Number = model.Number;

				context.Groups.Update(group);
				await context.SaveChangesAsync();

				response.Data = group;
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

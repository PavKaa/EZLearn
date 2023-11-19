using Microsoft.AspNetCore.Mvc;
using SheduleServer.Service.Dto.Group;
using SheduleServer.Service.Interface;
using SheduleServer_API.Models.Group;

namespace SheduleServer_API.Controllers
{
	public class GroupController : Controller
	{
		private readonly IGroupService service;

		public GroupController(IGroupService service)
		{
			this.service = service;
		}

		[HttpPost]
		public async Task<IActionResult> CreateGroupAsync([FromBody] GroupCreatingModel model)
		{
			if (ModelState.IsValid)
			{
				GroupCreateModelDto createModel = new GroupCreateModelDto()
				{
					Number = model.Number,
					UniversityId = model.UniversityId
				};

				var response = await service.CreateGroupAsync(createModel);

				if (response.StatusCode == 200)
				{
					return Json(response.Data);
				}
				else
				{
					return StatusCode(500, "Internal Server Error");
				}
			}

			return BadRequest();
		}

		[HttpGet]
		public async Task<IActionResult> GetGroupAsync(string id)
		{
			var response = await service.GetGroupById(id);

			if (response.StatusCode == 200)
			{
				return Json(response.Data);
			}
			else
			{
				return StatusCode(500, "Internal Server Error");
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetAllGroupsAsync()
		{
			var response = await service.GetAllGroupsAsync();

			if (response.StatusCode == 200)
			{
				return Json(response.Data);
			}
			else
			{
				return StatusCode(500, "Internal Server Error");
			}
		}

		[HttpPost]
		public async Task<IActionResult> DeleteGroupAsync(string id)
		{
			var response = await service.DeleteGroupAsync(id);

			if (response.StatusCode == 200)
			{
				return StatusCode(200, "Ok");
			}
			else
			{
				return StatusCode(500, "Internal Server Error");
			}
		}
	}
}

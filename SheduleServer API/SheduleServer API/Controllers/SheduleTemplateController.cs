using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleServer.Service.Dto.SheduleTemplate;
using SheduleServer.Service.Dto.University;
using SheduleServer.Service.Interface;
using SheduleServer_API.Models.SheduleTemplate;
using SheduleServer_API.Models.University;

namespace SheduleServer_API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SheduleTemplateController : Controller
	{
		private readonly ISheduleTemplateService service;

		public SheduleTemplateController(ISheduleTemplateService service)
		{
			this.service = service;
		}

		[HttpPost]
		public async Task<IActionResult> CreateSheduleTemplateAsync([FromBody]SheduleTemplateCreatingModel model)
		{
			if (ModelState.IsValid)
			{
				SheduleTemplateCreateModelDto createModel = new SheduleTemplateCreateModelDto()
				{
					GroupId = model.GroupId,
					Title = model.Title
				};

				var response = await service.CreateSheduleTemplateAsync(createModel);

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
		public async Task<IActionResult> GetSheduleTemplateAsync(string id)
		{
			var response = await service.GetSheduleTemplateById(id);

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
		public async Task<IActionResult> GetAllSheduleTemplatesAsync()
		{
			var response = await service.GetAllSheduleTemplatesAsync();

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
		public async Task<IActionResult> DeleteSheduleTemplateAsync(string id)
		{
			var response = await service.DeleteSheduleTemplateAsync(id);

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

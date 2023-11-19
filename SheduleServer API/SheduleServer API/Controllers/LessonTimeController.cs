using Microsoft.AspNetCore.Mvc;
using SheduleServer.Service.Dto.LessonTime;
using SheduleServer.Service.Interface;
using SheduleServer_API.Models.LessonTime;

namespace SheduleServer_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LessonTimeController : ControllerBase
	{
		private readonly ILessonTimeService service;

		public LessonTimeController(ILessonTimeService service)
		{
			this.service = service;
		}

		[HttpPost]
		public async Task<IActionResult> CreateLessonTimeAsync([FromBody] LessonTimeCreatingModel model)
		{
			if (ModelState.IsValid)
			{
				LessonTimeCreateModelDto createModel = new LessonTimeCreateModelDto()
				{
					Order = model.Order,
					TimeEnd = model.TimeEnd,
					TimeStart = model.TimeStart
				};

				var response = await service.CreateLessonTimeAsync(createModel);

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
		public async Task<IActionResult> GetLessonTimeAsync(string id)
		{
			var response = await service.GetLessonTimeById(id);

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
		public async Task<IActionResult> GetAllLessonTimesAsync()
		{
			var response = await service.GetAllLessonTimesAsync();

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
		public async Task<IActionResult> DeleteLessonTimeAsync(string id)
		{
			var response = await service.DeleteLessonTimeAsync(id);

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

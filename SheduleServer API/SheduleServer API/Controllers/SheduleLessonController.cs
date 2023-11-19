using Microsoft.AspNetCore.Mvc;
using SheduleServer.Service.Dto.SheduleLesson;
using SheduleServer.Service.Interface;
using SheduleServer_API.Models.SheduleLesson;

namespace SheduleServer_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SheduleLessonController : Controller
	{
		private readonly ISheduleLessonService service;

		public SheduleLessonController(ISheduleLessonService service)
		{
			this.service = service;
		}

		[HttpPost]
		public async Task<IActionResult> CreateSheduleLessonAsync([FromBody] SheduleLessonCreatingModel model)
		{
			if (ModelState.IsValid)
			{
				SheduleLessonCreateModelDto createModel = new SheduleLessonCreateModelDto()
				{
					Type = model.Type,
					LessonId = model.LessonId,
					LessonTimeId = model.LessonTimeId
				};

				var response = await service.CreateSheduleLessonAsync(createModel);

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
		public async Task<IActionResult> GetSheduleLessonAsync(string id)
		{
			var response = await service.GetSheduleLessonById(id);

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
		public async Task<IActionResult> GetAllSheduleLessonsAsync()
		{
			var response = await service.GetAllSheduleLessonsAsync();

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
		public async Task<IActionResult> DeleteSheduleLessonAsync(string id)
		{
			var response = await service.DeleteSheduleLessonAsync(id);

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

using Microsoft.AspNetCore.Mvc;
using SheduleServer.Service.Dto.Lesson;
using SheduleServer.Service.Interface;
using SheduleServer_API.Models.Lesson;

namespace SheduleServer_API.Controllers
{
	public class LessonController : Controller
	{
		private readonly ILessonService service;

		public LessonController(ILessonService service)
		{
			this.service = service;
		}

		[HttpPost]
		public async Task<IActionResult> CreateLessonAsync([FromBody] LessonCreatingModel model)
		{
			if (ModelState.IsValid)
			{
				LessonCreateModelDto createModel = new LessonCreateModelDto()
				{
					Title = model.Title
				};

				var response = await service.CreateLessonAsync(createModel);

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
		public async Task<IActionResult> GetLessonAsync(string id)
		{
			var response = await service.GetLessonById(id);

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
		public async Task<IActionResult> GetAllLessonsAsync()
		{
			var response = await service.GetAllLessonsAsync();

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
		public async Task<IActionResult> DeleteLessonAsync(string id)
		{
			var response = await service.DeleteLessonAsync(id);

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

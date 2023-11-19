using Microsoft.AspNetCore.Mvc;
using SheduleServer.Service.Dto.SheduleDay;
using SheduleServer.Service.Interface;
using SheduleServer_API.Models.SheduleDay;

namespace SheduleServer_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SheduleDayController : Controller
	{
		private readonly ISheduleDayService service;

		public SheduleDayController(ISheduleDayService service)
		{
			this.service = service;
		}

		[HttpPost]
		public async Task<IActionResult> CreateSheduleDayAsync([FromBody] SheduleDayCreatingModel model)
		{
			if (ModelState.IsValid)
			{
				SheduleDayCreateModelDto createModel = new SheduleDayCreateModelDto()
				{
					DayType = model.DayType,
					Parity = model.Parity,
					SheduleTemplateId = model.SheduleTemplateId
				};

				var response = await service.CreateSheduleDayAsync(createModel);

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
		public async Task<IActionResult> GetSheduleDayAsync(string id)
		{
			var response = await service.GetSheduleDayById(id);

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
		public async Task<IActionResult> GetAllSheduleDaysAsync()
		{
			var response = await service.GetAllSheduleDaysAsync();

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
		public async Task<IActionResult> DeleteSheduleDayAsync(string id)
		{
			var response = await service.DeleteSheduleDayAsync(id);

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

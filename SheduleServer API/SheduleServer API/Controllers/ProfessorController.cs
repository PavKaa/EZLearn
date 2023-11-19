using Microsoft.AspNetCore.Mvc;
using SheduleServer.Service.Dto.Professor;
using SheduleServer.Service.Interface;
using SheduleServer_API.Models.Professor;

namespace SheduleServer_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfessorController : Controller
	{
		private readonly IProfessorService service;

		public ProfessorController(IProfessorService service)
		{
			this.service = service;
		}

		[HttpPost]
		public async Task<IActionResult> CreateProfessorAsync([FromBody] ProfessorCreatingModel model)
		{
			if (ModelState.IsValid)
			{
				ProfessorCreateModelDto createModel = new ProfessorCreateModelDto()
				{
					FirstName = model.FirstName,
					LastName = model.LastName,
					MiddleName = model.MiddleName
				};

				var response = await service.CreateProfessorAsync(createModel);

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
		public async Task<IActionResult> GetProfessorAsync(string id)
		{
			var response = await service.GetProfessorById(id);

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
		public async Task<IActionResult> GetAllProfessorsAsync()
		{
			var response = await service.GetAllProfessorsAsync();

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
		public async Task<IActionResult> DeleteProfessorAsync(string id)
		{
			var response = await service.DeleteProfessorAsync(id);

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

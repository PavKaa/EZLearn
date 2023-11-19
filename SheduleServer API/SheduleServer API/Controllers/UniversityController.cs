using Microsoft.AspNetCore.Mvc;
using SheduleServer.Service.Dto.University;
using SheduleServer.Service.Interface;
using SheduleServer_API.Models.University;
using System.Text.Json;

namespace SheduleServer_API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UniversityController : Controller
	{
		private readonly IUniversityService service;

        public UniversityController(IUniversityService service)
        {
            this.service = service;
        }

		[HttpPost]
		public async Task<IActionResult> CreateUniversityAsync([FromBody]UniversityCreatingModel model)
		{
			if(ModelState.IsValid) 
			{
				UniversityCreateModelDto createModel = new UniversityCreateModelDto()
				{
					Title = model.Title,
				};

				var response = await service.CreateUniversityAsync(createModel);

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
		public async Task<IActionResult> GetUniversityAsync(string id)
		{
			var response = await service.GetUniversityById(id);

			if(response.StatusCode == 200)
			{
				return Json(response.Data);
			}
			else
			{
				return StatusCode(500, "Internal Server Error");
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetAllUniversitiesAsync()
		{
			var response = await service.GetAllUniversitiesAsync();

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
		public async Task<IActionResult> DeleteUniversityAsync(string id)
		{
			var response = await service.DeleteUniversityAsync(id);

			if(response.StatusCode == 200)
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

using Microsoft.AspNetCore.Mvc;
using SheduleServer.Service.Dto.University;
using SheduleServer.Service.Interface;

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

        public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateUniversityAsync([FromBody]UniversityCreateModelDto model)
		{
			if(ModelState.IsValid) 
			{
				var response = await service.CreateUniversityAsync(model);

                if (response.StatusCode == 200)
                {
					return Json(response.Data);
                }
            }

			return BadRequest();
			
		}
	}
}

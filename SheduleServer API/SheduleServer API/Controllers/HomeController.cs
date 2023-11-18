using Microsoft.AspNetCore.Mvc;

namespace SheduleServer_API.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

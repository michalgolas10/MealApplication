using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuWEB.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}
		public IActionResult Registration()
		{
			return View();
		}
	}
}

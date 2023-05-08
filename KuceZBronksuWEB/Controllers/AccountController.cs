using Microsoft.AspNetCore.Mvc;
using KuceZBronksuBLL.Services;

namespace KuceZBronksuWEB.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserService _userService;
		public AccountController(UserService userService)
		{
			_userService = userService;
		}
		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Registration()
		{
			return View();
		}
		public async Task<IActionResult> AdministratorPanel()
		{
			var users = await _userService.ShowAllUsers();
            return View(users);
		}
	}
}
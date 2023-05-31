using KuceZBronksuAPIBLL.Services.IServices;
using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KuceZBronksuAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LoggedUser : ControllerBase
	{
		private readonly MealAppContext _context;
		private readonly ILogger<LoggedUser> _logger;
        private readonly IReportManager _recipeManager;

        public LoggedUser(ILogger<LoggedUser> logger, MealAppContext context, IReportManager recipeManager)
		{
			_logger = logger;
			_context = context;
			_recipeManager= recipeManager;
		}

		[HttpGet(Name = "GetAllLastLoggedUsers")]
		public async Task<IActionResult> Get()
		{
			var allLastLogged = await _recipeManager.GetAllLoggedUsers();
			return Ok(allLastLogged);
		}

		[HttpPost(Name = "AddLastLoggedUser")]
		public async Task<ActionResult> AddAsync([FromBody] LastLoggedUsers lastLoggedReport)
		{
			await _context.AddAsync(lastLoggedReport);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}
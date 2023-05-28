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

		public LoggedUser(ILogger<LoggedUser> logger, MealAppContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet(Name = "GetAllLastLoggedUsers")]
		public async Task<IEnumerable<LastLoggedUsersReport>> Get()
		{
			var allLastLogged = await _context.LastLoggings.ToListAsync();
			return allLastLogged;
		}

		[HttpPost(Name = "AddLastLoggedUser")]
		public async Task AddAsync([FromBody] LastLoggedUsersReport lastLoggedReport)
		{
			await _context.AddAsync(lastLoggedReport);
			await _context.SaveChangesAsync();
		}
	}
}
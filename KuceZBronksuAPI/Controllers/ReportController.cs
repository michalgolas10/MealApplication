using KuceZBronksuDAL.Context;
using KuceZBronksuDAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KuceZBronksuAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ReportController : ControllerBase
	{
		private readonly MealAppContext _context;
		private readonly ILogger<ReportController> _logger;

		public ReportController(ILogger<ReportController> logger, MealAppContext context)
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
			var existingRow = await _context.LastLoggings
				.FirstOrDefaultAsync<LastLoggedUsersReport>(x => x.UserId == lastLoggedReport.UserId);

			if (existingRow != null)
			{
				_context.LastLoggings.Update(lastLoggedReport);
				await _context.SaveChangesAsync();
				return;
			}
			await _context.AddAsync(lastLoggedReport);
			await _context.SaveChangesAsync();
		}

		[HttpPut(Name = "UpdateLastLoggedUser")]
		public async Task UpdateAsync([FromBody] LastLoggedUsersReport lastLoggedReport)
		{
			_context.LastLoggings.Update(lastLoggedReport);
			await _context.SaveChangesAsync();
		}
	}
}

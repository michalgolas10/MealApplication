using KuceZBronksuBLL.Models;
using KuceZBronksuWebApi.BLL.Services.IServices;
using KuceZBronksuWebApi.Contracts;
using KuceZBronksuWebApi.DAL.Database;
using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuWebApi.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class RaportsController : ControllerBase
	{
		private readonly IRaportService _raportService;

		public RaportsController(IRaportService raportService)
		{
			_raportService = raportService;
		}


		[HttpPost]
		public IActionResult GenerateFavReport([FromBody] CreateFavRaportRequest request)
		{
			_raportService.CreateRaportOfFavs();

			return Ok();
		}
	}
}

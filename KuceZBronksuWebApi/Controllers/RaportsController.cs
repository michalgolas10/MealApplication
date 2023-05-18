using KuceZBronksuBLL.Models;
using KuceZBronksuWebApi.Models;
using KuceZBronksuWebApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuWebApi.Controllers
{
	public class RaportsController : ControllerBase
	{
		private readonly IRaportService _raportService;

		public RaportsController(IRaportService raportService)
		{
			_raportService = raportService;
		}

		[HttpGet]
		public async Task<ActionResult<Raport>> Get()
		{
			var raport = _raportService.CreateRaport();
			return Ok(raport);
		}
	}
}

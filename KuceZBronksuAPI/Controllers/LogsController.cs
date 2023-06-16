using KuceZBronksuAPIBLL.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly IReportManager _reportManager;

        public LogsController(IReportManager reportManager)
        {
            _reportManager = reportManager;
        }


        [HttpGet("~/download")]
        public async Task<IActionResult> DownloadReport()
        {
            string filePath = "Logs/WeeklyLogs.txt";

            await _reportManager.CreateWeeklyRaport(filePath);

            if (System.IO.File.Exists(filePath))
            {
                return File(await System.IO.File.ReadAllBytesAsync(filePath), "text/plain", Path.GetFileName(filePath));
            }
            return NotFound();
        }
    }
}

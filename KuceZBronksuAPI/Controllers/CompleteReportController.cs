using KuceZBronksuAPIBLL.Services.IServices;
using KuceZBronksuDAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace KuceZBronksuAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompleteReportController : ControllerBase
    {
        private readonly MealAppContext _context;
        private readonly ILogger<VisitedRecipeController> _logger;
        private readonly IReportManager _recipeManager;
        public CompleteReportController(MealAppContext context, ILogger<VisitedRecipeController> logger, IReportManager recipeManager)
        {
            _context = context;
            _recipeManager = recipeManager;
            _logger = logger;
        }
        [HttpGet(Name = "GetFullReport")]
        public async Task<IActionResult> Get()
        {
            var completeReport = await _recipeManager.CompleteReportCreate();
            return Ok(completeReport);
        }
    }
}

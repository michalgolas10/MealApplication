using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using Microsoft.Extensions.Logging;

namespace KuceZBronksuBLL.Services
{
	public class TimeService : ITimeService
	{
		private readonly IMailService _mailService;
		private readonly IGetReportService _getReportService;

        private readonly ILogger<ITimeService> _logger;

        public TimeService(IMailService mailService, IGetReportService getReportService, ILogger<ITimeService> logger)
		{
			_mailService = mailService;
			_getReportService = getReportService;
            _logger = logger;
		}

        public async Task SendEmailToAdmin()
        {
            try
            {
                var content = await _getReportService.GetCompleteReport();
                //var content = await _getReportService.GetCompleteReport();
                var mailData = new MailDataModel(
                    new List<string> { "janiya.price@ethereal.email" },
                    "Raport o aktywnosci uzytkownikow",
                    content,
                    null,
                    "Christian Schou",
                    null,
                    "Test mail"
                    );
                await _mailService.SendAsync(mailData, new CancellationToken());
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Problem inside TimeService");
            }
        }
    }
}
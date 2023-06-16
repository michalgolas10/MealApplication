using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;

namespace KuceZBronksuBLL.Services
{
	public class TimeService : ITimeService
	{
		private readonly IMailService _mailService;
		private readonly IGetReportService _getReportService;

		public TimeService(IMailService mailService, IGetReportService getReportService)
		{
			_mailService = mailService;
			_getReportService = getReportService;
		}

		public async Task SendEmailToAdmin()
		{
			var content = await _getReportService.GetCompleteReport();
            var mailData = new MailDataModel(
				new List<string> { "janiya.price@ethereal.email" },
				"Raport o aktywności użytkowników",
				content,
				null,
				"Twoja aplikacja webowa",
				null,
				"Test mail"
				);
			await _mailService.SendAsync(mailData, new CancellationToken());
		}
	}
}
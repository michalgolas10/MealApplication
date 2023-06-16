using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;

namespace KuceZBronksuBLL.Services
{
	public class TimeService : ITimeService
	{
		private readonly IMailService _mailService;

		public TimeService(IMailService mailService)
		{
			_mailService = mailService;
		}

		public async Task SendEmailToAdmin()
		{
			var mailData = new MailDataModel(
				new List<string> { "treta69@ethereal.email" },
				"Hello World",
				"Hola - this is just a test to verify that our mailing works. Have a great day!",
				null,
				"Christian Schou",
				null,
				"Test mail"
				);
			await _mailService.SendAsync(mailData, new CancellationToken());
		}
	}
}
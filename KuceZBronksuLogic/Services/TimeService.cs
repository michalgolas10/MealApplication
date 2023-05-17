using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				new List<string> { "janiya.price@ethereal.email" },
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

using KuceZBronksuBLL.Models;
using KuceZBronksuBLL.Services.IServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using KuceZBronksuBLL.ConfigurationMail;
using MimeKit;
using MailKit.Security;
using KuceZBronksuDAL.Models;
using Microsoft.Extensions.Logging;

namespace KuceZBronksuBLL.Services
{
	public class MailService : IMailService
	{
		private readonly MailSettings _settings;
		private readonly ILogger<MailSettings> _logger;
		public MailService(IOptions<MailSettings> settings, ILogger<MailSettings> logger)
		{
			_settings = settings.Value;
			_logger = logger;
		}

		public async Task<bool> SendAsync(MailDataModel mailData, CancellationToken ct = default)
		{
			try
			{
				// Initialize a new instance of the MimeKit.MimeMessage class
				var mail = new MimeMessage();

				#region Sender / Receiver
				// Sender
				mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
				mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);

				// Receiver
				foreach (string mailAddress in mailData.To)
					mail.To.Add(MailboxAddress.Parse(mailAddress));

				// Set Reply to if specified in mail data
				if (!string.IsNullOrEmpty(mailData.ReplyTo))
					mail.ReplyTo.Add(new MailboxAddress(mailData.ReplyToName, mailData.ReplyTo));

				// BCC
				// Check if a BCC was supplied in the request
				if (mailData.Bcc != null)
				{
					// Get only addresses where value is not null or with whitespace. x = value of address
					foreach (string mailAddress in mailData.Bcc.Where(x => !string.IsNullOrWhiteSpace(x)))
						mail.Bcc.Add(MailboxAddress.Parse(mailAddress.Trim()));
				}

				// CC
				// Check if a CC address was supplied in the request
				if (mailData.Cc != null)
				{
					foreach (string mailAddress in mailData.Cc.Where(x => !string.IsNullOrWhiteSpace(x)))
						mail.Cc.Add(MailboxAddress.Parse(mailAddress.Trim()));
				}
				#endregion

				#region Content

				// Add Content to Mime Message
				var body = new BodyBuilder();
				mail.Subject = mailData.Subject;
				body.HtmlBody = mailData.Body;
				mail.Body = body.ToMessageBody();

				#endregion

				#region Send Mail

				using var smtp = new MailKit.Net.Smtp.SmtpClient();

				if (_settings.UseSSL)
				{
					await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect, ct);
				}
				else if (_settings.UseStartTls)
				{
					await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, ct);
				}
				await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, ct);
				await smtp.SendAsync(mail, ct);
				await smtp.DisconnectAsync(true, ct);

				#endregion
				_logger.LogInformation("Email succefully sended");
				return true;

			}
			catch (Exception)
			{
				_logger.LogError("Problem with email send");
				return false;
			}
		}
	}
}

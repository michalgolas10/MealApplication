using KuceZBronksuBLL.Models;

namespace KuceZBronksuBLL.Services.IServices
{
	public interface IMailService
	{
		Task<bool> SendAsync(MailDataModel mailData, CancellationToken ct);
	}
}
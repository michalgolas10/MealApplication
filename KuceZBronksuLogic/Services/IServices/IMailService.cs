using KuceZBronksuBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Services.IServices
{
	public interface IMailService
	{
		Task<bool> SendAsync(MailDataModel mailData, CancellationToken ct);
	}
}

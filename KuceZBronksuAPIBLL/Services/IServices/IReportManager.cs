using KuceZBronksuAPIBLL.Models;
using KuceZBronksuDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuAPIBLL.Services.IServices
{
	public interface IReportManager
	{
		Task<string> GetReport();
	}
}

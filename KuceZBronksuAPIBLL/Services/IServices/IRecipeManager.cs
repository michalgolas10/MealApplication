using KuceZBronksuAPIBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuAPIBLL.Services.IServices
{
	public interface IRecipeManager
	{
		Task<IEnumerable<VisitedRecipeBO>> GetAll();
	}
}

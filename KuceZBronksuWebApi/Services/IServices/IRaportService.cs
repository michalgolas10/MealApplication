using KuceZBronksuWebApi.Models;

namespace KuceZBronksuWebApi.Services.IServices
{
	public interface IRaportService
	{
		public Task<Raport> CreateRaport();
	}
}

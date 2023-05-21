using KuceZBronksuWebApi.Contracts;

namespace KuceZBronksuWebApi.BLL.Services.IServices
{
	public interface IRecipeAnalysisService
	{
		public Task<CreateDateForAnalysisRequest> GetAll();
	}
}

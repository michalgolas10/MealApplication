using KuceZBronksuWebApi.DAL.Database;

namespace KuceZBronksuWebApi.BLL.Services.IServices
{
    public interface IRaportService
    {
        public Task<Raport> CreateRaportOfFavs();
        public Task<Raport> CreateRaportOfViews();
        public Task<Raport> CreateRaportOfLogs();
        public Task<Raport> CreateRaportOfErrors();
    }
}

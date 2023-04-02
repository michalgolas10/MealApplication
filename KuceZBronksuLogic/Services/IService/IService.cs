namespace KuceZBronksuBLL.Services.IService
{
    public interface IService<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetValue(string id);

        void AddNew(T t);

        void Delete(T t);
    }
}
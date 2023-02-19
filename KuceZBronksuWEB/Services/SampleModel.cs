using KuceZBronksuWEB.Models;

namespace KuceZBronksuWEB.Services
{
    public class SampleModel
    {
        private static List<TestModel> _models =
            new List<TestModel>
            {
                new TestModel()
                {
                    Info = "test",
                    Id = 1,
                },
                new TestModel()
                {
                    Info = "Nie wiem jak to działa",
                    Id = 2,
                },
                new TestModel()
                {
                    Info = "Ale działa",
                    Id = 3,
                }
            };
        public List<TestModel> GetAll() 
        { 
            return _models; 
        }
    }
}
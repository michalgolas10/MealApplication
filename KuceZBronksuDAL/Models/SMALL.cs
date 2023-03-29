using KuceZBronksuDAL.Models.BaseEntity;

namespace KuceZBronksuDAL
{
    public class SMALL : Entity
    {
        public string Url { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
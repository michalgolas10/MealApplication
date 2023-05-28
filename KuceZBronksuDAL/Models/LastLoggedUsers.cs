using KuceZBronksuDAL.Models.BaseEntity;

namespace KuceZBronksuDAL.Models
{
	public class LastLoggedUsers : Entity
	{
		public int UserId { get; set; }
		public DateTime LastLogged { get; set; }
	}
}
using KuceZBronksuDAL.Models.BaseEntity;

namespace KuceZBronksuDAL.Models
{
	public class LastLoggedUsersReport : Entity
	{
		public int UserId { get; set; }
		public DateTime LastLogged { get; set; }
	}
}
namespace KuceZBronksuBLL.Models
{
	public class LastLoggedUsersReportDto
	{
		public int UserId { get; set; }
		public DateTime LastLogged { get; set; }
		public int LoginCount { get; set; }
	}
}
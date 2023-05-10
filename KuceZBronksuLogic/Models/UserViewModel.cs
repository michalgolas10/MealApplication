namespace KuceZBronksuBLL.Models
{
	public class UserViewModel
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public List<string> Roles { get; set; }
		public bool EmailConfirmed { get; set; }
	}
}
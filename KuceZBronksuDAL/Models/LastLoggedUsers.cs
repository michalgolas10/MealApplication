using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuDAL.Models
{
	public class LastLoggedUsers
	{
		public int UserId { get; set; }
		public DateTime LastLogged { get; set; }
		public int LoginCount { get; set; }
	}
}

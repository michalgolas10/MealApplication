using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuceZBronksuBLL.Models
{
	public class AdminViewModel
	{
        public AdminViewModel()
        {
            TimeOfCyclicalEmailing = 1;
        }
        [DisplayName("How Often you want to e-mail with raport In Days")]
		[Required]
        public int TimeOfCyclicalEmailing { get ; set; }
	}
}

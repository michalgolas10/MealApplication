using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace KuceZBronksuDAL.Models.BaseEntity
{
	public class Entity
	{
		[JsonIgnore]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int? Id { get; set; }

		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }
	}
}
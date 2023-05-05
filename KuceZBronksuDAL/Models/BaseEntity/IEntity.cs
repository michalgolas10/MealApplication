using System.ComponentModel.DataAnnotations.Schema;

namespace KuceZBronksuDAL.Models.BaseEntity
{
	public interface IEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int? Id { get; set; }
	}
}
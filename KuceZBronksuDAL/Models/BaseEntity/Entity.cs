using System.ComponentModel.DataAnnotations.Schema;

namespace KuceZBronksuDAL.Models.BaseEntity
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? Id { get; set; }
    }
}
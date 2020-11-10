using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCinema.Entities
{
    public interface IEntityBaseString
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        string ID { get; set; }
    }
}

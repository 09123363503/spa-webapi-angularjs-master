using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCinema.Entities
{
    public interface IEntityBaseInteger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        int ID { get; set; }
    }
}

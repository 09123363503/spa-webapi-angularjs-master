using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public interface IEntityBaseInteger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        int ID { get; set; }
    }
}

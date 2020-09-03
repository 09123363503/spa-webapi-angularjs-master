using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public interface IEntityBase
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[MaxLength(16)]
        int ID { get; set; }
    }
}

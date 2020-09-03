using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class IEntityBaseString
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        string ID { get; set; }
    }
}

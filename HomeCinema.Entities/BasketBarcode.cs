using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class BasketBarcode : IEntityBaseInteger
    {
        public int ID { get; set; }
        [DefaultValue(0)]
        public int Parent { get; set; }
        [DefaultValue(0)]
        public int Child { get; set; }
    }
}

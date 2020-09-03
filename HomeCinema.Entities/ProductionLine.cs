using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class ProductionLine : IEntityBaseInteger
    {
        public ProductionLine()
        {
            ProductionOrders = new List<ProductionOrder>();
        }
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }

        public virtual ICollection<ProductionOrder> ProductionOrders { get; set; }
    }
}

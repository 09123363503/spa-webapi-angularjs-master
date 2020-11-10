using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

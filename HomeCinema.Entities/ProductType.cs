using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeCinema.Entities
{
    public class ProductType : IEntityBaseInteger
    {
        public ProductType()
        {
            ProductionOrders = new List<ProductionOrder>();
        }
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductionOrder> ProductionOrders { get; set; }
    }
}

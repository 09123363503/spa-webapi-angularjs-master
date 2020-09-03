using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

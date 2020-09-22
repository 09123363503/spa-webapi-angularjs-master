using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class ProductionOrderConfiguration : EntityBaseConfigurationInt<ProductionOrder>
    {
        public ProductionOrderConfiguration()
        {
            Property(p => p.Number).IsRequired();
            Property(p => p.Date).IsRequired();
            HasMany(p => p.Lots).WithRequired().HasForeignKey(s => s.ProductionOrderID);
            HasMany(p => p.ProductionOrderItems).WithRequired().HasForeignKey(s => s.ProductionOrederID);
        }
    }
}

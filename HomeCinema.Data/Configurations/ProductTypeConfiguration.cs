using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class ProductTypeConfiguration : EntityBaseConfiguration<ProductType>
    {
        public ProductTypeConfiguration()
        {
            Property(p => p.Code).IsRequired();
            Property(p => p.Name).IsRequired();
            HasMany(p => p.ProductionOrders).WithRequired().HasForeignKey(s => s.ProductTypeID);
        }
    }
}

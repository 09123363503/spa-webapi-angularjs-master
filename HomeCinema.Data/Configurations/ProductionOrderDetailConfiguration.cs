using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class ProductionOrderDetailConfiguration : EntityBaseConfiguration<ProductionOrderDetail>
    {
        public ProductionOrderDetailConfiguration()
        {
            Property(p => p.ProductionOrederID).IsRequired();
            Property(p => p.ArticleID).IsRequired();
        }
    }
}

using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class ArticleConfiguration : EntityBaseConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            Property(p => p.MainArticleID).IsRequired();
            Property(p => p.PurchaseAccID).IsRequired();
            Property(p => p.SaleAccID).IsRequired();
            Property(p => p.InventoryAccID).IsRequired();
            Property(p => p.Code).IsRequired();
            Property(p => p.Name).IsRequired();
            Property(p => p.RegisterID);
            Property(p => p.EditionID);
            Property(p => p.DeleteID);
            Property(p => p.RegisterDateTime);
            Property(p => p.EditionDateTime);
            Property(p => p.DeleteDateTime);
            HasMany(p => p.ArticleItems).WithRequired().HasForeignKey(s => s.ArticleID);
            HasMany(p => p.ProductionOrderDetails).WithRequired().HasForeignKey(s => s.ArticleID);
        }
    }
}

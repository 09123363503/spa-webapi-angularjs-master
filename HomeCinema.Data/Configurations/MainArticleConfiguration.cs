using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class MainArticleConfiguration : EntityBaseConfiguration<MainArticle>
    {
        public MainArticleConfiguration()
        {
            Property(p => p.Code).IsRequired().IsMaxLength();
            Property(p => p.Name).IsRequired().IsMaxLength();
            Property(p => p.Unit1ID).IsRequired();
            Property(p => p.Unit2ID).IsRequired();
            Property(p => p.Unit3ID).IsRequired();
            Property(p => p.PurchaseAccID);
            Property(p => p.SalesAccID);
            Property(p => p.InventoryAccID).IsRequired();
            Property(p => p.RegisterID);
            Property(p => p.EditionID);
            Property(p => p.DeleteID);
            Property(p => p.RegisterDateTime);
            Property(p => p.EditionDateTime);
            Property(p => p.DeleteDateTime);
            HasMany(p => p.Articles).WithRequired().HasForeignKey(s => s.MainArticleID);
            HasMany(p => p.MainArticleComponents).WithRequired().HasForeignKey(s => s.MainAricleID);
        }
    }
}

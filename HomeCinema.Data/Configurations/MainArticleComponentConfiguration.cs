using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class MainArticleComponentConfiguration : EntityBaseConfiguration<MainArticleComponent>
    {
        public MainArticleComponentConfiguration()
        {
            Property(p => p.Position).IsRequired();
            Property(p => p.Name).IsRequired().IsMaxLength();
            Property(p => p.ComponentID).IsRequired();
            HasMany(p => p.ArticleItems).WithRequired().HasForeignKey(s => s.MainArticleComponentID);
        }
    }
}

using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class ComponentConfiguration : EntityBaseConfiguration<Component>
    {
        public ComponentConfiguration()
        {
            Property(p => p.Code).IsRequired().IsMaxLength();
            Property(p => p.Name).IsRequired().IsMaxLength();
            Property(p => p.Lenght).IsRequired();
            HasMany(p => p.ComponentItems).WithRequired().HasForeignKey(s => s.ComponentID);
            HasMany(p => p.MainArticleComponents).WithRequired().HasForeignKey(s => s.ComponentID);
        }
    }
}

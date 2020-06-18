using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class UnitConfiguration : EntityBaseConfiguration<Unit>
    {
        public UnitConfiguration()
        {
            Property(p => p.Code).IsRequired().IsMaxLength();
            Property(p => p.Name).IsRequired().IsMaxLength();
            Property(p => p.RegisterID);
            Property(p => p.EditionID);
            Property(p => p.DeleteID);
            Property(p => p.RegisterDatetime);
            Property(p => p.EditionDateTime);
            Property(p => p.DeleteDateTime);
            HasMany(p => p.MainArticles).WithRequired().HasForeignKey(s => s.Unit1ID);
            HasMany(p => p.MainArticles).WithRequired().HasForeignKey(s => s.Unit2ID);
            HasMany(p => p.MainArticles).WithRequired().HasForeignKey(s => s.Unit3ID);
        }
    }
}

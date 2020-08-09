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
            Property(p => p.EditID);
            Property(p => p.DeleteID);
            Property(p => p.RegisterDatetime);
            Property(p => p.EditDateTime);
            Property(p => p.DeleteDateTime);
            HasMany(p => p.MainArticles).WithRequired().HasForeignKey(s => s.Unit1ID);
            HasMany(p => p.MainArticles).WithRequired().HasForeignKey(s => s.Unit2ID);
            HasMany(p => p.MainArticles).WithRequired().HasForeignKey(s => s.Unit3ID);
            HasMany(p => p.Barcodes).WithRequired().HasForeignKey(s => s.UnitID1);
            HasMany(p => p.Barcodes).WithRequired().HasForeignKey(s => s.UnitID2);
            HasMany(p => p.Barcodes).WithRequired().HasForeignKey(s => s.UnitID3);
            HasMany(p => p.ProductionOrderDetails).WithRequired().HasForeignKey(s => s.UnitID1);
            HasMany(p => p.ProductionOrderDetails).WithRequired().HasForeignKey(s => s.UnitID2);
            HasMany(p => p.ProductionOrderDetails).WithRequired().HasForeignKey(s => s.UnitID3);
            HasMany(p => p.Cargos).WithRequired().HasForeignKey(s => s.SumUnitID1);
            HasMany(p => p.Cargos).WithRequired().HasForeignKey(s => s.SumunitID2);
        }
    }
}

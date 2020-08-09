using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class WareHouseConfiguration : EntityBaseConfiguration<Warehouse>
    {
        public WareHouseConfiguration()
        {
            Property(p => p.Code).IsRequired();
            Property(p => p.Name).IsRequired();
            Property(p => p.WHKeeperID).IsRequired();
            HasMany(p => p.Warehouses).WithRequired().HasForeignKey(s => s.ID);
            HasMany(p => p.Locations).WithRequired().HasForeignKey(s => s.WarehouseID);
        }
    }
}

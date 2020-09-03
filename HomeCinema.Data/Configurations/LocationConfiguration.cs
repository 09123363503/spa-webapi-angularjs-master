using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class LocationConfiguration : EntityBaseConfiguration<Location>
    {
        public LocationConfiguration()
        {
            Property(p => p.WarehouseID).IsRequired();
            Property(p => p.Name).IsRequired();
            HasMany(p => p.Cargos).WithRequired().HasForeignKey(s => s.LocationID);
        }
    }
}

using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class CargoConfiguration : EntityBaseConfiguration<Cargo>
    {
        public CargoConfiguration()
        {
            Property(p => p.Date).IsRequired();
            Property(p => p.Number).IsRequired();
            Property(p => p.WHKeeperID).IsRequired();
            HasMany(p => p.CargoDetails).WithRequired().HasForeignKey(s => s.CargoID);
        }
    }
}

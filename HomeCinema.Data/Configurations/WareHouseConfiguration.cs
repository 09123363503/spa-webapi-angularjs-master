using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class WarehouseConfiguration : EntityBaseConfigurationInt<Warehouse>
    {
        public WarehouseConfiguration()
        {
            Property(p => p.Code).IsRequired();
            Property(p => p.Name).IsRequired();
            HasMany(p => p.Locations).WithRequired().HasForeignKey(s => s.WarehouseID);
        }
    }
}

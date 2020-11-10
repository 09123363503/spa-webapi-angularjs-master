using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class LocationConfiguration : EntityBaseConfigurationInt<Location>
    {
        public LocationConfiguration()
        {
            Property(p => p.WarehouseID).IsRequired();
            Property(p => p.Name).IsRequired();
            HasMany(p => p.Cargos).WithRequired().HasForeignKey(s => s.LocationID);
        }
    }
}

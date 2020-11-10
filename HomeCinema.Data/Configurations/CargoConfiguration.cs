using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class CargoConfiguration : EntityBaseConfigurationString<Cargo>
    {
        public CargoConfiguration()
        {
            Property(p => p.BarcodeID).IsRequired();
        }
    }
}

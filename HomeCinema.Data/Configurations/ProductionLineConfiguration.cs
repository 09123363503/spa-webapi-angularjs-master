using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class ProductionLineConfiguration : EntityBaseConfigurationInt<ProductionLine>
    {
        public ProductionLineConfiguration()
        {
            HasMany(p => p.ProductionOrders).WithRequired().HasForeignKey(s => s.ProductionLineID);
        }
    }
}

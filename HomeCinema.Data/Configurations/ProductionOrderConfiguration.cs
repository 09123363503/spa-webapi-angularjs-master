using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class ProductionOrderConfiguration : EntityBaseConfigurationInt<ProductionOrder>
    {
        public ProductionOrderConfiguration()
        {
            Property(p => p.Number).IsRequired();
            Property(p => p.Date).IsRequired();
            HasMany(p => p.Lots).WithRequired().HasForeignKey(s => s.ProductionOrderID);
            HasMany(p => p.ProductionOrderItems).WithRequired().HasForeignKey(s => s.ProductionOrederID);
        }
    }
}

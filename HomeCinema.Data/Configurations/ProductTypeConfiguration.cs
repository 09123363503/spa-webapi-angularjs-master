using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class ProductTypeConfiguration : EntityBaseConfigurationInt<ProductType>
    {
        public ProductTypeConfiguration()
        {
            Property(p => p.Code).IsRequired();
            Property(p => p.Name).IsRequired();
            HasMany(p => p.ProductionOrders).WithRequired().HasForeignKey(s => s.ProductTypeID);
        }
    }
}

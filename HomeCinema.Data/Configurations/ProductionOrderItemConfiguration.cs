using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class ProductionOrderItemConfiguration : EntityBaseConfigurationInt<ProductionOrderItem>
    {
        public ProductionOrderItemConfiguration()
        {
            Property(p => p.ProductionOrederID).IsRequired();
            Property(p => p.ArticleID).IsRequired();
        }
    }
}

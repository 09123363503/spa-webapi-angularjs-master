using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class ComponentItemConfiguration : EntityBaseConfigurationInt<ComponentItem>
    {
        public ComponentItemConfiguration()
        {
            Property(p => p.ComponentID).IsRequired();
            Property(p => p.Code).IsRequired().IsMaxLength();
            Property(p => p.Name).IsRequired().IsMaxLength();
            HasMany(p => p.ArticleItems).WithRequired().HasForeignKey(s => s.ComponentItemID);
        }
    }
}

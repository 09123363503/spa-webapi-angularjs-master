using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class ComponentConfiguration : EntityBaseConfigurationInt<Component>
    {
        public ComponentConfiguration()
        {
            Property(p => p.Code).IsRequired().IsMaxLength();
            Property(p => p.Name).IsRequired().IsMaxLength();
            Property(p => p.Lenght).IsRequired();
            HasMany(p => p.ComponentItems).WithRequired().HasForeignKey(s => s.ComponentID);
            HasMany(p => p.MainArticleComponents).WithRequired().HasForeignKey(s => s.ComponentID);
        }
    }
}

using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class MainArticleComponentConfiguration : EntityBaseConfigurationInt<MainArticleComponent>
    {
        public MainArticleComponentConfiguration()
        {
            Property(p => p.Position).IsRequired();
            Property(p => p.Name).IsRequired().IsMaxLength();
            Property(p => p.ComponentID).IsRequired();
            HasMany(p => p.ArticleItems).WithRequired().HasForeignKey(s => s.MainArticleComponentID);
        }
    }
}

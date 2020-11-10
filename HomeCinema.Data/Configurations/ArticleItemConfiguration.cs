using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class ArticleItemConfiguration : EntityBaseConfigurationInt<ArticleItem>
    {
        public ArticleItemConfiguration()
        {
            Property(p => p.ArticleID).IsRequired();
            Property(p => p.ComponentItemID).IsRequired();
        }
    }
}

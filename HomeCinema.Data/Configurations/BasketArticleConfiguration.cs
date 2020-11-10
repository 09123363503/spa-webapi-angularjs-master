using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class BasketArticleConfiguration : EntityBaseConfigurationInt<BasketArticle>
    {
        public BasketArticleConfiguration()
        {
            Property(p => p.Parent).IsRequired();
            Property(p => p.Child).IsRequired();
        }
    }
}

using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class LotConfiguration : EntityBaseConfigurationInt<Lot>
    {
        public LotConfiguration()
        {
            Property(p => p.ArticleID).IsRequired();
        }
    }
}

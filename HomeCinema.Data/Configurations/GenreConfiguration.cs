using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class GenreConfiguration : EntityBaseConfigurationInt<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Name).IsRequired().HasMaxLength(50);
        }
    }
}

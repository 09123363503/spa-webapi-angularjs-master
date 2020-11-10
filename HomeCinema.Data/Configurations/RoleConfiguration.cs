using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class RoleConfiguration : EntityBaseConfigurationInt<Role>
    {
        public RoleConfiguration()
        {
            Property(ur => ur.Name).IsRequired().HasMaxLength(50);
        }
    }
}

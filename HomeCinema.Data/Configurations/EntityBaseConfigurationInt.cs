using HomeCinema.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HomeCinema.Data.Configurations
{
    public class EntityBaseConfigurationInt<T> : EntityTypeConfiguration<T> where T : class, IEntityBaseInteger//, IEntityBaseInteger
    {
        public EntityBaseConfigurationInt()
        {
            HasKey(e => e.ID);
        }
    }
}

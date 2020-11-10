using HomeCinema.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HomeCinema.Data.Configurations
{
    public class EntityBaseConfigurationString<T> : EntityTypeConfiguration<T> where T : class, IEntityBaseString//, IEntityBaseString
    {
        public EntityBaseConfigurationString()
        {
            HasKey(f => f.ID);
        }
    }
}

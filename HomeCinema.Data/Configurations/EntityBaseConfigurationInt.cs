using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

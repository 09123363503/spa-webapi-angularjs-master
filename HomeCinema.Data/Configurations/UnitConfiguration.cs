using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class UnitConfiguration : EntityBaseConfigurationInt<Unit>
    {
        public UnitConfiguration()
        {
            Property(p => p.Code).IsRequired().IsMaxLength();
            Property(p => p.Name).IsRequired().IsMaxLength();
            Property(p => p.CreateUserID);
            Property(p => p.ModifyUserID);
            Property(p => p.DeleteUserID);
            Property(p => p.CreateOn);
            Property(p => p.ModifyOn);
            Property(p => p.DeleteOn);
        }
    }
}

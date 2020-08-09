using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class AccountConfiguration : EntityBaseConfiguration<Account>
    {
        public AccountConfiguration()
        {
            Property(p => p.Code).IsRequired();
            Property(p => p.Name).IsRequired();
            HasMany(p => p.Lots).WithRequired().HasForeignKey(s => s.AccountID);
        }
    }
}

using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class MyCompanyConfiguration : EntityBaseConfigurationInt<MyCompany>
    {
        public MyCompanyConfiguration()
        {
            Property(p => p.CompanyName).IsRequired();
            HasMany(p => p.Invoices).WithRequired().HasForeignKey(s => s.MyCompanyID);
        }
    }
}

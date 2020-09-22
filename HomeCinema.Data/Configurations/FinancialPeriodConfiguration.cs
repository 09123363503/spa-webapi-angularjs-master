using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class FinancialPeriodConfiguration : EntityBaseConfigurationInt<FinancialPeriod>
    {
        public FinancialPeriodConfiguration()
        {
            Property(p => p.Number).IsRequired();
            Property(p => p.Name).IsRequired();
            Property(p => p.StartDate).IsRequired();
            Property(p => p.EndDate).IsRequired();
            HasMany(p => p.ProductionOrders).WithRequired().HasForeignKey(s => s.FinancialPeriodID);
        }
    }
}

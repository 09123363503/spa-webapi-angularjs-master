using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    class BaseInvoiceTypeConfiguration : EntityBaseConfigurationInt<BaseInvoiceType>
    {
        public BaseInvoiceTypeConfiguration()
        {
            Property(p => p.Code).IsRequired();
            Property(p => p.Name).IsRequired();
            HasMany(p => p.InvoiceTypes).WithRequired().HasForeignKey(s => s.BaseInvoiceTypeID);
        }
    }
}

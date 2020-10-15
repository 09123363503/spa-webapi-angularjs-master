using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class InvoiceTypeConfiguration : EntityBaseConfigurationInt<InvoiceType>
    {
        public InvoiceTypeConfiguration()
        {
            Property(p => p.BaseInvoiceTypeID).IsRequired();
            Property(p => p.Code).IsRequired();
            Property(p => p.Name).IsRequired();
            HasMany(p => p.Invoices).WithRequired().HasForeignKey(s => s.InvoiceTypeID);
        }
    }
}

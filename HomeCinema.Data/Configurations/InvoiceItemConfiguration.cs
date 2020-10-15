using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class InvoiceItemConfiguration : EntityBaseConfigurationString<InvoiceItem>
    {
        public InvoiceItemConfiguration()
        {
            Property(p => p.InvoiceID).IsRequired();
            Property(p => p.UnitPrice).IsRequired();
            HasMany(p => p.Cargos).WithRequired().HasForeignKey(s => s.InvoiceItemID);
        }
    }
}

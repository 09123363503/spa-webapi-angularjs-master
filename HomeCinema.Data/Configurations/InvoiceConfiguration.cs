﻿using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class InvoiceConfiguration : EntityBaseConfigurationString<Invoice>
    {
        public InvoiceConfiguration()
        {
            Property(p => p.AccountID).IsRequired();
            Property(p => p.InvoiceTypeID).IsRequired();
            Property(p => p.CompanyID).IsRequired();
            Property(p => p.Date).IsRequired();
            Property(p => p.Number).IsRequired();
            HasMany(p => p.InvoiceItems).WithRequired().HasForeignKey(p => p.InvoiceID);
        }
    }
}

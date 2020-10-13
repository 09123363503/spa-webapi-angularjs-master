﻿using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class InvoiceConfiguration : EntityBaseConfigurationString<Invoice>
    {
        public InvoiceConfiguration()
        {
            Property(p => p.AccountID).IsRequired();
            Property(p => p.InvoiceTypeID).IsRequired();
            Property(p => p.MyCompanyID).IsRequired();
            Property(p => p.Date).IsRequired();
            Property(p => p.Number).IsRequired();
        }
    }
}

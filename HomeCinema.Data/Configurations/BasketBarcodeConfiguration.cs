using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class BasketBarcodeConfiguration : EntityBaseConfigurationInt<BasketBatcode>
    {
        public BasketBarcodeConfiguration()
        {
            Property(p => p.Parent).IsRequired();
            Property(p => p.Child).IsRequired();
        }
    }
}

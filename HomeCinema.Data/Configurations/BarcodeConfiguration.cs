using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Configurations
{
    public class BarcodeConfiguration : EntityBaseConfiguration<Barcode>
    {
        public BarcodeConfiguration()
        {
            Property(p => p.BarcodeString).IsRequired().IsMaxLength();
            Property(p => p.ArticleID).IsRequired();
            HasMany(p => p.CargoDetails).WithRequired().HasForeignKey(s => s.BarcodeID);
        }
    }
}

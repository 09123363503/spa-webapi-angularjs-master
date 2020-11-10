using HomeCinema.Entities;

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

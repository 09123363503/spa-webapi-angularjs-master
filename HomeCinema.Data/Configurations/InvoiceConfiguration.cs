using HomeCinema.Entities;

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
            HasMany(p => p.InvoiceItems).WithRequired(p => p.Invoice).HasForeignKey(p => p.InvoiceID);
        }
    }
}

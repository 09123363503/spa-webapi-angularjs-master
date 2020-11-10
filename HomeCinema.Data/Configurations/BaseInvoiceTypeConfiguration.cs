using HomeCinema.Entities;

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

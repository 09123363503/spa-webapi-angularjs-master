using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class CompanyConfiguration : EntityBaseConfigurationInt<Company>
    {
        public CompanyConfiguration()
        {
            Property(p => p.CompanyName).IsRequired();
            HasMany(p => p.Invoices).WithRequired().HasForeignKey(s => s.CompanyID);
        }
    }
}

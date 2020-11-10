using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class MyCompanyConfiguration : EntityBaseConfigurationInt<MyCompany>
    {
        public MyCompanyConfiguration()
        {
            Property(p => p.CompanyName).IsRequired();
            HasMany(p => p.Invoices).WithRequired().HasForeignKey(s => s.MyCompanyID);
        }
    }
}

using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class AccountConfiguration : EntityBaseConfigurationInt<Account>
    {
        public AccountConfiguration()
        {
            Property(p => p.Code).IsRequired();
            Property(p => p.Name).IsRequired();
            HasMany(p => p.Lots).WithRequired().HasForeignKey(s => s.AccountID);
            HasMany(p => p.Invoices).WithRequired().HasForeignKey(s => s.AccountID);
        }
    }
}

using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class PeriodConfiguration : EntityBaseConfigurationInt<Period>
    {
        public PeriodConfiguration()
        {
            Property(p => p.Number).IsRequired();
            Property(p => p.Name).IsRequired();
            Property(p => p.StartDate).IsRequired();
            Property(p => p.EndDate).IsRequired();
            HasMany(p => p.ProductionOrders).WithRequired().HasForeignKey(s => s.PeriodID);
        }
    }
}

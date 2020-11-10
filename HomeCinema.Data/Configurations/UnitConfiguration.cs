using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class UnitConfiguration : EntityBaseConfigurationInt<Unit>
    {
        public UnitConfiguration()
        {
            Property(p => p.Code).IsRequired().IsMaxLength();
            Property(p => p.Name).IsRequired().IsMaxLength();
            Property(p => p.CreateUserID);
            Property(p => p.ModifyUserID);
            Property(p => p.DeleteUserID);
            Property(p => p.CreateOn);
            Property(p => p.ModifyOn);
            Property(p => p.DeleteOn);
        }
    }
}

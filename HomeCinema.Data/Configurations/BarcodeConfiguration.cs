using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class BarcodeConfiguration : EntityBaseConfigurationInt<Barcode>
    {
        public BarcodeConfiguration()
        {
            Property(p => p.BarcodeString).IsRequired().IsMaxLength();
            Property(p => p.ArticleID).IsRequired();
            HasMany(p => p.Cargos).WithRequired().HasForeignKey(s => s.BarcodeID);
        }
    }
}

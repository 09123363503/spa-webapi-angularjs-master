using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class BasketBarcodeConfiguration : EntityBaseConfigurationInt<BasketBarcode>
    {
        public BasketBarcodeConfiguration()
        {
            Property(p => p.Parent).IsRequired();
            Property(p => p.Child).IsRequired();
        }
    }
}

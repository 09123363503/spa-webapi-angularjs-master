using System.ComponentModel;

namespace HomeCinema.Entities
{
    public class BasketBarcode : IEntityBaseInteger
    {
        public int ID { get; set; }
        [DefaultValue(0)]
        public int Parent { get; set; }
        [DefaultValue(0)]
        public int Child { get; set; }
    }
}

using System.ComponentModel;

namespace HomeCinema.Entities
{
    public class ProductionOrderItem : IEntityBaseInteger
    {
        public int ID { get; set; }
        public int ProductionOrederID { get; set; }
        public int ArticleID { get; set; }
        [DefaultValue(0)]
        public int UnitID1 { get; set; }
        [DefaultValue(0)]
        public int UnitID2 { get; set; }
        [DefaultValue(0)]
        public int UnitID3 { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue1 { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue2 { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue3 { get; set; }
    }
}

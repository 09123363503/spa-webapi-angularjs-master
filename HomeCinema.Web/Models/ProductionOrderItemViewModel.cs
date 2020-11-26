namespace HomeCinema.Web.Models
{
    public class ProductionOrderItemViewModel
    {
        public int ID { get; set; }
        public int ProductionOrederID { get; set; }
        public int ArticleID { get; set; }
        public decimal UnitValue1 { get; set; }
        public decimal UnitValue2 { get; set; }
        public decimal UnitValue3 { get; set; }
    }
}
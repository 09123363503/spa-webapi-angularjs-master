using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class ProductionOrderDetailViewModel
    {
        public int ID { get; set; }
        public int ProductionOrederID { get; set; }
        public int ArticleID { get; set; }
        public int UnitID1 { get; set; }
        public int UnitID2 { get; set; }
        public int UnitID3 { get; set; }
        public decimal UnitValue1 { get; set; }
        public decimal UnitValue2 { get; set; }
        public decimal UnitValue3 { get; set; }
    }
}
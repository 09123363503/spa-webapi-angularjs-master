using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class LotViewModel
    {
        public int ID { get; set; }
        public int ArticleID { get; set; }
        public int AccountID { get; set; }
        public string ProducerLot { get; set; }
        public int ProductionOrderID { get; set; }
        public int OwnerID { get; set; }
        public int Grade { get; set; }
        public int RegisterID { get; set; }
        public Int64 RegisterDateTime { get; set; }
        public int EditID { get; set; }
        public Int64 EditDateTime { get; set; }
        public int DeleteID { get; set; }
        public Int64 DeleteDatetime { get; set; }
    }
}
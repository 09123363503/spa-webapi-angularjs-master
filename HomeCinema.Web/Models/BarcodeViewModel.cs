using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class BarcodeViewModel
    {
        public int ID { get; set; }
        public string BarcodeString { get; set; }
        public int ArticleID { get; set; }
        public int Grade { get; set; }
        public int UnitID1 { get; set; }
        public decimal UnitValue1 { get; set; }
        public int UnitID2 { get; set; }
        public decimal UnitValue2 { get; set; }
        public int UnitID3 { get; set; }
        public decimal UnitValue3 { get; set; }
        public int Count { get; set; }
        public int RegisterID { get; set; }
        public Int64 RegisterDateTime { get; set; }
        public int EditID { get; set; }
        public Int64 EditDateTime { get; set; }
        public int DeleteID { get; set; }
        public Int64 DeleteDateTime { get; set; }
    }
}
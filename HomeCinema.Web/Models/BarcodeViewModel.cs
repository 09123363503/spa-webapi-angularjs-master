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
        public int CreateUserID { get; set; }
        public Int64 CreateOn { get; set; }
        public int ModifyUserID { get; set; }
        public Int64 ModifyOn { get; set; }
        public int DeleteUserID { get; set; }
        public Int64 DeleteOn { get; set; }
    }
}
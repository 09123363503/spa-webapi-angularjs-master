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
        public int CreateUserID { get; set; }
        public Int64 CreateOn { get; set; }
        public int ModifyUserID { get; set; }
        public Int64 ModifyOn { get; set; }
        public int DeleteUserID { get; set; }
        public Int64 DeleteOn { get; set; }
    }
}
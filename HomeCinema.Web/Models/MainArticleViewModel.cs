using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class MainArticleViewModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ViewName { get; set; }
        public int Unit1 { get; set; }
        public int Unit2 { get; set; }
        public int Unit3 { get; set; }
        public int PurchaseAccID { get; set; }
        public int SalesAccID { get; set; }
        public int InventoryAccID { get; set; }
        public int CreateUserID { get; set; }
        public int ModifyUserID { get; set; }
        public int DeleteUserID { get; set; }
        public Int64 CreateOn { get; set; }
        public Int64 ModifyOn { get; set; }
        public Int64 DeleteOn { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class CargoDetailViewModel
    {
        public int ID { get; set; }
        public int CargoID { get; set; }
        public int BarcodeID { get; set; }
        public int Count { get; set; }
        public int LocationID { get; set; }
        public int CreateUserID { get; set; }
        public Int64 CreateOn { get; set; }
        public int ModifyUserID { get; set; }
        public Int64 ModifyOn { get; set; }
        public int DeleteUserID { get; set; }
        public Int64 DeleteOn { get; set; }
    }
}
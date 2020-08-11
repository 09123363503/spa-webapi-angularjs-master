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
        public int RegisterID { get; set; }
        public Int64 RegisterDateTime { get; set; }
        public int EditID { get; set; }
        public Int64 EditDateTime { get; set; }
        public int DeleteID { get; set; }
        public Int64 DeleteDateTime { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class CargoViewModel
    {
        public int ID { get; set; }
        public int Date { get; set; }
        public int Number { get; set; }
        public bool Input { get; set; }
        public bool Output { get; set; }
        public bool Prodution { get; set; }
        public int WHKeeperID { get; set; }
        public int SumCount { get; set; }
        public int SumUnitID1 { get; set; }
        public decimal SumUnitValue1 { get; set; }
        public int SumunitID2 { get; set; }
        public decimal SumUnitValue2 { get; set; }
        public int RegisterID { get; set; }
        public Int64 RegisterDateTime { get; set; }
        public int EditID { get; set; }
        public Int64 EditDateTime { get; set; }
        public int DeleteID { get; set; }
        public Int64 DeleteDateTime { get; set; }
    }
}
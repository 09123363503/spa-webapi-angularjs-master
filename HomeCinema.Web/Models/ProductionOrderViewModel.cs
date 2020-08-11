using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class ProductionOrderViewModel
    {
        public int ID { get; set; }
        public int ProductionLineID { get; set; }
        public int FinancialPeriodID { get; set; }
        public int Number { get; set; }
        public int Date { get; set; }
        public int ProductTypeID { get; set; }
        public string Description { get; set; }
        public Int64 StartDateTime { get; set; }
        public Int64 FinishDateTime { get; set; }
        public int State { get; set; }
        public int ConfirmID { get; set; }
        public Int64 DeliveryDateTime { get; set; }
        public int RegisterID { get; set; }
        public Int64 RegisterDateTime { get; set; }
        public int EditID { get; set; }
        public Int64 EditDateTime { get; set; }
        public int DeleteID { get; set; }
        public Int64 DeleteDateTime { get; set; }
    }
}
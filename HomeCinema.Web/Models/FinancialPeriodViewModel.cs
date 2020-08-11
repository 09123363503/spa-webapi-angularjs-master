using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class FinancialPeriodViewModel
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public bool FinanciaPeriodTransfered { get; set; }
        public bool TemporaryClose { get; set; }
        public bool PermanentClose { get; set; }
    }
}
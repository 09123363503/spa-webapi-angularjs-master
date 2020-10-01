using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class BasketBarcodeViewModel
    {
        public int ID { get; set; }
        public int Parent { get; set; }
        public int Child { get; set; }
    }
}
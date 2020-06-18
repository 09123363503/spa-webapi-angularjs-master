﻿using System;
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
        public float Unit1 { get; set; }
        public float Unit2 { get; set; }
        public float Unit3 { get; set; }
        public int PurchaseAccID { get; set; }
        public int SalesAccID { get; set; }
        public int InventoryAccID { get; set; }
        public int RegisterID { get; set; }
        public int EditionID { get; set; }
        public int DeleteID { get; set; }
        public Int64 RegisterDateTime { get; set; }
        public Int64 EditionDateTime { get; set; }
        public Int64 DeleteDateTime { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class ComponentViewModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Lengtht { get; set; }
        public int RegisterID { get; set; }
        public int EditionID { get; set; }
        public int DeleteID { get; set; }
        public Int64 RegisterDateTime { get; set; }
        public Int64 EditionDateTime { get; set; }
        public Int64 DeleteDateTime { get; set; }
    }
}
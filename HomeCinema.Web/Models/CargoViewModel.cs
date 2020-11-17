﻿using System;

namespace HomeCinema.Web.Models
{
    public class CargoViewModel
    {
        public string ID { get; set; }
        public int BarcodeID { get; set; }
        public int Count { get; set; }
        public int LocationID { get; set; }
        public decimal UnitValue1 { get; set; }
        public decimal UnitValue2 { get; set; }
        public int CreateUserID { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public int ModifyUserID { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        public int DeleteUserID { get; set; }
        public DateTimeOffset DeleteOn { get; set; }
    }
}
﻿using System;

namespace HomeCinema.Web.Models
{
    public class BarcodeViewModel
    {
        public int ID { get; set; }
        public string BarcodeString { get; set; }
        public int ArticleID { get; set; }
        public int Grade { get; set; }
        public decimal UnitValue1 { get; set; }
        public decimal UnitValue2 { get; set; }
        public decimal UnitValue3 { get; set; }
        public int Count { get; set; }
        public int CreateUserID { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public int ModifyUserID { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        public int DeleteUserID { get; set; }
        public DateTimeOffset DeleteOn { get; set; }
    }
}
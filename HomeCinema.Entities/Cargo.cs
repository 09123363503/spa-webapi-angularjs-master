using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeCinema.Entities
{
    public class Cargo : IEntityBaseString
    {
        public string ID { get; set; }
        [Required]
        public int BarcodeID { get; set; }
        [Required]
        [DefaultValue(0)]
        public string InvoiceItemID { get; set; }
        [DefaultValue(1)]
        public int Count { get; set; }
        [DefaultValue(0)]
        public int LocationID { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue1 { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue2 { get; set; }
        [DefaultValue(0)]
        public int CreateUserID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset CreateOn { get; set; }
        [DefaultValue(0)]
        public int ModifyUserID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset ModifyOn { get; set; }
        [DefaultValue(0)]
        public int DeleteUserID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset DeleteOn { get; set; }
    }
}

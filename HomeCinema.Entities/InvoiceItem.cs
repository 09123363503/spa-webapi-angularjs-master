using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeCinema.Entities
{
    public class InvoiceItem : IEntityBaseString
    {
        public InvoiceItem()
        {
            Cargos = new List<Cargo>();
        }
        public string ID { get; set; }
        [Required]
        public string InvoiceID { get; set; }
        [ForeignKey("InvoiceID")]
        public virtual Invoice Invoice { get; set; }
        [Required]
        public int Count { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue1 { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue2 { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue3 { get; set; }
        [DefaultValue(1)]
        public int UnitPriceBaseUnit { get; set; }
        [DefaultValue(0)]
        public decimal UnitPrice { get; set; }
        public string UsanceDate { get; set; }
        public string SaleMethod { get; set; }
        [DefaultValue(0)]
        public int CreateUserID { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        [DefaultValue(0)]
        public int ModifyUserID { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        [DefaultValue(0)]
        public int DeleteUserID { get; set; }
        public DateTimeOffset DeleteOn { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; }

    }
}

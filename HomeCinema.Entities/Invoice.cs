using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeCinema.Entities
{
    public class Invoice : IEntityBaseString
    {
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
        }
        public string ID { get; set; }
        [Required]
        public int AccountID { get; set; }
        [Required]
        public int InvoiceTypeID { get; set; }
        [Required]
        public int CompanyID { get; set; }
        [DefaultValue(0)]
        public int WarehouseID { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        [Required]
        public int Number { get; set; }
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
        public int UsanceDate { get; set; }
        [DefaultValue(0)]
        public int CreateUserID { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        [DefaultValue(0)]
        public int ModifyUserID { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        [DefaultValue(0)]
        public int DeleteUserID { get; set; }
        public DateTimeOffset DeleteOn { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeCinema.Entities
{
    public class InvoiceType : IEntityBaseInteger
    {
        public InvoiceType()
        {
            Invoices = new List<Invoice>();
        }
        public int ID { get; set; }
        [Required]
        public int BaseInvoiceTypeID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}

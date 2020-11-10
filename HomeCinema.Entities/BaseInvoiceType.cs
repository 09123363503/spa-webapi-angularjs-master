using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeCinema.Entities
{
    public class BaseInvoiceType : IEntityBaseInteger
    {
        public BaseInvoiceType()
        {
            InvoiceTypes = new List<InvoiceType>();
        }
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<InvoiceType> InvoiceTypes { get; set; }
    }
}

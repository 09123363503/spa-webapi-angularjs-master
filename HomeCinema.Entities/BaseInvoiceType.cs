using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

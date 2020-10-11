using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class InvoiceType : IEntityBaseInteger
    {
        public int ID { get; set; }
        [Required]
        public int BaseInvoiceTypeID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}

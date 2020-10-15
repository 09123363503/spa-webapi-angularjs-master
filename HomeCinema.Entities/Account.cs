using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class Account : IEntityBaseInteger
    {
        public Account()
        {
            Lots = new List<Lot>();
            Invoices = new List<Invoice>();
        }
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}

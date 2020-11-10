using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

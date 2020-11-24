using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeCinema.Entities
{
    public class Company : IEntityBaseInteger
    {
        public Company()
        {
            Invoices = new List<Invoice>();
        }
        public int ID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string EconomicCode { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string Slogan { get; set; }
        public string Warning { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}

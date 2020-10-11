using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class MyCompany : IEntityBaseInteger
    {
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
    }
}

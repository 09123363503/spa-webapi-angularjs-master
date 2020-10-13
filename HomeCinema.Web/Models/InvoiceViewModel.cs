using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class InvoiceViewModel
    {
        public string ID { get; set; }
        public int AccountID { get; set; }
        public int InvoiceTypeID { get; set; }
        public int MyCompanyID { get; set; }
        public DateTimeOffset Date { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int CreateUserID { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public int ModifyUserID { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        public int DeleteUserID { get; set; }
        public DateTimeOffset DeleteOn { get; set; }
    }
}
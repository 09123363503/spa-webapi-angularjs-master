namespace HomeCinema.Web.Models
{
    public class InvoiceTypeViewModel
    {
        public int ID { get; set; }
        public int BaseInvoiceTypeID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
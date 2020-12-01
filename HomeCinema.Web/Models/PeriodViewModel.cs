namespace HomeCinema.Web.Models
{
    public class PeriodViewModel
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public bool PeriodTransfered { get; set; }
        public bool TemporaryClose { get; set; }
        public bool PermanentClose { get; set; }
    }
}
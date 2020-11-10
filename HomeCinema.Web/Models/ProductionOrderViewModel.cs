using System;

namespace HomeCinema.Web.Models
{
    public class ProductionOrderViewModel
    {
        public int ID { get; set; }
        public int ProductionLineID { get; set; }
        public int FinancialPeriodID { get; set; }
        public int Number { get; set; }
        public int Date { get; set; }
        public int ProductTypeID { get; set; }
        public string Description { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset FinishDateTime { get; set; }
        public int State { get; set; }
        public int ConfirmID { get; set; }
        public DateTimeOffset DeliveryDateTime { get; set; }
        public int CreateUserID { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public int ModifyUserID { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        public int DeleteUserID { get; set; }
        public DateTimeOffset DeleteOn { get; set; }
    }
}
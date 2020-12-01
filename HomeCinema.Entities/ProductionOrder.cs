using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeCinema.Entities
{
    public class ProductionOrder : IEntityBaseInteger
    {
        public ProductionOrder()
        {
            Lots = new List<Lot>();
            ProductionOrderItems = new List<ProductionOrderItem>();
        }
        public int ID { get; set; }
        [DefaultValue(0)]
        public int ProductionLineID { get; set; }
        public int PeriodID { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Date { get; set; }
        [DefaultValue(0)]
        public int ProductTypeID { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTimeOffset StartDateTime { get; set; }
        [Required]
        public DateTimeOffset FinishDateTime { get; set; }
        [DefaultValue(1)]
        public int State { get; set; }
        [DefaultValue(0)]
        public int ConfirmID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset DeliveryDateTime { get; set; }
        [DefaultValue(0)]
        public int CreateUserID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset CreateOn { get; set; }
        [DefaultValue(0)]
        public int ModifyUserID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset ModifyOn { get; set; }
        [DefaultValue(0)]
        public int DeleteUserID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset DeleteOn { get; set; }

        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<ProductionOrderItem> ProductionOrderItems { get; set; }
    }
}
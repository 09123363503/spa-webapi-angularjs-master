using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class ProductionOrder : IEntityBase
    {
        public ProductionOrder()
        {
            Lots = new List<Lot>();
            ProductionOrderDetails = new List<ProductionOrderDetail>();
        }
        public int ID { get; set; }
        [DefaultValue(0)]
        public int ProductionLineID { get; set; }
        public int FinancialPeriodID { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Date { get; set; }
        [DefaultValue(0)]
        public int ProductTypeID { get; set; }
        public string Description { get; set; }
        [Required]
        public Int64 StartDateTime { get; set; }
        [Required]
        public Int64 FinishDateTime { get; set; }
        [DefaultValue(1)]
        public int State { get; set; }
        [DefaultValue(0)]
        public int ConfirmID { get; set; }
        [DefaultValue(0)]
        public Int64 DeliveryDateTime { get; set; }
        [DefaultValue(0)]
        public int CreateUserID { get; set; }
        [DefaultValue(0)]
        public Int64 CreateOn { get; set; }
        [DefaultValue(0)]
        public int ModifyUserID { get; set; }
        [DefaultValue(0)]
        public Int64 ModifyOn { get; set; }
        [DefaultValue(0)]
        public int DeleteUserID { get; set; }
        [DefaultValue(0)]
        public Int64 DeleteOn { get; set; }

        public virtual ICollection<Lot> Lots { get; set; }
        public virtual ICollection<ProductionOrderDetail> ProductionOrderDetails { get; set; }
    }
}
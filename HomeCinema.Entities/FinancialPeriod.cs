using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeCinema.Entities
{
    public class FinancialPeriod : IEntityBaseInteger
    {
        public FinancialPeriod()
        {
            ProductionOrders = new List<ProductionOrder>();
        }
        public int ID { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int StartDate { get; set; }
        [Required]
        public int EndDate { get; set; }
        [DefaultValue(0)]
        public bool FinanciaPeriodTransfered { get; set; }
        [DefaultValue(0)]
        public bool TemporaryClose { get; set; }
        [DefaultValue(0)]
        public bool PermanentClose { get; set; }

        public virtual ICollection<ProductionOrder> ProductionOrders { get; set; }
    }
}

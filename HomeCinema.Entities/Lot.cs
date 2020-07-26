using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class Lot : IEntityBase
    {
        public int ID { get; set; }
        [DefaultValue(0)]
        public int ArticleID { get; set; }
        public string ProducerLot { get; set; }
        [DefaultValue(0)]
        public int ProductionOrderID { get; set; }
        [DefaultValue(0)]
        public int OwnerID { get; set; }
        [DefaultValue(1)]
        public int Grade { get; set; }
        [DefaultValue(0)]
        public int RegisterID { get; set; }
        [DefaultValue(0)]
        public Int64 RegisterDateTime { get; set; }
        [DefaultValue(0)]
        public int EditID { get; set; }
        [DefaultValue(0)]
        public Int64 EditDateTime { get; set; }
        [DefaultValue(0)]
        public int DeleteID { get; set; }
        [DefaultValue(0)]
        public Int64 DeleteDatetime { get; set; }
    }
}

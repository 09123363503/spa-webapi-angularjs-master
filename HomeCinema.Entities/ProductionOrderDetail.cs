using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class ProductionOrderDetail : IEntityBase
    {
        public int ID { get; set; }
        public int ProductionOrederID { get; set; }
        public int ArticleID { get; set; }
        [DefaultValue(0)]
        public int UnitID1 { get; set; }
        [DefaultValue(0)]
        public int UnitID2 { get; set; }
        [DefaultValue(0)]
        public int UnitID3 { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue1 { get; set; }
        [DefaultValue(0)]
        public decimal UnitVlue2 { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue3 { get; set; }
    }
}

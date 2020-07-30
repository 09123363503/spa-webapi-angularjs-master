using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    class Cargo : IEntityBase
    {
        public int ID { get; set; }
        [Required]
        public int Date { get; set; }
        [Required]
        public int Number { get; set; }
        public bool Input { get; set; }
        public bool Output { get; set; }
        public bool Prodution { get; set; }
        [Required]
        public int WHKeeper { get; set; }
        [DefaultValue(1)]
        public int SumCount { get; set; }
        [DefaultValue(0)]
        public int SumUnitID1 { get; set; }
        [DefaultValue(0)]
        public decimal SumUnitValue1 { get; set; }
        [DefaultValue(0)]
        public int SumunitID2 { get; set; }
        [DefaultValue(0)]
        public decimal SumUnitValue2 { get; set; }
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
        public Int64 DeleteDateTime { get; set; }
    }
}

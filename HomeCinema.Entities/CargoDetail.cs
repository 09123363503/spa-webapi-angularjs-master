using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class CargoDetail : IEntityBase
    {
        public int ID { get; set; }
        [Required]
        public int CargoID { get; set; }
        [Required]
        public int BarcodeID { get; set; }


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

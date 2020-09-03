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
        [DefaultValue(1)]
        public int Count { get; set; }
        [DefaultValue(0)]
        public int LocationID { get; set; }
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
    }
}

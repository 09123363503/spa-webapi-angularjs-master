using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class Warehouse : IEntityBase
    {
        public int ID { get; set; }
        [DefaultValue(0)]
        public int ParentID { get; set; }
        [Required]
        public int Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string AreaLocation { get; set; }
        [Required]
        public int WHKeeperID { get; set; }
        [DefaultValue(0)]
        public bool Leased { get; set; }
        [DefaultValue(0)]
        public bool IsGroup { get; set; }
        public string Description { get; set; }
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

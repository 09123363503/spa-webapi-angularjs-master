using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class WarehouseViewModel
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string AreaLocation { get; set; }
        public int WHKeeperID { get; set; }
        public bool Leased { get; set; }
        public bool IsGroup { get; set; }
        public string Description { get; set; }
        public int RegisterID { get; set; }
        public Int64 RegisterDateTime { get; set; }
        public int EditID { get; set; }
        public Int64 EditDateTime { get; set; }
        public int DeleteID { get; set; }
        public Int64 DeleteDateTime { get; set; }
    }
}
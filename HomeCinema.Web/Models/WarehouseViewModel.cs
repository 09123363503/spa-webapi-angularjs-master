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
        public int CreateUserID { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public int ModifyUserID { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        public int DeleteUserID { get; set; }
        public DateTimeOffset DeleteOn { get; set; }
    }
}
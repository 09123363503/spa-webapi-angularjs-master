using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class Warehouse : IEntityBaseInteger
    {
        public Warehouse()
        {
            Warehouses = new List<Warehouse>();
            Locations = new List<Location>();
        }
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
        public int CreateUserID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset CreateOn { get; set; }
        [DefaultValue(0)]
        public int ModifyUserID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset ModifyOn { get; set; }
        [DefaultValue(0)]
        public int DeleteUserID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset DeleteOn { get; set; }

        public virtual ICollection<Warehouse> Warehouses { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}

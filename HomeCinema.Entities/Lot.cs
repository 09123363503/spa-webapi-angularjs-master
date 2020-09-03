using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class Lot : IEntityBaseInteger
    {
        public int ID { get; set; }
        [DefaultValue(0)]
        public int ArticleID { get; set; }
        public int AccountID { get; set; }
        public string ProducerLot { get; set; }
        [DefaultValue(0)]
        public int ProductionOrderID { get; set; }
        [DefaultValue(0)]
        public int OwnerID { get; set; }
        [DefaultValue(1)]
        public int Grade { get; set; }
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
    }
}

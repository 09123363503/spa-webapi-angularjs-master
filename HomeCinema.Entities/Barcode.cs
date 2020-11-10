using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HomeCinema.Entities
{
    public class Barcode : IEntityBaseInteger
    {
        public Barcode()
        {
            Cargos = new List<Cargo>();
        }
        public int ID { get; set; }
        [DefaultValue("1")]
        public string BarcodeString { get; set; }
        [DefaultValue(0)]
        public int ArticleID { get; set; }
        [DefaultValue(1)]
        public int Grade { get; set; }
        [DefaultValue(0)]
        public int UnitID1 { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue1 { get; set; }
        [DefaultValue(0)]
        public int UnitID2 { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue2 { get; set; }
        [DefaultValue(0)]
        public int UnitID3 { get; set; }
        [DefaultValue(0)]
        public decimal UnitValue3 { get; set; }
        [DefaultValue(1)]
        public int Count { get; set; }
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

        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class Cargo : IEntityBaseString
    {
        public string ID { get; set; }
        [Required]
        public int BarcodeID { get; set; }
        [Required]
        [DefaultValue(0)]
        public string InvoiceItemID { get; set; }
        public int ArticleID { get; set; }
        [DefaultValue(1)]
        public int Count { get; set; }
        [DefaultValue(0)]
        public int LocationID { get; set; }
        [DefaultValue(0)]
        public int SumUnitID1 { get; set; }
        [DefaultValue(0)]
        public int SumUnitValue1 { get; set; }
        [DefaultValue(0)]
        public int SumUnitID2 { get; set; }
        [DefaultValue(0)]
        public int SumunitValue2 { get; set; }
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

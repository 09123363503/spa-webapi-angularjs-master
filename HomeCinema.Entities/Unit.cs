using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class Unit : IEntityBase
    {
        public Unit()
        {
            MainArticles = new List<MainArticle>();
            Barcodes = new List<Barcode>();
            Cargos = new List<Cargo>();
            ProductionOrderDetails = new List<ProductionOrderDetail>();
        }
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(0)]
        public int RegisterID { get; set; }
        [DefaultValue(0)]
        public int EditID { get; set; }
        [DefaultValue(0)]
        public int DeleteID { get; set; }
        [DefaultValue(0)]
        public Int64 RegisterDatetime { get; set; }
        [DefaultValue(0)]
        public Int64 EditDateTime { get; set; }
        [DefaultValue(0)]
        public Int64 DeleteDateTime { get; set; }
        
        public virtual ICollection<MainArticle> MainArticles { get; set; }
        public virtual ICollection<Barcode> Barcodes { get; set; }
        public virtual ICollection<Cargo> Cargos { get; set; }
        public virtual ICollection<ProductionOrderDetail> ProductionOrderDetails { get; set; }
    }
}

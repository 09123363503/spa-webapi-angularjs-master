using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class Unit : IEntityBaseInteger
    {
        #region Relation list
        public Unit()
        {
            MainArticles = new List<MainArticle>();
            Barcodes = new List<Barcode>();
            Cargos = new List<Cargo>();
            ProductionOrderItems = new List<ProductionOrderItem>();
            InvoiceItems = new List<InvoiceItem>();
        }
        #endregion Relation list
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(0)]
        public int CreateUserID { get; set; }
        [DefaultValue(0)]
        public int ModifyUserID { get; set; }
        [DefaultValue(0)]
        public int DeleteUserID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset CreateOn { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset ModifyOn { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset DeleteOn { get; set; }

        #region Collections
        public virtual ICollection<MainArticle> MainArticles { get; set; }
        public virtual ICollection<Barcode> Barcodes { get; set; }
        public virtual ICollection<Cargo> Cargos { get; set; }
        public virtual ICollection<ProductionOrderItem> ProductionOrderItems { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
        #endregion Collection
    }
}

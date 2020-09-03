using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    /// <summary>
    /// Accounting Article
    /// </summary>
    public class Article : IEntityBase
    {
        public Article()
        {
            ArticleItems = new List<ArticleItem>();
            ProductionOrderDetails = new List<ProductionOrderDetail>();
        }
        public int ID { get; set; }
        [Required]
        public int MainArticleID { get; set; }
        public int PurchaseAccID { get; set; }
        public int SaleAccID { get; set; }
        public int InventoryAccID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int RegisterID { get; set; }
        public int EditionID { get; set; }
        public int DeleteID { get; set; }
        public Int64 RegisterDateTime { get; set; }
        public Int64 EditionDateTime { get; set; }
        public Int64 DeleteDateTime { get; set; }
        
        public virtual ICollection<ArticleItem> ArticleItems { get; set; }
        public virtual ICollection<ProductionOrderDetail> ProductionOrderDetails { get; set; }
    }
}

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
    public class Article : IEntityBaseInteger
    {
        public Article()
        {
            ArticleItems = new List<ArticleItem>();
            ProductionOrderItems = new List<ProductionOrderItem>();
            BasketArticles = new List<BasketArticle>();
            BasketBatcodes = new List<BasketBatcode>();
        }
        public int ID { get; set; }
        [Required]
        public int MainArticleID { get; set; }
        public int PurchaseAccID { get; set; }
        public int SaleAccID { get; set; }
        public int InventoryAccID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CreateUserID { get; set; }
        public int ModifyUserID { get; set; }
        public int DeleteUserID { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        public DateTimeOffset DeleteOn { get; set; }
        
        public virtual ICollection<ArticleItem> ArticleItems { get; set; }
        public virtual ICollection<ProductionOrderItem> ProductionOrderItems { get; set; }
        public virtual ICollection<BasketArticle> BasketArticles { get; set; }
        public virtual ICollection<BasketBatcode> BasketBatcodes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            BasketBatcodes = new List<BasketBarcode>();
            Barcodes = new List<Barcode>();
            //InvoiceItems = new List<InvoiceItem>();
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
        public virtual ICollection<BasketBarcode> BasketBatcodes { get; set; }
        public virtual ICollection<Barcode> Barcodes { get; set; }
        //public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}

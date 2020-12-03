using HomeCinema.Entities;

namespace HomeCinema.Data.Configurations
{
    public class ArticleConfiguration : EntityBaseConfigurationInt<Article>
    {
        public ArticleConfiguration()
        {
            Property(p => p.MainArticleID).IsRequired();
            Property(p => p.PurchaseAccID).IsRequired();
            Property(p => p.SaleAccID).IsRequired();
            Property(p => p.InventoryAccID).IsRequired();
            Property(p => p.Code).IsRequired();
            Property(p => p.Name).IsRequired();
            Property(p => p.CreateUserID);
            Property(p => p.ModifyUserID);
            Property(p => p.DeleteUserID);
            Property(p => p.CreateOn);
            Property(p => p.ModifyOn);
            Property(p => p.DeleteOn);
            //----------------------------------------------------------------------------------//
            HasMany(p => p.ArticleItems).WithRequired().HasForeignKey(s => s.ArticleID);
            HasMany(p => p.ProductionOrderItems).WithRequired().HasForeignKey(s => s.ArticleID);
            HasMany(p => p.BasketArticles).WithRequired().HasForeignKey(s => s.Parent);
            HasMany(p => p.BasketBatcodes).WithRequired().HasForeignKey(s => s.Parent);
            HasMany(p => p.Barcodes).WithRequired().HasForeignKey(s => s.ArticleID);
            //HasMany(p => p.InvoiceItems).WithRequired().HasForeignKey(s => s.ArticleID);
        }
    }
}

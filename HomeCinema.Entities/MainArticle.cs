using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    /// <summary>
    /// Accounting MainArticle
    /// </summary>
    public class MainArticle : IEntityBaseInteger
    {
        public MainArticle()
        {
            Articles = new List<Article>();
            MainArticleComponents = new List<MainArticleComponent>();
        }
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ViewName { get; set; }
        public int Unit1ID { get; set; }
        public int Unit2ID { get; set; }
        public int Unit3ID { get; set; }
        public int PurchaseAccID { get; set; }
        public int SalesAccID { get; set; }
        public int InventoryAccID { get; set; }
        public int CreateUserID { get; set; }
        public int ModifyUserID { get; set; }
        public int DeleteUserID { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        public DateTimeOffset DeleteOn { get; set; }
        
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<MainArticleComponent> MainArticleComponents { get; set; }
    }
}

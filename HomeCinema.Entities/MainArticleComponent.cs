using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class MainArticleComponent : IEntityBase
    {
        public MainArticleComponent()
        {
            ArticleItems = new List<ArticleItem>();
        }
        public int ID { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public int MainAricleID { get; set; }
        public int ComponentID { get; set; }
        public virtual ICollection<ArticleItem> ArticleItems { get; set; }
    }
}

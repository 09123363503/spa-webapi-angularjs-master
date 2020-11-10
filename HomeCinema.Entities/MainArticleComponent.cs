using System.Collections.Generic;

namespace HomeCinema.Entities
{
    public class MainArticleComponent : IEntityBaseInteger
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

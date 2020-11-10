using System.ComponentModel;

namespace HomeCinema.Entities
{
    public class ArticleItem : IEntityBaseInteger
    {
        public int ID { get; set; }
        [DefaultValue(0)]
        public int ArticleID { get; set; }
        [DefaultValue(0)]
        public int ComponentItemID { get; set; }
        [DefaultValue(0)]
        public int MainArticleComponentID { get; set; }
    }
}

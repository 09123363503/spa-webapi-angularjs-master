using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class ArticleItem : IEntityBase
    {
        public int ID { get; set; }
        public int ArticleID { get; set; }
        public int ComponentItemID { get; set; }
        public int MainArticleComponentID { get; set; }
    }
}

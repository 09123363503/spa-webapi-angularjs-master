using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class ArticleItem : IEntityBase
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

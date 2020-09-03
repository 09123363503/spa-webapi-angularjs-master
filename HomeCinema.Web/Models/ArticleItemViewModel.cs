using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class ArticleItemViewModel
    {
        public int ID { get; set; }

        public int GID { get; set; }
        public int ArticleID { get; set; }
        public int ComponentItemID { get; set; }
        public int MainArticleComponentID { get; set; }
    }
}
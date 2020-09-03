using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCinema.Web.Models
{
    public class ArticleViewModel
    {
        public int ID { get; set; }
        public int MainArticleID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CreateUserID { get; set; }
        public int ModifyUserID { get; set; }
        public int DeleteUserID { get; set; }
        public Int64 CreateOn { get; set; }
        public Int64 ModifyOn { get; set; }
        public Int64 DeleteOn { get; set; }
    }
}
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
        public DateTimeOffset CreateOn { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        public DateTimeOffset DeleteOn { get; set; }
    }
}
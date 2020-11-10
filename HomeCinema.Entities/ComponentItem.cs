using System;
using System.Collections.Generic;

namespace HomeCinema.Entities
{
    public class ComponentItem : IEntityBaseInteger
    {
        public ComponentItem()
        {
            ArticleItems = new List<ArticleItem>();
        }
        public int ID { get; set; }
        public int ComponentID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CreateUserID { get; set; }
        public int ModifyUserID { get; set; }
        public int DeleteUserID { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        public DateTimeOffset DeleteOn { get; set; }
        public virtual ICollection<ArticleItem> ArticleItems { get; set; }
    }
}

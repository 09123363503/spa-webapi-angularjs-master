using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Entities
{
    public class ComponentItem : IEntityBase
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
        public Int64 CreateOn { get; set; }
        public Int64 ModifyOn { get; set; }
        public Int64 DeleteOn { get; set; }
        public virtual ICollection<ArticleItem> ArticleItems { get; set; }
    }
}

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
        public int RegisterID { get; set; }
        public int EditionID { get; set; }
        public int DeleteID { get; set; }
        public Int64 RegisterDatetime { get; set; }
        public Int64 EditionDateTime { get; set; }
        public Int64 DeleteDateTime { get; set; }
        public virtual ICollection<ArticleItem> ArticleItems { get; set; }
    }
}

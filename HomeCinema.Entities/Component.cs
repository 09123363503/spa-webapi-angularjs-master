using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HomeCinema.Entities
{
    /// <summary>
    /// Accounting Component
    /// </summary>
    public class Component : IEntityBaseInteger
    {
        public Component()
        {
            ComponentItems = new List<ComponentItem>();
            MainArticleComponents = new LinkedList<MainArticleComponent>();
        }
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Lenght { get; set; }
        [DefaultValue(0)]
        public int CreateUserID { get; set; }
        public int ModifyUserID { get; set; }
        public int DeleteUserID { get; set; }
        public DateTimeOffset CreateOn { get; set; }
        public DateTimeOffset ModifyOn { get; set; }
        public DateTimeOffset DeleteOn { get; set; }
        public virtual ICollection<ComponentItem> ComponentItems { get; set; }
        public virtual ICollection<MainArticleComponent> MainArticleComponents { get; set; }
    }
}

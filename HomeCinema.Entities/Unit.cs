using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeCinema.Entities
{
    public class Unit : IEntityBaseInteger
    {
        #region Relation list
        public Unit()
        {
            MainArticles = new List<MainArticle>();
        }
        #endregion Relation list
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(0)]
        public int CreateUserID { get; set; }
        [DefaultValue(0)]
        public int ModifyUserID { get; set; }
        [DefaultValue(0)]
        public int DeleteUserID { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset CreateOn { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset ModifyOn { get; set; }
        [DefaultValue(0)]
        public DateTimeOffset DeleteOn { get; set; }

        #region Collections
        public virtual ICollection<MainArticle> MainArticles { get; set; }
        #endregion Collection
    }
}

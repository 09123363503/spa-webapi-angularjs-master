using HomeCinema.Data.Configurations;
using HomeCinema.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data
{
    public class HomeCinemaContext : DbContext
    {
        public HomeCinemaContext()
            : base("HomeCinema")
        {
            Database.SetInitializer<HomeCinemaContext>(null);
        }

        #region Entity Sets
        public IDbSet<User> UserSet { get; set; }
        public IDbSet<Role> RoleSet { get; set; }
        public IDbSet<UserRole> UserRoleSet { get; set; }
        public IDbSet<Customer> CustomerSet { get; set; }
        public IDbSet<Movie> MovieSet { get; set; }
        public IDbSet<Genre> GenreSet { get; set; }
        public IDbSet<Stock> StockSet { get; set; }
        public IDbSet<Rental> RentalSet { get; set; }
        public IDbSet<Error> ErrorSet { get; set; }
        public IDbSet<MainArticle> MainArticleSet { get; set; }
        public IDbSet<Article> ArticleSet { get; set; }
        public IDbSet<Unit> UnitSet { get; set; }
        public IDbSet<ArticleItem> ArticleItemSet { get; set; }
        public IDbSet<Component> ComponentSet { get; set; }
        public IDbSet<ComponentItem> ComponentItemSet { get; set; }
        public IDbSet<MainArticleComponent> MainArticleComponentSet { get; set; }
        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        #region Model Builder
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new MovieConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new StockConfiguration());
            modelBuilder.Configurations.Add(new RentalConfiguration());
            modelBuilder.Configurations.Add(new MainArticleConfiguration());
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new UnitConfiguration());
            modelBuilder.Configurations.Add(new ArticleItemConfiguration());
            modelBuilder.Configurations.Add(new ComponentConfiguration());
            modelBuilder.Configurations.Add(new ComponentItemConfiguration());
            modelBuilder.Configurations.Add(new MainArticleComponentConfiguration());

            modelBuilder.Entity<Article>().Property(p => p.PurchaseAccID).HasColumnAnnotation("0", true);
            modelBuilder.Entity<Article>().Property(p => p.SaleAccID).HasColumnAnnotation("0", true);
            modelBuilder.Entity<Article>().Property(p => p.InventoryAccID).HasColumnAnnotation("0", true);
            //base.OnModelCreating(modelBuilder);
        }
        #endregion Model Builder
    }
}

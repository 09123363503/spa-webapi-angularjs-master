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
        public IDbSet<Lot> LotSet { get; set; }
        public IDbSet<Barcode> BarcodeSet { get; set; }
        public IDbSet<Cargo> CargoSet { get; set; }
        public IDbSet<Location> LocationSet { get; set; }
        public IDbSet<Warehouse> WarehoseSet { get; set; }
        public IDbSet<ProductionOrder> ProdutionOrderSet { get; set; }
        public IDbSet<ProductionOrderItem> ProdutionOrderItemSet { get; set; }
        public IDbSet<Account> AccountSet { get; set; }
        public IDbSet<FinancialPeriod> FinancialPeridSet { get; set; }
        public IDbSet<ProductionLine> ProdutionLineSet { get; set; }
        public IDbSet<ProductType> ProductTypeSet { get; set; }
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
            modelBuilder.Configurations.Add(new LotConfiguration());
            modelBuilder.Configurations.Add(new BarcodeConfiguration());
            modelBuilder.Configurations.Add(new CargoConfiguration());
            modelBuilder.Configurations.Add(new CargoConfiguration());
            modelBuilder.Configurations.Add(new WareHouseConfiguration());
            modelBuilder.Configurations.Add(new LocationConfiguration());
            modelBuilder.Configurations.Add(new ProductionOrderConfiguration());
            modelBuilder.Configurations.Add(new ProductionOrderItemConfiguration());
            modelBuilder.Configurations.Add(new AccountConfiguration());
            modelBuilder.Configurations.Add(new FinancialPeriodConfiguration());
            modelBuilder.Configurations.Add(new ProductionLineConfiguration());
            modelBuilder.Configurations.Add(new ProductTypeConfiguration());

            #region Relation Constraint
            modelBuilder.Entity<Component>().HasMany(p => p.MainArticleComponents)
                .WithRequired().HasForeignKey(p => p.ComponentID).WillCascadeOnDelete(false);

            modelBuilder.Entity<MainArticle>().HasMany(p => p.MainArticleComponents)
                .WithRequired().HasForeignKey(p => p.MainAricleID).WillCascadeOnDelete(false);
            #endregion Relation Constraint
        }
        #endregion Model Builder
    }
}

namespace HomeCinema.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ArticleID = c.Int(nullable: false),
                        ComponentItemID = c.Int(nullable: false),
                        MainArticleComponentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Article", t => t.ArticleID, cascadeDelete: true)
                .ForeignKey("dbo.ComponentItem", t => t.ComponentItemID, cascadeDelete: true)
                .ForeignKey("dbo.MainArticleComponent", t => t.MainArticleComponentID, cascadeDelete: true)
                .Index(t => t.ArticleID)
                .Index(t => t.ComponentItemID)
                .Index(t => t.MainArticleComponentID);
            
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MainArticleID = c.Int(nullable: false),
                        PurchaseAccID = c.Int(nullable: false),
                        SaleAccID = c.Int(nullable: false),
                        InventoryAccID = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        RegisterID = c.Int(nullable: false),
                        EditionID = c.Int(nullable: false),
                        DeleteID = c.Int(nullable: false),
                        RegisterDateTime = c.Long(nullable: false),
                        EditionDateTime = c.Long(nullable: false),
                        DeleteDateTime = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MainArticle", t => t.MainArticleID, cascadeDelete: true)
                .Index(t => t.MainArticleID);
            
            CreateTable(
                "dbo.ComponentItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ComponentID = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        RegisterID = c.Int(nullable: false),
                        EditionID = c.Int(nullable: false),
                        DeleteID = c.Int(nullable: false),
                        RegisterDatetime = c.Long(nullable: false),
                        EditionDateTime = c.Long(nullable: false),
                        DeleteDateTime = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Component", t => t.ComponentID, cascadeDelete: true)
                .Index(t => t.ComponentID);
            
            CreateTable(
                "dbo.Component",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Lenght = c.Int(nullable: false),
                        RegisterID = c.Int(nullable: false),
                        EditionID = c.Int(nullable: false),
                        DeleteID = c.Int(nullable: false),
                        RegisterDatetime = c.Long(nullable: false),
                        EditionDateTime = c.Long(nullable: false),
                        DeleteDateTime = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MainArticleComponent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        MainAricleID = c.Int(nullable: false),
                        ComponentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Component", t => t.ComponentID)
                .ForeignKey("dbo.MainArticle", t => t.MainAricleID)
                .Index(t => t.MainAricleID)
                .Index(t => t.ComponentID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        IdentityCard = c.String(nullable: false, maxLength: 50),
                        UniqueKey = c.Guid(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Mobile = c.String(maxLength: 10),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        StackTrace = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 2000),
                        Image = c.String(),
                        GenreId = c.Int(nullable: false),
                        Director = c.String(nullable: false, maxLength: 100),
                        Writer = c.String(nullable: false, maxLength: 50),
                        Producer = c.String(nullable: false, maxLength: 50),
                        ReleaseDate = c.DateTime(nullable: false),
                        Rating = c.Byte(nullable: false),
                        TrailerURI = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        UniqueKey = c.Guid(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Rental",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        StockId = c.Int(nullable: false),
                        RentalDate = c.DateTime(nullable: false),
                        ReturnedDate = c.DateTime(),
                        Status = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Stock", t => t.StockId, cascadeDelete: true)
                .Index(t => t.StockId);
            
            CreateTable(
                "dbo.MainArticle",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        ViewName = c.String(),
                        Unit1ID = c.Int(nullable: false),
                        Unit2ID = c.Int(nullable: false),
                        Unit3ID = c.Int(nullable: false),
                        PurchaseAccID = c.Int(nullable: false),
                        SalesAccID = c.Int(nullable: false),
                        InventoryAccID = c.Int(nullable: false),
                        RegisterID = c.Int(nullable: false),
                        EditionID = c.Int(nullable: false),
                        DeleteID = c.Int(nullable: false),
                        RegisterDateTime = c.Long(nullable: false),
                        EditionDateTime = c.Long(nullable: false),
                        DeleteDateTime = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Unit", t => t.Unit3ID, cascadeDelete: true)
                .Index(t => t.Unit3ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        RegisterID = c.Int(nullable: false),
                        EditionID = c.Int(nullable: false),
                        DeleteID = c.Int(nullable: false),
                        RegisterDatetime = c.Long(nullable: false),
                        EditionDateTime = c.Long(nullable: false),
                        DeleteDateTime = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 200),
                        HashedPassword = c.String(nullable: false, maxLength: 200),
                        Salt = c.String(nullable: false, maxLength: 200),
                        IsLocked = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.MainArticle", "Unit3ID", "dbo.Unit");
            DropForeignKey("dbo.MainArticleComponent", "MainAricleID", "dbo.MainArticle");
            DropForeignKey("dbo.Article", "MainArticleID", "dbo.MainArticle");
            DropForeignKey("dbo.Rental", "StockId", "dbo.Stock");
            DropForeignKey("dbo.Stock", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Movie", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.MainArticleComponent", "ComponentID", "dbo.Component");
            DropForeignKey("dbo.ArticleItem", "MainArticleComponentID", "dbo.MainArticleComponent");
            DropForeignKey("dbo.ComponentItem", "ComponentID", "dbo.Component");
            DropForeignKey("dbo.ArticleItem", "ComponentItemID", "dbo.ComponentItem");
            DropForeignKey("dbo.ArticleItem", "ArticleID", "dbo.Article");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.MainArticle", new[] { "Unit3ID" });
            DropIndex("dbo.Rental", new[] { "StockId" });
            DropIndex("dbo.Stock", new[] { "MovieId" });
            DropIndex("dbo.Movie", new[] { "GenreId" });
            DropIndex("dbo.MainArticleComponent", new[] { "ComponentID" });
            DropIndex("dbo.MainArticleComponent", new[] { "MainAricleID" });
            DropIndex("dbo.ComponentItem", new[] { "ComponentID" });
            DropIndex("dbo.Article", new[] { "MainArticleID" });
            DropIndex("dbo.ArticleItem", new[] { "MainArticleComponentID" });
            DropIndex("dbo.ArticleItem", new[] { "ComponentItemID" });
            DropIndex("dbo.ArticleItem", new[] { "ArticleID" });
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Unit");
            DropTable("dbo.Role");
            DropTable("dbo.MainArticle");
            DropTable("dbo.Rental");
            DropTable("dbo.Stock");
            DropTable("dbo.Movie");
            DropTable("dbo.Genre");
            DropTable("dbo.Error");
            DropTable("dbo.Customer");
            DropTable("dbo.MainArticleComponent");
            DropTable("dbo.Component");
            DropTable("dbo.ComponentItem");
            DropTable("dbo.Article");
            DropTable("dbo.ArticleItem");
        }
    }
}

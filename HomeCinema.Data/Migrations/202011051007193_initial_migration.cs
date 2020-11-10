namespace HomeCinema.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Code = c.String(nullable: false),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Invoice",
                c => new
                {
                    ID = c.String(nullable: false, maxLength: 128),
                    AccountID = c.Int(nullable: false),
                    InvoiceTypeID = c.Int(nullable: false),
                    MyCompanyID = c.Int(nullable: false),
                    Date = c.DateTimeOffset(nullable: false, precision: 7),
                    Number = c.Int(nullable: false),
                    Description = c.String(),
                    CreateUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyUserID = c.Int(nullable: false),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteUserID = c.Int(nullable: false),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.InvoiceType", t => t.InvoiceTypeID, cascadeDelete: true)
                .ForeignKey("dbo.MyCompany", t => t.MyCompanyID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.InvoiceTypeID)
                .Index(t => t.MyCompanyID);

            CreateTable(
                "dbo.InvoiceItem",
                c => new
                {
                    ID = c.String(nullable: false, maxLength: 128),
                    InvoiceID = c.String(nullable: false, maxLength: 128),
                    WarehouseID = c.Int(nullable: false),
                    Count = c.Int(nullable: false),
                    UnitID1 = c.Int(nullable: false),
                    UnitValue1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    UnitID2 = c.Int(nullable: false),
                    UnitValue2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    UnitID3 = c.Int(nullable: false),
                    UnitValue3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    CreateUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyUserID = c.Int(nullable: false),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteUserID = c.Int(nullable: false),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
                    Unit_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Invoice", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Unit", t => t.Unit_ID)
                .Index(t => t.InvoiceID)
                .Index(t => t.Unit_ID);

            CreateTable(
                "dbo.Cargo",
                c => new
                {
                    ID = c.String(nullable: false, maxLength: 128),
                    BarcodeID = c.Int(nullable: false),
                    InvoiceItemID = c.String(nullable: false, maxLength: 128),
                    ArticleID = c.Int(nullable: false),
                    Count = c.Int(nullable: false),
                    LocationID = c.Int(nullable: false),
                    SumUnitID1 = c.Int(nullable: false),
                    SumUnitValue1 = c.Int(nullable: false),
                    SumUnitID2 = c.Int(nullable: false),
                    SumunitValue2 = c.Int(nullable: false),
                    CreateUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyUserID = c.Int(nullable: false),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteUserID = c.Int(nullable: false),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
                    Unit_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InvoiceItem", t => t.InvoiceItemID, cascadeDelete: true)
                .ForeignKey("dbo.Barcode", t => t.BarcodeID, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.Unit", t => t.Unit_ID)
                .Index(t => t.BarcodeID)
                .Index(t => t.InvoiceItemID)
                .Index(t => t.LocationID)
                .Index(t => t.Unit_ID);

            CreateTable(
                "dbo.Lot",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ArticleID = c.Int(nullable: false),
                    AccountID = c.Int(nullable: false),
                    ProducerLot = c.String(),
                    ProductionOrderID = c.Int(nullable: false),
                    OwnerID = c.Int(nullable: false),
                    Grade = c.Int(nullable: false),
                    CreateUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyUserID = c.Int(nullable: false),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteUserID = c.Int(nullable: false),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.ProductionOrder", t => t.ProductionOrderID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.ProductionOrderID);

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
                    CreateUserID = c.Int(nullable: false),
                    ModifyUserID = c.Int(nullable: false),
                    DeleteUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MainArticle", t => t.MainArticleID, cascadeDelete: true)
                .Index(t => t.MainArticleID);

            CreateTable(
                "dbo.BasketArticle",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Parent = c.Int(nullable: false),
                    Child = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Article", t => t.Child, cascadeDelete: true)
                .Index(t => t.Child);

            CreateTable(
                "dbo.BasketBarcode",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Parent = c.Int(nullable: false),
                    Child = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Article", t => t.Child, cascadeDelete: true)
                .Index(t => t.Child);

            CreateTable(
                "dbo.ProductionOrderItem",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ProductionOrederID = c.Int(nullable: false),
                    ArticleID = c.Int(nullable: false),
                    UnitID1 = c.Int(nullable: false),
                    UnitID2 = c.Int(nullable: false),
                    UnitID3 = c.Int(nullable: false),
                    UnitValue1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    UnitValue2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    UnitValue3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Unit_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Article", t => t.ArticleID, cascadeDelete: true)
                .ForeignKey("dbo.ProductionOrder", t => t.ProductionOrederID, cascadeDelete: true)
                .ForeignKey("dbo.Unit", t => t.Unit_ID)
                .Index(t => t.ProductionOrederID)
                .Index(t => t.ArticleID)
                .Index(t => t.Unit_ID);

            CreateTable(
                "dbo.Barcode",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    BarcodeString = c.String(nullable: false),
                    ArticleID = c.Int(nullable: false),
                    Grade = c.Int(nullable: false),
                    UnitID1 = c.Int(nullable: false),
                    UnitValue1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    UnitID2 = c.Int(nullable: false),
                    UnitValue2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    UnitID3 = c.Int(nullable: false),
                    UnitValue3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Count = c.Int(nullable: false),
                    CreateUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyUserID = c.Int(nullable: false),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteUserID = c.Int(nullable: false),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
                    Unit_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Unit", t => t.Unit_ID)
                .Index(t => t.Unit_ID);

            CreateTable(
                "dbo.BaseInvoiceType",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Code = c.String(nullable: false),
                    Name = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.InvoiceType",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    BaseInvoiceTypeID = c.Int(nullable: false),
                    Code = c.String(nullable: false),
                    Name = c.String(nullable: false),
                    Abbreviation = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BaseInvoiceType", t => t.BaseInvoiceTypeID, cascadeDelete: true)
                .Index(t => t.BaseInvoiceTypeID);

            CreateTable(
                "dbo.ComponentItem",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ComponentID = c.Int(nullable: false),
                    Code = c.String(nullable: false),
                    Name = c.String(nullable: false),
                    CreateUserID = c.Int(nullable: false),
                    ModifyUserID = c.Int(nullable: false),
                    DeleteUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
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
                    CreateUserID = c.Int(nullable: false),
                    ModifyUserID = c.Int(nullable: false),
                    DeleteUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
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
                "dbo.FinancialPeriod",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Number = c.Int(nullable: false),
                    Name = c.String(nullable: false),
                    StartDate = c.Int(nullable: false),
                    EndDate = c.Int(nullable: false),
                    FinanciaPeriodTransfered = c.Boolean(nullable: false),
                    TemporaryClose = c.Boolean(nullable: false),
                    PermanentClose = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.ProductionOrder",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ProductionLineID = c.Int(nullable: false),
                    FinancialPeriodID = c.Int(nullable: false),
                    Number = c.Int(nullable: false),
                    Date = c.Int(nullable: false),
                    ProductTypeID = c.Int(nullable: false),
                    Description = c.String(),
                    StartDateTime = c.DateTimeOffset(nullable: false, precision: 7),
                    FinishDateTime = c.DateTimeOffset(nullable: false, precision: 7),
                    State = c.Int(nullable: false),
                    ConfirmID = c.Int(nullable: false),
                    DeliveryDateTime = c.DateTimeOffset(nullable: false, precision: 7),
                    CreateUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyUserID = c.Int(nullable: false),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteUserID = c.Int(nullable: false),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FinancialPeriod", t => t.FinancialPeriodID, cascadeDelete: true)
                .ForeignKey("dbo.ProductType", t => t.ProductTypeID, cascadeDelete: true)
                .ForeignKey("dbo.ProductionLine", t => t.ProductionLineID, cascadeDelete: true)
                .Index(t => t.ProductionLineID)
                .Index(t => t.FinancialPeriodID)
                .Index(t => t.ProductTypeID);

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
                "dbo.Location",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    WarehouseID = c.Int(nullable: false),
                    Name = c.String(nullable: false),
                    Block = c.String(),
                    Shelf = c.String(),
                    Level = c.String(),
                    Row = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseID, cascadeDelete: true)
                .Index(t => t.WarehouseID);

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
                    CreateUserID = c.Int(nullable: false),
                    ModifyUserID = c.Int(nullable: false),
                    DeleteUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
                    Unit_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Unit", t => t.Unit_ID)
                .Index(t => t.Unit_ID);

            CreateTable(
                "dbo.MyCompany",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    CompanyName = c.String(nullable: false),
                    EconomicCode = c.String(),
                    PhoneNumber1 = c.String(),
                    PhoneNumber2 = c.String(),
                    FaxNumber = c.String(),
                    Address = c.String(),
                    Slogan = c.String(),
                    Warning = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.ProductType",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Code = c.String(nullable: false),
                    Name = c.String(nullable: false),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.ProductionLine",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Code = c.String(nullable: false),
                })
                .PrimaryKey(t => t.ID);

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
                    CreateUserID = c.Int(nullable: false),
                    ModifyUserID = c.Int(nullable: false),
                    DeleteUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
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

            CreateTable(
                "dbo.Warehouse",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ParentID = c.Int(nullable: false),
                    Code = c.Int(nullable: false),
                    Name = c.String(nullable: false),
                    AreaLocation = c.String(),
                    WHKeeperID = c.Int(nullable: false),
                    Leased = c.Boolean(nullable: false),
                    IsGroup = c.Boolean(nullable: false),
                    Description = c.String(),
                    CreateUserID = c.Int(nullable: false),
                    CreateOn = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifyUserID = c.Int(nullable: false),
                    ModifyOn = c.DateTimeOffset(nullable: false, precision: 7),
                    DeleteUserID = c.Int(nullable: false),
                    DeleteOn = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Location", "WarehouseID", "dbo.Warehouse");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ProductionOrderItem", "Unit_ID", "dbo.Unit");
            DropForeignKey("dbo.MainArticle", "Unit_ID", "dbo.Unit");
            DropForeignKey("dbo.InvoiceItem", "Unit_ID", "dbo.Unit");
            DropForeignKey("dbo.Cargo", "Unit_ID", "dbo.Unit");
            DropForeignKey("dbo.Barcode", "Unit_ID", "dbo.Unit");
            DropForeignKey("dbo.ProductionOrder", "ProductionLineID", "dbo.ProductionLine");
            DropForeignKey("dbo.ProductionOrder", "ProductTypeID", "dbo.ProductType");
            DropForeignKey("dbo.Invoice", "MyCompanyID", "dbo.MyCompany");
            DropForeignKey("dbo.MainArticleComponent", "MainAricleID", "dbo.MainArticle");
            DropForeignKey("dbo.Article", "MainArticleID", "dbo.MainArticle");
            DropForeignKey("dbo.Cargo", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Rental", "StockId", "dbo.Stock");
            DropForeignKey("dbo.Stock", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Movie", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.ProductionOrder", "FinancialPeriodID", "dbo.FinancialPeriod");
            DropForeignKey("dbo.ProductionOrderItem", "ProductionOrederID", "dbo.ProductionOrder");
            DropForeignKey("dbo.Lot", "ProductionOrderID", "dbo.ProductionOrder");
            DropForeignKey("dbo.MainArticleComponent", "ComponentID", "dbo.Component");
            DropForeignKey("dbo.ArticleItem", "MainArticleComponentID", "dbo.MainArticleComponent");
            DropForeignKey("dbo.ComponentItem", "ComponentID", "dbo.Component");
            DropForeignKey("dbo.ArticleItem", "ComponentItemID", "dbo.ComponentItem");
            DropForeignKey("dbo.InvoiceType", "BaseInvoiceTypeID", "dbo.BaseInvoiceType");
            DropForeignKey("dbo.Invoice", "InvoiceTypeID", "dbo.InvoiceType");
            DropForeignKey("dbo.Cargo", "BarcodeID", "dbo.Barcode");
            DropForeignKey("dbo.ProductionOrderItem", "ArticleID", "dbo.Article");
            DropForeignKey("dbo.BasketBarcode", "Child", "dbo.Article");
            DropForeignKey("dbo.BasketArticle", "Child", "dbo.Article");
            DropForeignKey("dbo.ArticleItem", "ArticleID", "dbo.Article");
            DropForeignKey("dbo.Lot", "AccountID", "dbo.Account");
            DropForeignKey("dbo.Invoice", "AccountID", "dbo.Account");
            DropForeignKey("dbo.InvoiceItem", "InvoiceID", "dbo.Invoice");
            DropForeignKey("dbo.Cargo", "InvoiceItemID", "dbo.InvoiceItem");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.MainArticle", new[] { "Unit_ID" });
            DropIndex("dbo.Location", new[] { "WarehouseID" });
            DropIndex("dbo.Rental", new[] { "StockId" });
            DropIndex("dbo.Stock", new[] { "MovieId" });
            DropIndex("dbo.Movie", new[] { "GenreId" });
            DropIndex("dbo.ProductionOrder", new[] { "ProductTypeID" });
            DropIndex("dbo.ProductionOrder", new[] { "FinancialPeriodID" });
            DropIndex("dbo.ProductionOrder", new[] { "ProductionLineID" });
            DropIndex("dbo.MainArticleComponent", new[] { "ComponentID" });
            DropIndex("dbo.MainArticleComponent", new[] { "MainAricleID" });
            DropIndex("dbo.ComponentItem", new[] { "ComponentID" });
            DropIndex("dbo.InvoiceType", new[] { "BaseInvoiceTypeID" });
            DropIndex("dbo.Barcode", new[] { "Unit_ID" });
            DropIndex("dbo.ProductionOrderItem", new[] { "Unit_ID" });
            DropIndex("dbo.ProductionOrderItem", new[] { "ArticleID" });
            DropIndex("dbo.ProductionOrderItem", new[] { "ProductionOrederID" });
            DropIndex("dbo.BasketBarcode", new[] { "Child" });
            DropIndex("dbo.BasketArticle", new[] { "Child" });
            DropIndex("dbo.Article", new[] { "MainArticleID" });
            DropIndex("dbo.ArticleItem", new[] { "MainArticleComponentID" });
            DropIndex("dbo.ArticleItem", new[] { "ComponentItemID" });
            DropIndex("dbo.ArticleItem", new[] { "ArticleID" });
            DropIndex("dbo.Lot", new[] { "ProductionOrderID" });
            DropIndex("dbo.Lot", new[] { "AccountID" });
            DropIndex("dbo.Cargo", new[] { "Unit_ID" });
            DropIndex("dbo.Cargo", new[] { "LocationID" });
            DropIndex("dbo.Cargo", new[] { "InvoiceItemID" });
            DropIndex("dbo.Cargo", new[] { "BarcodeID" });
            DropIndex("dbo.InvoiceItem", new[] { "Unit_ID" });
            DropIndex("dbo.InvoiceItem", new[] { "InvoiceID" });
            DropIndex("dbo.Invoice", new[] { "MyCompanyID" });
            DropIndex("dbo.Invoice", new[] { "InvoiceTypeID" });
            DropIndex("dbo.Invoice", new[] { "AccountID" });
            DropTable("dbo.Warehouse");
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Unit");
            DropTable("dbo.Role");
            DropTable("dbo.ProductionLine");
            DropTable("dbo.ProductType");
            DropTable("dbo.MyCompany");
            DropTable("dbo.MainArticle");
            DropTable("dbo.Location");
            DropTable("dbo.Rental");
            DropTable("dbo.Stock");
            DropTable("dbo.Movie");
            DropTable("dbo.Genre");
            DropTable("dbo.ProductionOrder");
            DropTable("dbo.FinancialPeriod");
            DropTable("dbo.Error");
            DropTable("dbo.Customer");
            DropTable("dbo.MainArticleComponent");
            DropTable("dbo.Component");
            DropTable("dbo.ComponentItem");
            DropTable("dbo.InvoiceType");
            DropTable("dbo.BaseInvoiceType");
            DropTable("dbo.Barcode");
            DropTable("dbo.ProductionOrderItem");
            DropTable("dbo.BasketBarcode");
            DropTable("dbo.BasketArticle");
            DropTable("dbo.Article");
            DropTable("dbo.ArticleItem");
            DropTable("dbo.Lot");
            DropTable("dbo.Cargo");
            DropTable("dbo.InvoiceItem");
            DropTable("dbo.Invoice");
            DropTable("dbo.Account");
        }
    }
}

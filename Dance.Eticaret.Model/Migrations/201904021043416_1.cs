namespace Dance.Eticaret.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DanceLessonID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateUserID = c.Int(nullable: false),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DanceLessons", t => t.DanceLessonID)
                .Index(t => t.DanceLessonID);
            
            CreateTable(
                "dbo.DanceLessons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DanceTypeID = c.String(),
                        Trainer = c.String(),
                        ImageUrl = c.String(),
                        VideoUrl = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kontenjan = c.Int(nullable: false),
                        IsActive = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateUserID = c.Int(nullable: false),
                        UpdateUserID = c.Int(),
                        DanceType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DanceTypes", t => t.DanceType_ID)
                .Index(t => t.DanceType_ID);
            
            CreateTable(
                "dbo.DanceTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(nullable: false),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateUserID = c.Int(nullable: false),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderLessons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        DanceLessonID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateUserID = c.Int(nullable: false),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DanceLessons", t => t.DanceLessonID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID)
                .Index(t => t.DanceLessonID);
            
            CreateTable(
                "dbo.OrderPayments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        OrderType = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bank = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateUserID = c.Int(nullable: false),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        UserAddressID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        TotalLessonPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalTaxPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDiscount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateUserID = c.Int(nullable: false),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Status", t => t.StatusID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.UserAddresses", t => t.UserAddressID)
                .Index(t => t.UserID)
                .Index(t => t.UserAddressID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateUserID = c.Int(nullable: false),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                        Password = c.String(),
                        TcNo = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ISAdmin = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateUserID = c.Int(nullable: false),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Title = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        IsActive = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateUserID = c.Int(nullable: false),
                        UpdateUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserAddressID", "dbo.UserAddresses");
            DropForeignKey("dbo.UserAddresses", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "StatusID", "dbo.Status");
            DropForeignKey("dbo.OrderPayments", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderLessons", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderLessons", "DanceLessonID", "dbo.DanceLessons");
            DropForeignKey("dbo.Baskets", "DanceLessonID", "dbo.DanceLessons");
            DropForeignKey("dbo.DanceLessons", "DanceType_ID", "dbo.DanceTypes");
            DropIndex("dbo.UserAddresses", new[] { "UserID" });
            DropIndex("dbo.Orders", new[] { "StatusID" });
            DropIndex("dbo.Orders", new[] { "UserAddressID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.OrderPayments", new[] { "OrderID" });
            DropIndex("dbo.OrderLessons", new[] { "DanceLessonID" });
            DropIndex("dbo.OrderLessons", new[] { "OrderID" });
            DropIndex("dbo.DanceLessons", new[] { "DanceType_ID" });
            DropIndex("dbo.Baskets", new[] { "DanceLessonID" });
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Users");
            DropTable("dbo.Status");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderPayments");
            DropTable("dbo.OrderLessons");
            DropTable("dbo.DanceTypes");
            DropTable("dbo.DanceLessons");
            DropTable("dbo.Baskets");
        }
    }
}

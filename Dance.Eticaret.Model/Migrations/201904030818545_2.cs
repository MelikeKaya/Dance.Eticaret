namespace Dance.Eticaret.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DanceLessons", new[] { "DanceType_ID" });
            DropColumn("dbo.DanceLessons", "DanceTypeID");
            RenameColumn(table: "dbo.DanceLessons", name: "DanceType_ID", newName: "DanceTypeID");
            AlterColumn("dbo.DanceLessons", "DanceTypeID", c => c.Int(nullable: false));
            AlterColumn("dbo.DanceLessons", "DanceTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.DanceLessons", "DanceTypeID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DanceLessons", new[] { "DanceTypeID" });
            AlterColumn("dbo.DanceLessons", "DanceTypeID", c => c.Int());
            AlterColumn("dbo.DanceLessons", "DanceTypeID", c => c.String());
            RenameColumn(table: "dbo.DanceLessons", name: "DanceTypeID", newName: "DanceType_ID");
            AddColumn("dbo.DanceLessons", "DanceTypeID", c => c.String());
            CreateIndex("dbo.DanceLessons", "DanceType_ID");
        }
    }
}

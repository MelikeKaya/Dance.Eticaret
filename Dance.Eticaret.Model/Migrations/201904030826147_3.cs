namespace Dance.Eticaret.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DanceLessons", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DanceLessons", "IsActive", c => c.Int(nullable: false));
        }
    }
}

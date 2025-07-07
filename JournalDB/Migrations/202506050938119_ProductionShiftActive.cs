namespace JournalDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductionShiftActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JournalTypes", "ProductionShiftActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JournalTypes", "ProductionShiftActive");
        }
    }
}

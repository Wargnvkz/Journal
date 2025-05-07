namespace JournalDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JournalTypes",
                c => new
                    {
                        JournalTypeID = c.Int(nullable: false, identity: true),
                        JournalTypeName = c.String(),
                    })
                .PrimaryKey(t => t.JournalTypeID);
            
            CreateTable(
                "dbo.JournalTypeUserTypeRights",
                c => new
                    {
                        JournalTypeUserTypeRightID = c.Int(nullable: false, identity: true),
                        JournalTypeID = c.Int(nullable: false),
                        UserTypeID = c.Int(nullable: false),
                        bUserTypeRight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JournalTypeUserTypeRightID)
                .ForeignKey("dbo.JournalTypes", t => t.JournalTypeID, cascadeDelete: true)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeID, cascadeDelete: true)
                .Index(t => t.JournalTypeID)
                .Index(t => t.UserTypeID);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeID = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(),
                    })
                .PrimaryKey(t => t.UserTypeID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        AutoLogonComputerNames = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.MessageFiles",
                c => new
                    {
                        MessageFileID = c.Int(nullable: false, identity: true),
                        MessageID = c.Int(nullable: false),
                        Filename = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.MessageFileID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        CreatingDate = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        JournalTypeID = c.Int(nullable: false),
                        MessageText = c.String(),
                        IsPinned = c.Boolean(nullable: false),
                        StartPin = c.DateTime(),
                        StopPin = c.DateTime(),
                    })
                .PrimaryKey(t => t.MessageID);
            
            CreateTable(
                "dbo.UserUserTypes",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        UserType_UserTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.UserType_UserTypeID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.UserTypes", t => t.UserType_UserTypeID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.UserType_UserTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JournalTypeUserTypeRights", "UserTypeID", "dbo.UserTypes");
            DropForeignKey("dbo.UserUserTypes", "UserType_UserTypeID", "dbo.UserTypes");
            DropForeignKey("dbo.UserUserTypes", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.JournalTypeUserTypeRights", "JournalTypeID", "dbo.JournalTypes");
            DropIndex("dbo.UserUserTypes", new[] { "UserType_UserTypeID" });
            DropIndex("dbo.UserUserTypes", new[] { "User_UserID" });
            DropIndex("dbo.JournalTypeUserTypeRights", new[] { "UserTypeID" });
            DropIndex("dbo.JournalTypeUserTypeRights", new[] { "JournalTypeID" });
            DropTable("dbo.UserUserTypes");
            DropTable("dbo.Messages");
            DropTable("dbo.MessageFiles");
            DropTable("dbo.Users");
            DropTable("dbo.UserTypes");
            DropTable("dbo.JournalTypeUserTypeRights");
            DropTable("dbo.JournalTypes");
        }
    }
}

namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Announcements", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies");
            DropForeignKey("dbo.AspNetUsers", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies");
            DropForeignKey("dbo.Roles", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies");
            DropForeignKey("dbo.AspNetUsers", "SubRole_ID", "dbo.SubRoles");
            DropForeignKey("dbo.SubRoles", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies");
            DropForeignKey("dbo.AspNetUsers", "DeathPrivacy_ID", "dbo.DeathPrivacies");
            DropForeignKey("dbo.Deaths", "DeathPrivacy_ID", "dbo.DeathPrivacies");
            DropForeignKey("dbo.Roles", "DeathPrivacy_ID", "dbo.DeathPrivacies");
            DropForeignKey("dbo.SubRoles", "DeathPrivacy_ID", "dbo.DeathPrivacies");
            DropForeignKey("dbo.AspNetUsers", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies");
            DropForeignKey("dbo.AspNetUsers", "FolderGroup_ID", "dbo.FolderGroups");
            DropForeignKey("dbo.Roles", "FolderGroup_ID", "dbo.FolderGroups");
            DropForeignKey("dbo.SubRoles", "FolderGroup_ID", "dbo.FolderGroups");
            DropForeignKey("dbo.FolderGroups", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies");
            DropForeignKey("dbo.Roles", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies");
            DropForeignKey("dbo.SubRoles", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies");
            DropForeignKey("dbo.AspNetUsers", "FolderPrivacy_ID", "dbo.FolderPrivacies");
            DropForeignKey("dbo.Folders", "FolderPrivacy_ID", "dbo.FolderPrivacies");
            DropForeignKey("dbo.Roles", "FolderPrivacy_ID", "dbo.FolderPrivacies");
            DropForeignKey("dbo.SubRoles", "FolderPrivacy_ID", "dbo.FolderPrivacies");
            DropForeignKey("dbo.AspNetUsers", "MeetingPrivacy_ID", "dbo.MeetingPrivacies");
            DropForeignKey("dbo.AspNetUsers", "Meeting_ID", "dbo.Meetings");
            DropForeignKey("dbo.Meetings", "MeetingPrivacy_ID", "dbo.MeetingPrivacies");
            DropForeignKey("dbo.Roles", "MeetingPrivacy_ID", "dbo.MeetingPrivacies");
            DropForeignKey("dbo.SubRoles", "MeetingPrivacy_ID", "dbo.MeetingPrivacies");
            DropForeignKey("dbo.Meetings", "MeetingResource_ID", "dbo.MeetingResources");
            DropForeignKey("dbo.AspNetUsers", "Notification_ID", "dbo.Notifications");
            DropForeignKey("dbo.Roles", "Notification_ID", "dbo.Notifications");
            DropForeignKey("dbo.SubRoles", "Notification_ID", "dbo.Notifications");
            DropForeignKey("dbo.AspNetUsers", "RSVP_ID", "dbo.RSVPs");
            DropIndex("dbo.Announcements", new[] { "AnnouncePrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "AnnouncePrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "SubRole_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "DeathPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "FolderGroupPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "FolderGroup_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "FolderPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "MeetingPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Meeting_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Notification_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "RSVP_ID" });
            DropIndex("dbo.Roles", new[] { "AnnouncePrivacy_ID" });
            DropIndex("dbo.Roles", new[] { "DeathPrivacy_ID" });
            DropIndex("dbo.Roles", new[] { "FolderGroup_ID" });
            DropIndex("dbo.Roles", new[] { "FolderGroupPrivacy_ID" });
            DropIndex("dbo.Roles", new[] { "FolderPrivacy_ID" });
            DropIndex("dbo.Roles", new[] { "MeetingPrivacy_ID" });
            DropIndex("dbo.Roles", new[] { "Notification_ID" });
            DropIndex("dbo.SubRoles", new[] { "AnnouncePrivacy_ID" });
            DropIndex("dbo.SubRoles", new[] { "DeathPrivacy_ID" });
            DropIndex("dbo.SubRoles", new[] { "FolderGroup_ID" });
            DropIndex("dbo.SubRoles", new[] { "FolderGroupPrivacy_ID" });
            DropIndex("dbo.SubRoles", new[] { "FolderPrivacy_ID" });
            DropIndex("dbo.SubRoles", new[] { "MeetingPrivacy_ID" });
            DropIndex("dbo.SubRoles", new[] { "Notification_ID" });
            DropIndex("dbo.Deaths", new[] { "DeathPrivacy_ID" });
            DropIndex("dbo.FolderGroups", new[] { "FolderGroupPrivacy_ID" });
            DropIndex("dbo.Folders", new[] { "FolderPrivacy_ID" });
            DropIndex("dbo.Meetings", new[] { "MeetingPrivacy_ID" });
            DropIndex("dbo.Meetings", new[] { "MeetingResource_ID" });
            DropColumn("dbo.Announcements", "AnnouncePrivacy_ID");
            DropColumn("dbo.AspNetUsers", "AnnouncePrivacy_ID");
            DropColumn("dbo.AspNetUsers", "SubRole_ID");
            DropColumn("dbo.AspNetUsers", "DeathPrivacy_ID");
            DropColumn("dbo.AspNetUsers", "FolderGroupPrivacy_ID");
            DropColumn("dbo.AspNetUsers", "FolderGroup_ID");
            DropColumn("dbo.AspNetUsers", "FolderPrivacy_ID");
            DropColumn("dbo.AspNetUsers", "MeetingPrivacy_ID");
            DropColumn("dbo.AspNetUsers", "Meeting_ID");
            DropColumn("dbo.AspNetUsers", "Notification_ID");
            DropColumn("dbo.AspNetUsers", "RSVP_ID");
            DropColumn("dbo.Deaths", "DeathPrivacy_ID");
            DropColumn("dbo.Folders", "FolderPrivacy_ID");
            DropTable("dbo.AnnouncePrivacies");
            DropTable("dbo.Roles");
            DropTable("dbo.SubRoles");
            DropTable("dbo.DeathPrivacies");
            DropTable("dbo.FolderGroupPrivacies");
            DropTable("dbo.FolderGroups");
            DropTable("dbo.FolderPrivacies");
            DropTable("dbo.Links");
            DropTable("dbo.MeetingPrivacies");
            DropTable("dbo.Meetings");
            DropTable("dbo.MeetingResources");
            DropTable("dbo.Notifications");
            DropTable("dbo.RSVPs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RSVPs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        didRespond = c.Boolean(nullable: false),
                        isAttending = c.Boolean(nullable: false),
                        Note = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        viewedNotification = c.Boolean(nullable: false),
                        isAttending = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(nullable: false),
                        TypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MeetingResources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MeetingID = c.Int(nullable: false),
                        FileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1000),
                        Date = c.DateTime(nullable: false),
                        Length = c.String(maxLength: 50),
                        Location = c.String(maxLength: 50),
                        Requirements = c.String(maxLength: 200),
                        isVisible = c.Boolean(nullable: false),
                        StaffLeadID = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        MeetingPrivacy_ID = c.Int(),
                        MeetingResource_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MeetingPrivacies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MeetingID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        SubRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        URL = c.String(nullable: false, maxLength: 250),
                        Visible = c.Int(nullable: false),
                        Group = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FolderPrivacies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FolderID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        SubRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FolderGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FolderID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        SubRoleID = c.Int(nullable: false),
                        FolderGroupPrivacy_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FolderGroupPrivacies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FolderID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        SubRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DeathPrivacies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        SubRoleID = c.Int(nullable: false),
                        DeathID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        roleName = c.String(nullable: false, maxLength: 200),
                        RoleID = c.Int(nullable: false),
                        AnnouncePrivacy_ID = c.Int(),
                        DeathPrivacy_ID = c.Int(),
                        FolderGroup_ID = c.Int(),
                        FolderGroupPrivacy_ID = c.Int(),
                        FolderPrivacy_ID = c.Int(),
                        MeetingPrivacy_ID = c.Int(),
                        Notification_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        AnnouncePrivacy_ID = c.Int(),
                        DeathPrivacy_ID = c.Int(),
                        FolderGroup_ID = c.Int(),
                        FolderGroupPrivacy_ID = c.Int(),
                        FolderPrivacy_ID = c.Int(),
                        MeetingPrivacy_ID = c.Int(),
                        Notification_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AnnouncePrivacies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AnnounceID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        SubRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Folders", "FolderPrivacy_ID", c => c.Int());
            AddColumn("dbo.Deaths", "DeathPrivacy_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "RSVP_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Notification_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Meeting_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "MeetingPrivacy_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FolderPrivacy_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FolderGroup_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FolderGroupPrivacy_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "DeathPrivacy_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "SubRole_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "AnnouncePrivacy_ID", c => c.Int());
            AddColumn("dbo.Announcements", "AnnouncePrivacy_ID", c => c.Int());
            CreateIndex("dbo.Meetings", "MeetingResource_ID");
            CreateIndex("dbo.Meetings", "MeetingPrivacy_ID");
            CreateIndex("dbo.Folders", "FolderPrivacy_ID");
            CreateIndex("dbo.FolderGroups", "FolderGroupPrivacy_ID");
            CreateIndex("dbo.Deaths", "DeathPrivacy_ID");
            CreateIndex("dbo.SubRoles", "Notification_ID");
            CreateIndex("dbo.SubRoles", "MeetingPrivacy_ID");
            CreateIndex("dbo.SubRoles", "FolderPrivacy_ID");
            CreateIndex("dbo.SubRoles", "FolderGroupPrivacy_ID");
            CreateIndex("dbo.SubRoles", "FolderGroup_ID");
            CreateIndex("dbo.SubRoles", "DeathPrivacy_ID");
            CreateIndex("dbo.SubRoles", "AnnouncePrivacy_ID");
            CreateIndex("dbo.Roles", "Notification_ID");
            CreateIndex("dbo.Roles", "MeetingPrivacy_ID");
            CreateIndex("dbo.Roles", "FolderPrivacy_ID");
            CreateIndex("dbo.Roles", "FolderGroupPrivacy_ID");
            CreateIndex("dbo.Roles", "FolderGroup_ID");
            CreateIndex("dbo.Roles", "DeathPrivacy_ID");
            CreateIndex("dbo.Roles", "AnnouncePrivacy_ID");
            CreateIndex("dbo.AspNetUsers", "RSVP_ID");
            CreateIndex("dbo.AspNetUsers", "Notification_ID");
            CreateIndex("dbo.AspNetUsers", "Meeting_ID");
            CreateIndex("dbo.AspNetUsers", "MeetingPrivacy_ID");
            CreateIndex("dbo.AspNetUsers", "FolderPrivacy_ID");
            CreateIndex("dbo.AspNetUsers", "FolderGroup_ID");
            CreateIndex("dbo.AspNetUsers", "FolderGroupPrivacy_ID");
            CreateIndex("dbo.AspNetUsers", "DeathPrivacy_ID");
            CreateIndex("dbo.AspNetUsers", "SubRole_ID");
            CreateIndex("dbo.AspNetUsers", "AnnouncePrivacy_ID");
            CreateIndex("dbo.Announcements", "AnnouncePrivacy_ID");
            AddForeignKey("dbo.AspNetUsers", "RSVP_ID", "dbo.RSVPs", "ID");
            AddForeignKey("dbo.SubRoles", "Notification_ID", "dbo.Notifications", "ID");
            AddForeignKey("dbo.Roles", "Notification_ID", "dbo.Notifications", "ID");
            AddForeignKey("dbo.AspNetUsers", "Notification_ID", "dbo.Notifications", "ID");
            AddForeignKey("dbo.Meetings", "MeetingResource_ID", "dbo.MeetingResources", "ID");
            AddForeignKey("dbo.SubRoles", "MeetingPrivacy_ID", "dbo.MeetingPrivacies", "ID");
            AddForeignKey("dbo.Roles", "MeetingPrivacy_ID", "dbo.MeetingPrivacies", "ID");
            AddForeignKey("dbo.Meetings", "MeetingPrivacy_ID", "dbo.MeetingPrivacies", "ID");
            AddForeignKey("dbo.AspNetUsers", "Meeting_ID", "dbo.Meetings", "ID");
            AddForeignKey("dbo.AspNetUsers", "MeetingPrivacy_ID", "dbo.MeetingPrivacies", "ID");
            AddForeignKey("dbo.SubRoles", "FolderPrivacy_ID", "dbo.FolderPrivacies", "ID");
            AddForeignKey("dbo.Roles", "FolderPrivacy_ID", "dbo.FolderPrivacies", "ID");
            AddForeignKey("dbo.Folders", "FolderPrivacy_ID", "dbo.FolderPrivacies", "ID");
            AddForeignKey("dbo.AspNetUsers", "FolderPrivacy_ID", "dbo.FolderPrivacies", "ID");
            AddForeignKey("dbo.SubRoles", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies", "ID");
            AddForeignKey("dbo.Roles", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies", "ID");
            AddForeignKey("dbo.FolderGroups", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies", "ID");
            AddForeignKey("dbo.SubRoles", "FolderGroup_ID", "dbo.FolderGroups", "ID");
            AddForeignKey("dbo.Roles", "FolderGroup_ID", "dbo.FolderGroups", "ID");
            AddForeignKey("dbo.AspNetUsers", "FolderGroup_ID", "dbo.FolderGroups", "ID");
            AddForeignKey("dbo.AspNetUsers", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies", "ID");
            AddForeignKey("dbo.SubRoles", "DeathPrivacy_ID", "dbo.DeathPrivacies", "ID");
            AddForeignKey("dbo.Roles", "DeathPrivacy_ID", "dbo.DeathPrivacies", "ID");
            AddForeignKey("dbo.Deaths", "DeathPrivacy_ID", "dbo.DeathPrivacies", "ID");
            AddForeignKey("dbo.AspNetUsers", "DeathPrivacy_ID", "dbo.DeathPrivacies", "ID");
            AddForeignKey("dbo.SubRoles", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies", "ID");
            AddForeignKey("dbo.AspNetUsers", "SubRole_ID", "dbo.SubRoles", "ID");
            AddForeignKey("dbo.Roles", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies", "ID");
            AddForeignKey("dbo.AspNetUsers", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies", "ID");
            AddForeignKey("dbo.Announcements", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies", "ID");
        }
    }
}

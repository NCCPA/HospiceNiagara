namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Announcement_ID", "dbo.Announcements");
            DropForeignKey("dbo.Users", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies");
            DropForeignKey("dbo.Users", "DeathPrivacy_ID", "dbo.DeathPrivacies");
            DropForeignKey("dbo.Users", "FolderGroup_ID", "dbo.FolderGroups");
            DropForeignKey("dbo.Users", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies");
            DropForeignKey("dbo.Users", "FolderPrivacy_ID", "dbo.FolderPrivacies");
            DropForeignKey("dbo.Users", "Meeting_ID", "dbo.Meetings");
            DropForeignKey("dbo.Users", "MeetingPrivacy_ID", "dbo.MeetingPrivacies");
            DropForeignKey("dbo.Users", "Notification_ID", "dbo.Notifications");
            DropForeignKey("dbo.Users", "RSVP_ID", "dbo.RSVPs");
            DropForeignKey("dbo.SubRoles", "UserSubRole_ID", "dbo.UserSubRoles");
            DropForeignKey("dbo.Users", "UserSubRole_ID", "dbo.UserSubRoles");
            DropIndex("dbo.Users", new[] { "Announcement_ID" });
            DropIndex("dbo.Users", new[] { "AnnouncePrivacy_ID" });
            DropIndex("dbo.Users", new[] { "DeathPrivacy_ID" });
            DropIndex("dbo.Users", new[] { "FolderGroup_ID" });
            DropIndex("dbo.Users", new[] { "FolderGroupPrivacy_ID" });
            DropIndex("dbo.Users", new[] { "FolderPrivacy_ID" });
            DropIndex("dbo.Users", new[] { "Meeting_ID" });
            DropIndex("dbo.Users", new[] { "MeetingPrivacy_ID" });
            DropIndex("dbo.Users", new[] { "Notification_ID" });
            DropIndex("dbo.Users", new[] { "RSVP_ID" });
            DropIndex("dbo.Users", new[] { "UserSubRole_ID" });
            DropIndex("dbo.SubRoles", new[] { "UserSubRole_ID" });
            CreateTable(
                "dbo.SubRoleApplicationUsers",
                c => new
                    {
                        SubRole_ID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SubRole_ID, t.ApplicationUser_Id })
                .ForeignKey("dbo.SubRoles", t => t.SubRole_ID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.SubRole_ID)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "Announcement_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "AnnouncePrivacy_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "DeathPrivacy_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FolderGroupPrivacy_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FolderGroup_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FolderPrivacy_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "MeetingPrivacy_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Meeting_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Notification_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "RSVP_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Announcement_ID");
            CreateIndex("dbo.AspNetUsers", "AnnouncePrivacy_ID");
            CreateIndex("dbo.AspNetUsers", "DeathPrivacy_ID");
            CreateIndex("dbo.AspNetUsers", "FolderGroupPrivacy_ID");
            CreateIndex("dbo.AspNetUsers", "FolderGroup_ID");
            CreateIndex("dbo.AspNetUsers", "FolderPrivacy_ID");
            CreateIndex("dbo.AspNetUsers", "MeetingPrivacy_ID");
            CreateIndex("dbo.AspNetUsers", "Meeting_ID");
            CreateIndex("dbo.AspNetUsers", "Notification_ID");
            CreateIndex("dbo.AspNetUsers", "RSVP_ID");
            AddForeignKey("dbo.AspNetUsers", "Announcement_ID", "dbo.Announcements", "ID");
            AddForeignKey("dbo.AspNetUsers", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies", "ID");
            AddForeignKey("dbo.AspNetUsers", "DeathPrivacy_ID", "dbo.DeathPrivacies", "ID");
            AddForeignKey("dbo.AspNetUsers", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies", "ID");
            AddForeignKey("dbo.AspNetUsers", "FolderGroup_ID", "dbo.FolderGroups", "ID");
            AddForeignKey("dbo.AspNetUsers", "FolderPrivacy_ID", "dbo.FolderPrivacies", "ID");
            AddForeignKey("dbo.AspNetUsers", "MeetingPrivacy_ID", "dbo.MeetingPrivacies", "ID");
            AddForeignKey("dbo.AspNetUsers", "Meeting_ID", "dbo.Meetings", "ID");
            AddForeignKey("dbo.AspNetUsers", "Notification_ID", "dbo.Notifications", "ID");
            AddForeignKey("dbo.AspNetUsers", "RSVP_ID", "dbo.RSVPs", "ID");
            DropColumn("dbo.SubRoles", "UserSubRole_ID");
            DropTable("dbo.Users");
            DropTable("dbo.UserSubRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserSubRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        SubRoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Announcement_ID = c.Int(),
                        AnnouncePrivacy_ID = c.Int(),
                        DeathPrivacy_ID = c.Int(),
                        FolderGroup_ID = c.Int(),
                        FolderGroupPrivacy_ID = c.Int(),
                        FolderPrivacy_ID = c.Int(),
                        Meeting_ID = c.Int(),
                        MeetingPrivacy_ID = c.Int(),
                        Notification_ID = c.Int(),
                        RSVP_ID = c.Int(),
                        UserSubRole_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.SubRoles", "UserSubRole_ID", c => c.Int());
            DropForeignKey("dbo.AspNetUsers", "RSVP_ID", "dbo.RSVPs");
            DropForeignKey("dbo.AspNetUsers", "Notification_ID", "dbo.Notifications");
            DropForeignKey("dbo.AspNetUsers", "Meeting_ID", "dbo.Meetings");
            DropForeignKey("dbo.AspNetUsers", "MeetingPrivacy_ID", "dbo.MeetingPrivacies");
            DropForeignKey("dbo.AspNetUsers", "FolderPrivacy_ID", "dbo.FolderPrivacies");
            DropForeignKey("dbo.AspNetUsers", "FolderGroup_ID", "dbo.FolderGroups");
            DropForeignKey("dbo.AspNetUsers", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies");
            DropForeignKey("dbo.AspNetUsers", "DeathPrivacy_ID", "dbo.DeathPrivacies");
            DropForeignKey("dbo.AspNetUsers", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies");
            DropForeignKey("dbo.AspNetUsers", "Announcement_ID", "dbo.Announcements");
            DropForeignKey("dbo.SubRoleApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubRoleApplicationUsers", "SubRole_ID", "dbo.SubRoles");
            DropIndex("dbo.SubRoleApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SubRoleApplicationUsers", new[] { "SubRole_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "RSVP_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Notification_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Meeting_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "MeetingPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "FolderPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "FolderGroup_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "FolderGroupPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "DeathPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "AnnouncePrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Announcement_ID" });
            DropColumn("dbo.AspNetUsers", "RSVP_ID");
            DropColumn("dbo.AspNetUsers", "Notification_ID");
            DropColumn("dbo.AspNetUsers", "Meeting_ID");
            DropColumn("dbo.AspNetUsers", "MeetingPrivacy_ID");
            DropColumn("dbo.AspNetUsers", "FolderPrivacy_ID");
            DropColumn("dbo.AspNetUsers", "FolderGroup_ID");
            DropColumn("dbo.AspNetUsers", "FolderGroupPrivacy_ID");
            DropColumn("dbo.AspNetUsers", "DeathPrivacy_ID");
            DropColumn("dbo.AspNetUsers", "AnnouncePrivacy_ID");
            DropColumn("dbo.AspNetUsers", "Announcement_ID");
            DropTable("dbo.SubRoleApplicationUsers");
            CreateIndex("dbo.SubRoles", "UserSubRole_ID");
            CreateIndex("dbo.Users", "UserSubRole_ID");
            CreateIndex("dbo.Users", "RSVP_ID");
            CreateIndex("dbo.Users", "Notification_ID");
            CreateIndex("dbo.Users", "MeetingPrivacy_ID");
            CreateIndex("dbo.Users", "Meeting_ID");
            CreateIndex("dbo.Users", "FolderPrivacy_ID");
            CreateIndex("dbo.Users", "FolderGroupPrivacy_ID");
            CreateIndex("dbo.Users", "FolderGroup_ID");
            CreateIndex("dbo.Users", "DeathPrivacy_ID");
            CreateIndex("dbo.Users", "AnnouncePrivacy_ID");
            CreateIndex("dbo.Users", "Announcement_ID");
            AddForeignKey("dbo.Users", "UserSubRole_ID", "dbo.UserSubRoles", "ID");
            AddForeignKey("dbo.SubRoles", "UserSubRole_ID", "dbo.UserSubRoles", "ID");
            AddForeignKey("dbo.Users", "RSVP_ID", "dbo.RSVPs", "ID");
            AddForeignKey("dbo.Users", "Notification_ID", "dbo.Notifications", "ID");
            AddForeignKey("dbo.Users", "MeetingPrivacy_ID", "dbo.MeetingPrivacies", "ID");
            AddForeignKey("dbo.Users", "Meeting_ID", "dbo.Meetings", "ID");
            AddForeignKey("dbo.Users", "FolderPrivacy_ID", "dbo.FolderPrivacies", "ID");
            AddForeignKey("dbo.Users", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies", "ID");
            AddForeignKey("dbo.Users", "FolderGroup_ID", "dbo.FolderGroups", "ID");
            AddForeignKey("dbo.Users", "DeathPrivacy_ID", "dbo.DeathPrivacies", "ID");
            AddForeignKey("dbo.Users", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies", "ID");
            AddForeignKey("dbo.Users", "Announcement_ID", "dbo.Announcements", "ID");
        }
    }
}

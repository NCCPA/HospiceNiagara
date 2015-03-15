namespace HospiceNiagara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnounceFiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AnnounceID = c.Int(nullable: false),
                        FileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1000),
                        isVisible = c.Boolean(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        AnnounceFile_ID = c.Int(),
                        AnnouncePrivacy_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AnnounceFiles", t => t.AnnounceFile_ID)
                .ForeignKey("dbo.AnnouncePrivacies", t => t.AnnouncePrivacy_ID)
                .Index(t => t.AnnounceFile_ID)
                .Index(t => t.AnnouncePrivacy_ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(),
                        PhoneExt = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsContact = c.Boolean(nullable: false),
                        CanCreateMeeting = c.Boolean(nullable: false),
                        Position = c.String(),
                        PositionDescription = c.String(),
                        Bio = c.String(),
                        ProfilePicture = c.Binary(nullable: false),
                        MimeType = c.String(nullable: false, maxLength: 256),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Announcement_ID = c.Int(),
                        AnnouncePrivacy_ID = c.Int(),
                        SubRole_ID = c.Int(),
                        DeathPrivacy_ID = c.Int(),
                        FolderGroupPrivacy_ID = c.Int(),
                        FolderGroup_ID = c.Int(),
                        FolderPrivacy_ID = c.Int(),
                        MeetingPrivacy_ID = c.Int(),
                        Meeting_ID = c.Int(),
                        Notification_ID = c.Int(),
                        RSVP_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Announcements", t => t.Announcement_ID)
                .ForeignKey("dbo.AnnouncePrivacies", t => t.AnnouncePrivacy_ID)
                .ForeignKey("dbo.SubRoles", t => t.SubRole_ID)
                .ForeignKey("dbo.DeathPrivacies", t => t.DeathPrivacy_ID)
                .ForeignKey("dbo.FolderGroupPrivacies", t => t.FolderGroupPrivacy_ID)
                .ForeignKey("dbo.FolderGroups", t => t.FolderGroup_ID)
                .ForeignKey("dbo.FolderPrivacies", t => t.FolderPrivacy_ID)
                .ForeignKey("dbo.MeetingPrivacies", t => t.MeetingPrivacy_ID)
                .ForeignKey("dbo.Meetings", t => t.Meeting_ID)
                .ForeignKey("dbo.Notifications", t => t.Notification_ID)
                .ForeignKey("dbo.RSVPs", t => t.RSVP_ID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Announcement_ID)
                .Index(t => t.AnnouncePrivacy_ID)
                .Index(t => t.SubRole_ID)
                .Index(t => t.DeathPrivacy_ID)
                .Index(t => t.FolderGroupPrivacy_ID)
                .Index(t => t.FolderGroup_ID)
                .Index(t => t.FolderPrivacy_ID)
                .Index(t => t.MeetingPrivacy_ID)
                .Index(t => t.Meeting_ID)
                .Index(t => t.Notification_ID)
                .Index(t => t.RSVP_ID);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AnnouncePrivacies", t => t.AnnouncePrivacy_ID)
                .ForeignKey("dbo.DeathPrivacies", t => t.DeathPrivacy_ID)
                .ForeignKey("dbo.FolderGroups", t => t.FolderGroup_ID)
                .ForeignKey("dbo.FolderGroupPrivacies", t => t.FolderGroupPrivacy_ID)
                .ForeignKey("dbo.FolderPrivacies", t => t.FolderPrivacy_ID)
                .ForeignKey("dbo.MeetingPrivacies", t => t.MeetingPrivacy_ID)
                .ForeignKey("dbo.Notifications", t => t.Notification_ID)
                .Index(t => t.AnnouncePrivacy_ID)
                .Index(t => t.DeathPrivacy_ID)
                .Index(t => t.FolderGroup_ID)
                .Index(t => t.FolderGroupPrivacy_ID)
                .Index(t => t.FolderPrivacy_ID)
                .Index(t => t.MeetingPrivacy_ID)
                .Index(t => t.Notification_ID);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AnnouncePrivacies", t => t.AnnouncePrivacy_ID)
                .ForeignKey("dbo.DeathPrivacies", t => t.DeathPrivacy_ID)
                .ForeignKey("dbo.FolderGroups", t => t.FolderGroup_ID)
                .ForeignKey("dbo.FolderGroupPrivacies", t => t.FolderGroupPrivacy_ID)
                .ForeignKey("dbo.FolderPrivacies", t => t.FolderPrivacy_ID)
                .ForeignKey("dbo.MeetingPrivacies", t => t.MeetingPrivacy_ID)
                .ForeignKey("dbo.Notifications", t => t.Notification_ID)
                .Index(t => t.AnnouncePrivacy_ID)
                .Index(t => t.DeathPrivacy_ID)
                .Index(t => t.FolderGroup_ID)
                .Index(t => t.FolderGroupPrivacy_ID)
                .Index(t => t.FolderPrivacy_ID)
                .Index(t => t.MeetingPrivacy_ID)
                .Index(t => t.Notification_ID);
            
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
                "dbo.Deaths",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(maxLength: 100),
                        Note = c.String(maxLength: 200),
                        Visible = c.Int(nullable: false),
                        CreatedByID = c.Int(nullable: false),
                        DeathPrivacy_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DeathPrivacies", t => t.DeathPrivacy_ID)
                .Index(t => t.DeathPrivacy_ID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FolderID = c.Int(nullable: false),
                        FileContent = c.Binary(nullable: false),
                        MimeType = c.String(nullable: false, maxLength: 256),
                        FileName = c.String(nullable: false, maxLength: 100),
                        FileDescription = c.String(maxLength: 100),
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FolderGroupPrivacies", t => t.FolderGroupPrivacy_ID)
                .Index(t => t.FolderGroupPrivacy_ID);
            
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
                "dbo.Folders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false, maxLength: 100),
                        FileDescription = c.String(maxLength: 100),
                        FolderPrivacy_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FolderPrivacies", t => t.FolderPrivacy_ID)
                .Index(t => t.FolderPrivacy_ID);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MeetingPrivacies", t => t.MeetingPrivacy_ID)
                .ForeignKey("dbo.MeetingResources", t => t.MeetingResource_ID)
                .Index(t => t.MeetingPrivacy_ID)
                .Index(t => t.MeetingResource_ID);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "RSVP_ID", "dbo.RSVPs");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SubRoles", "Notification_ID", "dbo.Notifications");
            DropForeignKey("dbo.Roles", "Notification_ID", "dbo.Notifications");
            DropForeignKey("dbo.AspNetUsers", "Notification_ID", "dbo.Notifications");
            DropForeignKey("dbo.Meetings", "MeetingResource_ID", "dbo.MeetingResources");
            DropForeignKey("dbo.SubRoles", "MeetingPrivacy_ID", "dbo.MeetingPrivacies");
            DropForeignKey("dbo.Roles", "MeetingPrivacy_ID", "dbo.MeetingPrivacies");
            DropForeignKey("dbo.Meetings", "MeetingPrivacy_ID", "dbo.MeetingPrivacies");
            DropForeignKey("dbo.AspNetUsers", "Meeting_ID", "dbo.Meetings");
            DropForeignKey("dbo.AspNetUsers", "MeetingPrivacy_ID", "dbo.MeetingPrivacies");
            DropForeignKey("dbo.SubRoles", "FolderPrivacy_ID", "dbo.FolderPrivacies");
            DropForeignKey("dbo.Roles", "FolderPrivacy_ID", "dbo.FolderPrivacies");
            DropForeignKey("dbo.Folders", "FolderPrivacy_ID", "dbo.FolderPrivacies");
            DropForeignKey("dbo.AspNetUsers", "FolderPrivacy_ID", "dbo.FolderPrivacies");
            DropForeignKey("dbo.SubRoles", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies");
            DropForeignKey("dbo.Roles", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies");
            DropForeignKey("dbo.FolderGroups", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies");
            DropForeignKey("dbo.SubRoles", "FolderGroup_ID", "dbo.FolderGroups");
            DropForeignKey("dbo.Roles", "FolderGroup_ID", "dbo.FolderGroups");
            DropForeignKey("dbo.AspNetUsers", "FolderGroup_ID", "dbo.FolderGroups");
            DropForeignKey("dbo.AspNetUsers", "FolderGroupPrivacy_ID", "dbo.FolderGroupPrivacies");
            DropForeignKey("dbo.SubRoles", "DeathPrivacy_ID", "dbo.DeathPrivacies");
            DropForeignKey("dbo.Roles", "DeathPrivacy_ID", "dbo.DeathPrivacies");
            DropForeignKey("dbo.Deaths", "DeathPrivacy_ID", "dbo.DeathPrivacies");
            DropForeignKey("dbo.AspNetUsers", "DeathPrivacy_ID", "dbo.DeathPrivacies");
            DropForeignKey("dbo.SubRoles", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies");
            DropForeignKey("dbo.AspNetUsers", "SubRole_ID", "dbo.SubRoles");
            DropForeignKey("dbo.Roles", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies");
            DropForeignKey("dbo.AspNetUsers", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies");
            DropForeignKey("dbo.Announcements", "AnnouncePrivacy_ID", "dbo.AnnouncePrivacies");
            DropForeignKey("dbo.Announcements", "AnnounceFile_ID", "dbo.AnnounceFiles");
            DropForeignKey("dbo.AspNetUsers", "Announcement_ID", "dbo.Announcements");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Meetings", new[] { "MeetingResource_ID" });
            DropIndex("dbo.Meetings", new[] { "MeetingPrivacy_ID" });
            DropIndex("dbo.Folders", new[] { "FolderPrivacy_ID" });
            DropIndex("dbo.FolderGroups", new[] { "FolderGroupPrivacy_ID" });
            DropIndex("dbo.Deaths", new[] { "DeathPrivacy_ID" });
            DropIndex("dbo.SubRoles", new[] { "Notification_ID" });
            DropIndex("dbo.SubRoles", new[] { "MeetingPrivacy_ID" });
            DropIndex("dbo.SubRoles", new[] { "FolderPrivacy_ID" });
            DropIndex("dbo.SubRoles", new[] { "FolderGroupPrivacy_ID" });
            DropIndex("dbo.SubRoles", new[] { "FolderGroup_ID" });
            DropIndex("dbo.SubRoles", new[] { "DeathPrivacy_ID" });
            DropIndex("dbo.SubRoles", new[] { "AnnouncePrivacy_ID" });
            DropIndex("dbo.Roles", new[] { "Notification_ID" });
            DropIndex("dbo.Roles", new[] { "MeetingPrivacy_ID" });
            DropIndex("dbo.Roles", new[] { "FolderPrivacy_ID" });
            DropIndex("dbo.Roles", new[] { "FolderGroupPrivacy_ID" });
            DropIndex("dbo.Roles", new[] { "FolderGroup_ID" });
            DropIndex("dbo.Roles", new[] { "DeathPrivacy_ID" });
            DropIndex("dbo.Roles", new[] { "AnnouncePrivacy_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "RSVP_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Notification_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Meeting_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "MeetingPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "FolderPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "FolderGroup_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "FolderGroupPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "DeathPrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "SubRole_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "AnnouncePrivacy_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "Announcement_ID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Announcements", new[] { "AnnouncePrivacy_ID" });
            DropIndex("dbo.Announcements", new[] { "AnnounceFile_ID" });
            DropTable("dbo.RSVPs");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Notifications");
            DropTable("dbo.MeetingResources");
            DropTable("dbo.Meetings");
            DropTable("dbo.MeetingPrivacies");
            DropTable("dbo.Links");
            DropTable("dbo.Folders");
            DropTable("dbo.FolderPrivacies");
            DropTable("dbo.FolderGroups");
            DropTable("dbo.FolderGroupPrivacies");
            DropTable("dbo.Files");
            DropTable("dbo.Deaths");
            DropTable("dbo.DeathPrivacies");
            DropTable("dbo.SubRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.AnnouncePrivacies");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Announcements");
            DropTable("dbo.AnnounceFiles");
        }
    }
}

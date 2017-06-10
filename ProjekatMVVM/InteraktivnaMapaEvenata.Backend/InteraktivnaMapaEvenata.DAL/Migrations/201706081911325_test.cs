namespace InteraktivnaMapaEvenata.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        IsBanned = c.Boolean(nullable: false),
                        ProfileImage = c.Binary(),
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        QRScanner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.QRScanners", t => t.QRScanner_Id)
                .Index(t => t.UserId)
                .Index(t => t.QRScanner_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        QRScanner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.QRScanners", t => t.QRScanner_Id)
                .Index(t => t.UserId)
                .Index(t => t.QRScanner_Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        SourceId = c.Int(nullable: false),
                        DestinationUserId = c.String(nullable: false, maxLength: 128),
                        Text = c.String(),
                        LongText = c.String(),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.AspNetUsers", t => t.DestinationUserId)
                .ForeignKey("dbo.Owners", t => t.SourceId)
                .Index(t => t.SourceId)
                .Index(t => t.DestinationUserId);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(nullable: false),
                        SelectedTierId = c.Int(),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OwnerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.PaymentTiers", t => t.SelectedTierId)
                .Index(t => t.SelectedTierId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        EventStateId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        PromotionId = c.Int(),
                        OwnerId = c.Int(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.EventStates", t => t.EventStateId)
                .ForeignKey("dbo.Owners", t => t.OwnerId)
                .ForeignKey("dbo.Promotions", t => t.PromotionId)
                .Index(t => t.EventStateId)
                .Index(t => t.PromotionId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.EventStates",
                c => new
                    {
                        EventStateId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EventStateId);
            
            CreateTable(
                "dbo.Flags",
                c => new
                    {
                        FlagId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        FlaggedStateId = c.Int(nullable: false),
                        EventFlagId = c.Int(),
                        FlaggedEventId = c.Int(),
                        OwnerFlagId = c.Int(),
                        FlaggedOwnerId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Owner_OwnerId = c.Int(),
                        Owner_OwnerId1 = c.Int(),
                    })
                .PrimaryKey(t => t.FlagId)
                .ForeignKey("dbo.Events", t => t.FlaggedEventId)
                .ForeignKey("dbo.Owners", t => t.FlaggedOwnerId)
                .ForeignKey("dbo.Owners", t => t.Owner_OwnerId)
                .ForeignKey("dbo.Owners", t => t.Owner_OwnerId1)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.FlagStates", t => t.FlaggedStateId)
                .Index(t => t.CustomerId)
                .Index(t => t.FlaggedStateId)
                .Index(t => t.FlaggedEventId)
                .Index(t => t.FlaggedOwnerId)
                .Index(t => t.Owner_OwnerId)
                .Index(t => t.Owner_OwnerId1);
            
            CreateTable(
                "dbo.FlagStates",
                c => new
                    {
                        FlagStateId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.FlagStateId);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        PromotionId = c.Int(nullable: false, identity: true),
                        CustomerLimit = c.Int(),
                        OwnerId = c.Int(),
                        Description = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PromotionId)
                .ForeignKey("dbo.Owners", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.QRScanners",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CurrentPromotionId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Promotions", t => t.CurrentPromotionId)
                .ForeignKey("dbo.Owners", t => t.OwnerId)
                .Index(t => t.CurrentPromotionId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        QRScanner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.QRScanners", t => t.QRScanner_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.QRScanner_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.PaymentTiers",
                c => new
                    {
                        PaymentTierId = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Description = c.String(nullable: false),
                        Label = c.String(nullable: false),
                        Duration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentTierId);
            
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
                "dbo.EventCustomers",
                c => new
                    {
                        Event_EventId = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_EventId, t.Customer_CustomerId })
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Event_EventId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.PromotionCustomers",
                c => new
                    {
                        Promotion_PromotionId = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Promotion_PromotionId, t.Customer_CustomerId })
                .ForeignKey("dbo.Promotions", t => t.Promotion_PromotionId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Promotion_PromotionId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.TagEvents",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Event_EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Event_EventId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Event_EventId);
            
            CreateTable(
                "dbo.OwnerCustomers",
                c => new
                    {
                        Owner_OwnerId = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Owner_OwnerId, t.Customer_CustomerId })
                .ForeignKey("dbo.Owners", t => t.Owner_OwnerId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Owner_OwnerId)
                .Index(t => t.Customer_CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Customers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Flags", "FlaggedStateId", "dbo.FlagStates");
            DropForeignKey("dbo.Flags", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Owners", "SelectedTierId", "dbo.PaymentTiers");
            DropForeignKey("dbo.Flags", "Owner_OwnerId1", "dbo.Owners");
            DropForeignKey("dbo.Notifications", "SourceId", "dbo.Owners");
            DropForeignKey("dbo.OwnerCustomers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OwnerCustomers", "Owner_OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Flags", "Owner_OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Flags", "FlaggedOwnerId", "dbo.Owners");
            DropForeignKey("dbo.TagEvents", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.TagEvents", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.AspNetUserRoles", "QRScanner_Id", "dbo.QRScanners");
            DropForeignKey("dbo.QRScanners", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.AspNetUserLogins", "QRScanner_Id", "dbo.QRScanners");
            DropForeignKey("dbo.QRScanners", "CurrentPromotionId", "dbo.Promotions");
            DropForeignKey("dbo.AspNetUserClaims", "QRScanner_Id", "dbo.QRScanners");
            DropForeignKey("dbo.Promotions", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Events", "PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.PromotionCustomers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PromotionCustomers", "Promotion_PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.Events", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Flags", "FlaggedEventId", "dbo.Events");
            DropForeignKey("dbo.Events", "EventStateId", "dbo.EventStates");
            DropForeignKey("dbo.EventCustomers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.EventCustomers", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.Owners", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "DestinationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.OwnerCustomers", new[] { "Customer_CustomerId" });
            DropIndex("dbo.OwnerCustomers", new[] { "Owner_OwnerId" });
            DropIndex("dbo.TagEvents", new[] { "Event_EventId" });
            DropIndex("dbo.TagEvents", new[] { "Tag_TagId" });
            DropIndex("dbo.PromotionCustomers", new[] { "Customer_CustomerId" });
            DropIndex("dbo.PromotionCustomers", new[] { "Promotion_PromotionId" });
            DropIndex("dbo.EventCustomers", new[] { "Customer_CustomerId" });
            DropIndex("dbo.EventCustomers", new[] { "Event_EventId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "QRScanner_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.QRScanners", new[] { "OwnerId" });
            DropIndex("dbo.QRScanners", new[] { "CurrentPromotionId" });
            DropIndex("dbo.Promotions", new[] { "OwnerId" });
            DropIndex("dbo.Flags", new[] { "Owner_OwnerId1" });
            DropIndex("dbo.Flags", new[] { "Owner_OwnerId" });
            DropIndex("dbo.Flags", new[] { "FlaggedOwnerId" });
            DropIndex("dbo.Flags", new[] { "FlaggedEventId" });
            DropIndex("dbo.Flags", new[] { "FlaggedStateId" });
            DropIndex("dbo.Flags", new[] { "CustomerId" });
            DropIndex("dbo.Events", new[] { "OwnerId" });
            DropIndex("dbo.Events", new[] { "PromotionId" });
            DropIndex("dbo.Events", new[] { "EventStateId" });
            DropIndex("dbo.Owners", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Owners", new[] { "SelectedTierId" });
            DropIndex("dbo.Notifications", new[] { "DestinationUserId" });
            DropIndex("dbo.Notifications", new[] { "SourceId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "QRScanner_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "QRScanner_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Customers", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Customers", new[] { "ApplicationUser_Id" });
            DropTable("dbo.OwnerCustomers");
            DropTable("dbo.TagEvents");
            DropTable("dbo.PromotionCustomers");
            DropTable("dbo.EventCustomers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PaymentTiers");
            DropTable("dbo.Tags");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.QRScanners");
            DropTable("dbo.Promotions");
            DropTable("dbo.FlagStates");
            DropTable("dbo.Flags");
            DropTable("dbo.EventStates");
            DropTable("dbo.Events");
            DropTable("dbo.Owners");
            DropTable("dbo.Notifications");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Customers");
        }
    }
}

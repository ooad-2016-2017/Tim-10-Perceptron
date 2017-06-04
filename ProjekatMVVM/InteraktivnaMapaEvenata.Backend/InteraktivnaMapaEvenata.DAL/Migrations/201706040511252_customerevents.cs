namespace InteraktivnaMapaEvenata.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerevents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Events", new[] { "Customer_CustomerId" });
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
            
            DropColumn("dbo.Events", "Customer_CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Customer_CustomerId", c => c.Int());
            DropForeignKey("dbo.EventCustomers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.EventCustomers", "Event_EventId", "dbo.Events");
            DropIndex("dbo.EventCustomers", new[] { "Customer_CustomerId" });
            DropIndex("dbo.EventCustomers", new[] { "Event_EventId" });
            DropTable("dbo.EventCustomers");
            CreateIndex("dbo.Events", "Customer_CustomerId");
            AddForeignKey("dbo.Events", "Customer_CustomerId", "dbo.Customers", "CustomerId");
        }
    }
}

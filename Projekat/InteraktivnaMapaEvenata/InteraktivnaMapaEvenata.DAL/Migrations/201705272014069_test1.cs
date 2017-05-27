namespace InteraktivnaMapaEvenata.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Events", new[] { "PromotionId" });
            DropIndex("dbo.Owners", new[] { "SelectedTierId" });
            DropIndex("dbo.Promotions", new[] { "OwnerId" });
            AlterColumn("dbo.Events", "PromotionId", c => c.Int());
            AlterColumn("dbo.Owners", "SelectedTierId", c => c.Int());
            AlterColumn("dbo.Promotions", "OwnerId", c => c.Int());
            CreateIndex("dbo.Events", "PromotionId");
            CreateIndex("dbo.Owners", "SelectedTierId");
            CreateIndex("dbo.Promotions", "OwnerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Promotions", new[] { "OwnerId" });
            DropIndex("dbo.Owners", new[] { "SelectedTierId" });
            DropIndex("dbo.Events", new[] { "PromotionId" });
            AlterColumn("dbo.Promotions", "OwnerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Owners", "SelectedTierId", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "PromotionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Promotions", "OwnerId");
            CreateIndex("dbo.Owners", "SelectedTierId");
            CreateIndex("dbo.Events", "PromotionId");
        }
    }
}

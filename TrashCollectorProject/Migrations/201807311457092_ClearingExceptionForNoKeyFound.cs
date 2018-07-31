namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClearingExceptionForNoKeyFound : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickupDates",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        PickupDates = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PickupDates");
        }
    }
}

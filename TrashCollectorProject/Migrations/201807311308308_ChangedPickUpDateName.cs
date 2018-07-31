namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPickUpDateName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "OneTimePickupDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "PickupDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PickupDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "OneTimePickupDate");
        }
    }
}

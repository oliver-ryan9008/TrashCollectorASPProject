namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedWeeklyPickupDateForCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "WeeklyPickupDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "WeeklyPickupDay");
        }
    }
}

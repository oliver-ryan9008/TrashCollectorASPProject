namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedWeeklyPickupDayToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "WeeklyPickupDay", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "WeeklyPickupDay", c => c.DateTime(nullable: false));
        }
    }
}

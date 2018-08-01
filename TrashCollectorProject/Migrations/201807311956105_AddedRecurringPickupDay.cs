namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRecurringPickupDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PickupDates", "RecurringPickupDayOfWeek", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PickupDates", "RecurringPickupDayOfWeek");
        }
    }
}

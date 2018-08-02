namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEmployeeFields : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.PickupDates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PickupDates",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        PickupDates = c.DateTime(nullable: false),
                        RecurringPickupDayOfWeek = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
    }
}

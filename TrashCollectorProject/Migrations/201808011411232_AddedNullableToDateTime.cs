namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNullableToDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "OneTimePickupDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "OneTimePickupDate", c => c.DateTime(nullable: false));
        }
    }
}

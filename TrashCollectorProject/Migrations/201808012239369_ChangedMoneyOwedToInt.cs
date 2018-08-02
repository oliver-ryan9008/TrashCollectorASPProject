namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMoneyOwedToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "MoneyOwed", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "MoneyOwed", c => c.String());
        }
    }
}

namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDisplayMoneyOwedMethod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "MoneyOwed", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "MoneyOwed", c => c.Double(nullable: false));
        }
    }
}

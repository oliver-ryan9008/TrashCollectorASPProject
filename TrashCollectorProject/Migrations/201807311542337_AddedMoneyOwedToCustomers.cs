namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoneyOwedToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MoneyOwed", c => c.Double(nullable: false));
            DropColumn("dbo.Customers", "Wallet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Wallet", c => c.Double(nullable: false));
            DropColumn("dbo.Customers", "MoneyOwed");
        }
    }
}

namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedCustomerAndEmployeeModels : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TrashCollectors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TrashCollectors",
                c => new
                    {
                        EmailAddress = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EmailAddress);
            
        }
    }
}

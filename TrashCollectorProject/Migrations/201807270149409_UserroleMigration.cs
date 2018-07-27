namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserroleMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrashCollectors",
                c => new
                    {
                        EmailAddress = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EmailAddress);
            
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserRole");
            DropTable("dbo.TrashCollectors");
        }
    }
}

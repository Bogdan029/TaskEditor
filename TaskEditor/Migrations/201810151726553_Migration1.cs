namespace TaskEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Created", c => c.String());
            AddColumn("dbo.Tasks", "Modificated", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Surname");
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Tasks", "Modificated");
            DropColumn("dbo.Tasks", "Created");
        }
    }
}

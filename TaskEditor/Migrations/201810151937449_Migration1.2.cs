namespace TaskEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tasks", "Created");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Created", c => c.DateTime(nullable: false));
        }
    }
}

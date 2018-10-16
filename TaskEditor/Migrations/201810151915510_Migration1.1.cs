namespace TaskEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "Created", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tasks", "Modificated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Modificated", c => c.String());
            AlterColumn("dbo.Tasks", "Created", c => c.String());
        }
    }
}

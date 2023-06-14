namespace VeganProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class veganmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VeganTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VeganTypes", "Name");
        }
    }
}

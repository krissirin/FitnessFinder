namespace FitnessClassFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocalArea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassSchedules", "LocalArea", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassSchedules", "LocalArea");
        }
    }
}

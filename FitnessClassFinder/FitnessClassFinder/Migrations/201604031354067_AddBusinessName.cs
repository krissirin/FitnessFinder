namespace FitnessClassFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBusinessName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassSchedules", "BusinessName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClassSchedules", "BusinessName");
        }
    }
}

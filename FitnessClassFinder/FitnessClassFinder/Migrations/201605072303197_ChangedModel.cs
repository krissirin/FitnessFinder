namespace FitnessClassFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructors", "Email", c => c.String());
            AddColumn("dbo.Instructors", "Phone", c => c.String());
            DropColumn("dbo.Instructors", "EmailAddress");
            DropColumn("dbo.Instructors", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instructors", "PhoneNumber", c => c.String());
            AddColumn("dbo.Instructors", "EmailAddress", c => c.String());
            DropColumn("dbo.Instructors", "Phone");
            DropColumn("dbo.Instructors", "Email");
        }
    }
}

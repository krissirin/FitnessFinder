namespace FitnessClassFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Participants", "EmailAdress", c => c.String());
            AlterColumn("dbo.Instructors", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instructors", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Participants", "EmailAdress", c => c.String(nullable: false));
        }
    }
}

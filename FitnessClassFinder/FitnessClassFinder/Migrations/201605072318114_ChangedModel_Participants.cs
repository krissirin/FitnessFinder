namespace FitnessClassFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedModel_Participants : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "Email", c => c.String());
            DropColumn("dbo.Participants", "EmailAdress");
            DropColumn("dbo.Participants", "PhoneNumber");
            DropColumn("dbo.Participants", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Participants", "Status", c => c.String());
            AddColumn("dbo.Participants", "PhoneNumber", c => c.String());
            AddColumn("dbo.Participants", "EmailAdress", c => c.String());
            DropColumn("dbo.Participants", "Email");
        }
    }
}

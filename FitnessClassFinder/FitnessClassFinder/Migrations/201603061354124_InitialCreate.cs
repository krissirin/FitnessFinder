namespace FitnessClassFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        SelectCategory = c.Int(nullable: false),
                        CategoryDescription = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.ClassSchedules",
                c => new
                    {
                        FitnessClassID = c.Int(nullable: false, identity: true),
                        SelectArea = c.Int(nullable: false),
                        ClassName = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        StartTime = c.String(),
                        Duration = c.String(),
                        Status = c.String(),
                        MaxEnroll = c.Int(nullable: false),
                        CategoryID = c.Int(),
                        Instructor_InstructorID = c.Int(),
                        RegistrationRecord_RecordID = c.Int(),
                        Participant_ParticipantID = c.Int(),
                    })
                .PrimaryKey(t => t.FitnessClassID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Instructors", t => t.Instructor_InstructorID)
                .ForeignKey("dbo.RegistrationRecords", t => t.RegistrationRecord_RecordID)
                .ForeignKey("dbo.Participants", t => t.Participant_ParticipantID)
                .Index(t => t.CategoryID)
                .Index(t => t.Instructor_InstructorID)
                .Index(t => t.RegistrationRecord_RecordID)
                .Index(t => t.Participant_ParticipantID);
            
            CreateTable(
                "dbo.EditUserViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        Name = c.String(maxLength: 20),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 20),
                        Town = c.String(),
                        County = c.String(),
                        Postcode = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        InstructorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        FitnessClassID = c.Int(),
                    })
                .PrimaryKey(t => t.InstructorID);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ParticipantID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        RecordID = c.Int(),
                    })
                .PrimaryKey(t => t.ParticipantID)
                .ForeignKey("dbo.RegistrationRecords", t => t.RecordID)
                .Index(t => t.RecordID);
            
            CreateTable(
                "dbo.RegistrationRecords",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        FitnessClassID = c.Int(nullable: false),
                        ParticipantID = c.Int(nullable: false),
                        RegistraionDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RecordID);
            
            CreateTable(
                "dbo.RoleViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassSchedules", "Participant_ParticipantID", "dbo.Participants");
            DropForeignKey("dbo.Participants", "RecordID", "dbo.RegistrationRecords");
            DropForeignKey("dbo.ClassSchedules", "RegistrationRecord_RecordID", "dbo.RegistrationRecords");
            DropForeignKey("dbo.ClassSchedules", "Instructor_InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.ClassSchedules", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Participants", new[] { "RecordID" });
            DropIndex("dbo.ClassSchedules", new[] { "Participant_ParticipantID" });
            DropIndex("dbo.ClassSchedules", new[] { "RegistrationRecord_RecordID" });
            DropIndex("dbo.ClassSchedules", new[] { "Instructor_InstructorID" });
            DropIndex("dbo.ClassSchedules", new[] { "CategoryID" });
            DropTable("dbo.RoleViewModels");
            DropTable("dbo.RegistrationRecords");
            DropTable("dbo.Participants");
            DropTable("dbo.Instructors");
            DropTable("dbo.EditUserViewModels");
            DropTable("dbo.ClassSchedules");
            DropTable("dbo.Categories");
        }
    }
}

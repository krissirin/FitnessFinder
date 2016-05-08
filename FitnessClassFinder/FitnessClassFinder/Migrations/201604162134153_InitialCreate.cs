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
                        LocalArea = c.String(),
                        ClassName = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false),
                        BusinessName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        StartTime = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        MaxEnroll = c.Int(nullable: false),
                        Fee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(),
                        Participant_ParticipantID = c.Int(),
                        Instructor_InstructorID = c.Int(),
                    })
                .PrimaryKey(t => t.FitnessClassID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Participants", t => t.Participant_ParticipantID)
                .ForeignKey("dbo.Instructors", t => t.Instructor_InstructorID)
                .Index(t => t.CategoryID)
                .Index(t => t.Participant_ParticipantID)
                .Index(t => t.Instructor_InstructorID);
            
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
                "dbo.RegistrationRecordClassSchedules",
                c => new
                    {
                        RegistrationRecord_RecordID = c.Int(nullable: false),
                        ClassSchedule_FitnessClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RegistrationRecord_RecordID, t.ClassSchedule_FitnessClassID })
                .ForeignKey("dbo.RegistrationRecords", t => t.RegistrationRecord_RecordID, cascadeDelete: true)
                .ForeignKey("dbo.ClassSchedules", t => t.ClassSchedule_FitnessClassID, cascadeDelete: true)
                .Index(t => t.RegistrationRecord_RecordID)
                .Index(t => t.ClassSchedule_FitnessClassID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassSchedules", "Instructor_InstructorID", "dbo.Instructors");
            DropForeignKey("dbo.RegistrationRecordClassSchedules", "ClassSchedule_FitnessClassID", "dbo.ClassSchedules");
            DropForeignKey("dbo.RegistrationRecordClassSchedules", "RegistrationRecord_RecordID", "dbo.RegistrationRecords");
            DropForeignKey("dbo.ClassSchedules", "Participant_ParticipantID", "dbo.Participants");
            DropForeignKey("dbo.Participants", "RecordID", "dbo.RegistrationRecords");
            DropForeignKey("dbo.ClassSchedules", "CategoryID", "dbo.Categories");
            DropIndex("dbo.RegistrationRecordClassSchedules", new[] { "ClassSchedule_FitnessClassID" });
            DropIndex("dbo.RegistrationRecordClassSchedules", new[] { "RegistrationRecord_RecordID" });
            DropIndex("dbo.Participants", new[] { "RecordID" });
            DropIndex("dbo.ClassSchedules", new[] { "Instructor_InstructorID" });
            DropIndex("dbo.ClassSchedules", new[] { "Participant_ParticipantID" });
            DropIndex("dbo.ClassSchedules", new[] { "CategoryID" });
            DropTable("dbo.RegistrationRecordClassSchedules");
            DropTable("dbo.Instructors");
            DropTable("dbo.Participants");
            DropTable("dbo.RegistrationRecords");
            DropTable("dbo.ClassSchedules");
            DropTable("dbo.Categories");
        }
    }
}

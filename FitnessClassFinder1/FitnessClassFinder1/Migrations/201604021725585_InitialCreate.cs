namespace FitnessClassFinder1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingCart",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ScheduleID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Schedule", t => t.ScheduleID, cascadeDelete: true)
                .Index(t => t.ScheduleID);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        ScheduleID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        InstructorID = c.Int(nullable: false),
                        DublinArea = c.String(nullable: false),
                        ClassName = c.String(nullable: false),
                        GymName = c.String(nullable: false),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        StartTime = c.String(),
                        MaxEnroll = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ScheduleID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Instructor", t => t.InstructorID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.RegistrationRecord",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        ScheduleID = c.Int(nullable: false),
                        ParticipantID = c.Int(nullable: false),
                        RegistraionDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordID)
                .ForeignKey("dbo.Participant", t => t.ParticipantID, cascadeDelete: true)
                .ForeignKey("dbo.Schedule", t => t.ScheduleID, cascadeDelete: true)
                .Index(t => t.ScheduleID)
                .Index(t => t.ParticipantID);
            
            CreateTable(
                "dbo.Participant",
                c => new
                    {
                        ParticipantID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        EmailAddress = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ParticipantID);
            
            CreateTable(
                "dbo.BookingDetail",
                c => new
                    {
                        BookingDetailID = c.Int(nullable: false, identity: true),
                        BookingOrderID = c.Int(nullable: false),
                        ScheduleID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingDetailID)
                .ForeignKey("dbo.BookingOrder", t => t.BookingOrderID, cascadeDelete: true)
                .ForeignKey("dbo.Schedule", t => t.ScheduleID, cascadeDelete: true)
                .Index(t => t.BookingOrderID)
                .Index(t => t.ScheduleID);
            
            CreateTable(
                "dbo.BookingOrder",
                c => new
                    {
                        BookingOrderID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingOrderID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        InstructorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        EmailAddress = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        ScheduleID = c.Int(),
                    })
                .PrimaryKey(t => t.InstructorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedule", "InstructorID", "dbo.Instructor");
            DropForeignKey("dbo.Schedule", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.BookingDetail", "ScheduleID", "dbo.Schedule");
            DropForeignKey("dbo.BookingDetail", "BookingOrderID", "dbo.BookingOrder");
            DropForeignKey("dbo.BookingCart", "ScheduleID", "dbo.Schedule");
            DropForeignKey("dbo.RegistrationRecord", "ScheduleID", "dbo.Schedule");
            DropForeignKey("dbo.RegistrationRecord", "ParticipantID", "dbo.Participant");
            DropIndex("dbo.BookingDetail", new[] { "ScheduleID" });
            DropIndex("dbo.BookingDetail", new[] { "BookingOrderID" });
            DropIndex("dbo.RegistrationRecord", new[] { "ParticipantID" });
            DropIndex("dbo.RegistrationRecord", new[] { "ScheduleID" });
            DropIndex("dbo.Schedule", new[] { "InstructorID" });
            DropIndex("dbo.Schedule", new[] { "CategoryID" });
            DropIndex("dbo.BookingCart", new[] { "ScheduleID" });
            DropTable("dbo.Instructor");
            DropTable("dbo.Category");
            DropTable("dbo.BookingOrder");
            DropTable("dbo.BookingDetail");
            DropTable("dbo.Participant");
            DropTable("dbo.RegistrationRecord");
            DropTable("dbo.Schedule");
            DropTable("dbo.BookingCart");
        }
    }
}

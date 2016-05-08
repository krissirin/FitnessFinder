using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessClassFinder.Models;

namespace FitnessModel.tests
{
    [TestClass]
    public class UnitTest1
    {
        // Test adding a new fitness class and verifies that two specified objects are equal 
        // within the specified accuracy of each other. 
        // The assertion fails if the objects are not equal.

        [TestMethod]
        public void TestSchedule()
        {
            ClassSchedule c = new ClassSchedule()
            {
                FitnessClassID = 1,
                SelectArea = SelectArea.Dublin,
                LocalArea = "Tallaght",
                ClassName = "Yoga",
                Description = "Contact us for more details",
                BusinessName = "Westpark Fitness",
                StartDate = DateTime.Parse("09-05-2016"),
                StartTime = StartTime.AM1200,
                Duration = Duration.SixtyMinute,
                Status = Status.Available,
                MaxEnroll = 15,
                Fee = 0,
                CategoryID = 1
            };
            Assert.AreEqual(1, c.FitnessClassID);
            Assert.AreEqual(SelectArea.Dublin, c.SelectArea);
            Assert.AreEqual("Tallaght", c.LocalArea);
            Assert.AreEqual("Yoga", c.ClassName);
            Assert.AreEqual("Contact us for more details", c.Description);
            Assert.AreEqual("Westpark Fitness", c.BusinessName);
            Assert.AreEqual(DateTime.Parse("09-05-2016"), c.StartDate);
            Assert.AreEqual(StartTime.AM1200, c.StartTime);
            Assert.AreEqual(Duration.SixtyMinute, c.Duration);
            Assert.AreEqual(Status.Available, c.Status);
            Assert.AreEqual(15, c.MaxEnroll);
            Assert.AreEqual(0, c.Fee);
            Assert.AreEqual(1, c.CategoryID);
        }
    }
}

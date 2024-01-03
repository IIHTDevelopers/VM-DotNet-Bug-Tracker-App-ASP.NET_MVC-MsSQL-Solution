
using BugTrackerApp.DAL;
using BugTrackerApp.DAL.Interface;
using BugTrackerApp.DAL.Repository;
using BugTrackerApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace BugTrackerApp.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IBugTrackerInterface _bugTrackerService;
        public readonly Mock<IBugTrackerRepository> bugtrackerservice = new Mock<IBugTrackerRepository>();
        private readonly Bug _Bug;
        private readonly IEnumerable<Bug> BugList;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _bugTrackerService = new BugTrackerService(bugtrackerservice.Object);
            _output = output;
            _Bug = new Bug
            {
                Id = 1,
                Date = DateTime.Now,
                BugName = "Exercise",
                IsCompleted = true,
                Notes = "30 minutes of jogging in the park."
            };
             BugList = new List<Bug>
        {
            new Bug
            {
               Id = 1,
                Date = DateTime.Now,
                BugName = "Exercise",
                IsCompleted = true,
                Notes = "30 minutes of jogging in the park."
            },
            new Bug
            {
                Id = 1,
                Date = DateTime.Now,
                BugName = "Exercise",
                IsCompleted = true,
                Notes = "30 minutes of jogging in the park."
            },
        };

        }

        [Fact]
        public async Task<bool> Testfor_Get_Bug()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                 bugtrackerservice.Setup(repos => repos.GetBugs()).Returns(BugList);
                var result =  _bugTrackerService.GetBugs();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Get_Bug_ById()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                bugtrackerservice.Setup(repos => repos.GetBugByID(_Bug.Id)).Returns(_Bug);
                var result = _bugTrackerService.GetBugByID(_Bug.Id);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Update_Bug()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                bugtrackerservice.Setup(repos => repos.UpdateBug(_Bug)).Returns(true);
                var result=_bugTrackerService.UpdateBug(_Bug);
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Delete_Bug()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                bugtrackerservice.Setup(repos => repos.DeleteBug(_Bug.Id)).Returns(1);
                var result=_bugTrackerService.DeleteBug(_Bug.Id);

                //Assertion
                if (result!= null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}
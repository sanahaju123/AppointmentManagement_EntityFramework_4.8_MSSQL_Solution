

using AppointmentManagementApp.DAL.Interrfaces;
using AppointmentManagementApp.DAL.Services;
using AppointmentManagementApp.DAL.Services.Repository;
using AppointmentManagementApp.Models;
using AppointmentManagementApp.Tests.TestCases;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AppointmentManagementApp.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IAppointmentService _appointmentService;
        public readonly Mock<IAppointmentRepository> appointmentservice = new Mock<IAppointmentRepository>();

        private readonly Appointment _appointment;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _appointmentService = new AppointmentService(appointmentservice.Object);

            _output = output;

            _appointment = new Appointment
            {
                AppointmentId = 1,
                Title = "Team Meeting",
                StartDateTime = DateTime.Now.AddHours(1),
                EndDateTime = DateTime.Now.AddHours(2),
                Location = "Virtual Meeting",
                Description = "Discuss project updates",
                UserId = 123
            };
        }


        [Fact]
        public async Task<bool> Testfor_Create_Appointment()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentservice.Setup(repos => repos.CreateAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _appointmentService.CreateAppointment(_appointment);
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
        public async Task<bool> Testfor_Update_Appointment()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentservice.Setup(repos => repos.UpdateAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _appointmentService.UpdateAppointment(_appointment);
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
        public async Task<bool> Testfor_GetAppointmentById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentservice.Setup(repos => repos.GetAppointmentById(id)).ReturnsAsync(_appointment);
                var result = await _appointmentService.GetAppointmentById(id);
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
        public async Task<bool> Testfor_DeleteAppointmentById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentservice.Setup(repos => repos.DeleteAppointmentById(id)).ReturnsAsync(response);
                var result = await _appointmentService.DeleteAppointmentById(id);
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

    }
}


using AppointmentManagementApp.DAL.Interrfaces;
using AppointmentManagementApp.DAL.Services;
using AppointmentManagementApp.DAL.Services.Repository;
using AppointmentManagementApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AppointmentManagementApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IAppointmentService _appointmentService;
        public readonly Mock<IAppointmentRepository> appointmentservice = new Mock<IAppointmentRepository>();

        private readonly Appointment _appointment;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Appointment_Title_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentservice.Setup(repo => repo.CreateAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _appointmentService.CreateAppointment(_appointment);
                var actualLength = _appointment.Title.ToString().Length;
                if (result.Title.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Appointment_Location_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                appointmentservice.Setup(repo => repo.CreateAppointment(_appointment)).ReturnsAsync(_appointment);
                var result = await _appointmentService.CreateAppointment(_appointment);
                var actualLength = _appointment.Location.ToString().Length;
                if (result.Location.ToString().Length == actualLength)
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
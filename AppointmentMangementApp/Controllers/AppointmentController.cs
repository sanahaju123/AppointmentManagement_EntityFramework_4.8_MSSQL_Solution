using AppointmentManagement.Models;
using AppointmentManagementApp.DAL.Interrfaces;
using AppointmentManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppointmentManagementApp.Controllers
{
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentService _service;
        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }
        public AppointmentController()
        {
            // Constructor logic, if needed
        }
        [HttpPost]
        [Route("api/Appointment/CreateAppointment")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> CreateAppointment([FromBody] Appointment model)
        {
            var leaveExists = await _service.GetAppointmentById(model.AppointmentId);
            var result = await _service.CreateAppointment(model);
            return Ok(new Response { Status = "Success", Message = "Appointment created successfully!" });
        }


        [HttpPut]
        [Route("api/Appointment/UpdateAppointment")]
        public async Task<IHttpActionResult> UpdateAppointment([FromBody] Appointment model)
        {
            var result = await _service.UpdateAppointment(model);
            return Ok(new Response { Status = "Success", Message = "Appointment updated successfully!" });
        }


        [HttpDelete]
        [Route("api/Appointment/DeleteAppointment")]
        public async Task<IHttpActionResult> DeleteAppointment(long id)
        {
            var result = await _service.DeleteAppointmentById(id);
            return Ok(new Response { Status = "Success", Message = "Appointment deleted successfully!" });
        }


        [HttpGet]
        [Route("api/Appointment/GetAppointmentById")]
        public async Task<IHttpActionResult> GetAppointmentById(long id)
        {
            var expense = await _service.GetAppointmentById(id);
            return Ok(expense);
        }


        [HttpGet]
        [Route("api/Appointment/GetAllAppointments")]
        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return _service.GetAllAppointments();
        }
    }
}

using AppointmentManagementApp.DAL.Interrfaces;
using AppointmentManagementApp.DAL.Services.Repository;
using AppointmentManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AppointmentManagementApp.DAL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public Task<Appointment> CreateAppointment(Appointment expense)
        {
            return _repository.CreateAppointment(expense);
        }

        public Task<bool> DeleteAppointmentById(long id)
        {
            return _repository.DeleteAppointmentById(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return _repository.GetAllAppointments();
        }

        public Task<Appointment> GetAppointmentById(long id)
        {
            return _repository.GetAppointmentById(id); ;
        }

        public Task<Appointment> UpdateAppointment(Appointment model)
        {
            return _repository.UpdateAppointment(model);
        }
    }
}
using AppointmentManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagementApp.DAL.Interrfaces
{
    public interface IAppointmentService
    {
        List<Appointment> GetAllAppointments();
        Task<Appointment> CreateAppointment(Appointment expense);
        Task<Appointment> GetAppointmentById(long id);
        Task<bool> DeleteAppointmentById(long id);
        Task<Appointment> UpdateAppointment(Appointment model);
    }
}

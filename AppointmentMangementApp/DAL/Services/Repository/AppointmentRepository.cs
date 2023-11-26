using AppointmentManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AppointmentManagementApp.DAL.Services.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DatabaseContext _dbContext;
        public AppointmentRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Appointment> CreateAppointment(Appointment expense)
        {
            try
            {
                var result =  _dbContext.Appointments.Add(expense);
                await _dbContext.SaveChangesAsync();
                return expense;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteAppointmentById(long id)
        {
            try
            {
                _dbContext.Appointments.Remove(_dbContext.Appointments.Single(a => a.AppointmentId == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            try
            {
                var result = _dbContext.Appointments.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Appointment> GetAppointmentById(long id)
        {
            try
            {
                return await _dbContext.Appointments.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

      
        

        public async Task<Appointment> UpdateAppointment(Appointment model)
        {
            var ex = await _dbContext.Appointments.FindAsync(model.AppointmentId);
            try
            {
                await _dbContext.SaveChangesAsync();
                return ex;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
    }
}
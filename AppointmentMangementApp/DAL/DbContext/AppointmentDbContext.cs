
using AppointmentManagementApp.Models;
using System.Data.Entity;


namespace AppointmentManagementApp.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
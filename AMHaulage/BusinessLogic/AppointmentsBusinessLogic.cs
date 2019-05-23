using System.Linq;
using AMHaulage.Models;

namespace AMHaulage.BusinessLogic
{
    public class AppointmentsBusinessLogic
    {
        private static IQueryable<Appointment> _appointmentsQuery;

        public AppointmentsBusinessLogic(AppointmentContext context)
        {
            // LINQ to get all Appointments in Appointments table
            _appointmentsQuery = from m in context.Appointments
                select m;
        }
        
        // Get appointments query which is filtered by summary
        public static IQueryable<Appointment> GetAppointmentsQueryBySummary(string searchString)
        {
            // Check if a string (searchString) was searched, and if so,
            // ... modify appointmentsQuery to find all Appointments
            // ... where searchString is part of Appointment Summary
            return !string.IsNullOrEmpty(searchString) ? _appointmentsQuery.Where(s => s.Summary.Contains(searchString)) : _appointmentsQuery;
        }

        // Get appointments query which is filtered by location
        public static IQueryable<Appointment> GetAppointmentsQueryByLocation(string appointmentLocation)
        {
            // Check if location (appointmentLocation) requested is null, and if so,
            // ... modify appointmentsQuery to find all Appointments
            // ... where appointmentLocation is a valid Location in Appointments table
            return !string.IsNullOrEmpty(appointmentLocation) ? _appointmentsQuery.Where(x => x.Location == appointmentLocation) : _appointmentsQuery;
        }

        // Get appointments query which is filtered by location and summary
        public IQueryable<Appointment> GetAppointmentsQuery(string searchString, string appointmentLocation)
        {
            return GetAppointmentsQueryBySummary(searchString).Intersect(GetAppointmentsQueryByLocation(appointmentLocation));
        }
    }
}
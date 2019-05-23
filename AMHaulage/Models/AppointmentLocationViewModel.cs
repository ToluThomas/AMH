using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AMHaulage.Models
{
    public class AppointmentLocationViewModel
    {
        public List<Appointment> Appointments { get; set; }
        public SelectList Locations { get; set; }
        public string AppointmentLocation { get; set; }
        public string SearchString { get; set; }
    }
}

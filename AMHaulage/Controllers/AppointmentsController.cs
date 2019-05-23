using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AMHaulage.Models;
using AMHaulage.BusinessLogic;

namespace AMHaulage.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository<Appointment> _appointmentRepository;
        //private readonly AppointmentContext _context;
        private readonly IQueryable<string> _appointmentLocationQuery;
        private readonly AppointmentsBusinessLogic _appointmentsBusinessLogic;
        

        public AppointmentsController(IAppointmentRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            // LINQ to get all Locations in Appointments table
            _appointmentLocationQuery = from m in appointmentRepository.GetContext().Appointments
                orderby m.Location
                select m.Location;
            // Create new instance of business logic and supply context arg
            _appointmentsBusinessLogic = new AppointmentsBusinessLogic(appointmentRepository.GetContext());
        }

       /* public AppointmentsController(AppointmentContext context)
        {
            _context = context;
        }*/

        // GET: Appointments
        public async Task<IActionResult> Index(string appointmentLocation, string searchString)
        {

            var appointmentLocationViewModel = new AppointmentLocationViewModel
            {
                Locations = new SelectList(await _appointmentLocationQuery.Distinct().ToListAsync()),
                Appointments = await _appointmentsBusinessLogic.GetAppointmentsQuery(searchString, appointmentLocation).ToListAsync()
            };

            return View(appointmentLocationViewModel);
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentRepository.FirstOrDefault(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        // To protect from over-posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Summary,Location,Color,Driver,Vehicle")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _appointmentRepository.Add(appointment);
                await _appointmentRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentRepository.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from over-posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,Summary,Location,Color,Driver,Vehicle")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appointmentRepository.Update(appointment);
                    await _appointmentRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentRepository.FirstOrDefault(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _appointmentRepository.Find(id);
            _appointmentRepository.Remove(appointment);
            await _appointmentRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _appointmentRepository.Any(e => e.Id == id);
        }
    }
}

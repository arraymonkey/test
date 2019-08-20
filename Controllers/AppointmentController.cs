using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlushMe.Data;
using BlushMe.Dto;
using BlushMe.Extensions;
using BlushMe.Hubs;
using BlushMe.Model;
using Microsoft.AspNetCore.SignalR;

namespace BlushMe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly BlushDbContext _context;
        private readonly IMapper _mapper;
        private IHubContext<AlertHub> _hubContext;

        public AppointmentController(BlushDbContext context, IMapper mapper, IHubContext<AlertHub> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments()
        {
            var appt = await _context.Appointments.Include(c=>c.Client).ToListAsync();

            return Ok(appt.Select(x => _mapper.Map<AppointmentDto>(x)));
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.Include(c => c.Client).Include(e => e.Employee)
                .Include(m => m.Meta).FirstOrDefaultAsync(a => a.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AppointmentDto>(appointment));
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            await _hubContext.Clients.All.SendAsync("apptUpdated", _mapper.Map<AppointmentDto>(appointment));
            return NoContent();
        }

        // POST: api/Appointment
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            foreach (var s in appointment.ServicesId.Split(','))
            {
                appointment.Title += _context.Services.Find(int.Parse(s)).Name + " ";
            }

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("newAppt", _mapper.Map<AppointmentDto>(appointment));
            return CreatedAtAction("GetAppointment", new {id = appointment.AppointmentId}, appointment);
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("apptDeleted", _mapper.Map<AppointmentDto>(appointment));
            return appointment;
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using SpaApp.models;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        public ReservationController()
        {
            
        }

        [HttpGet]
        public async Task<ICollection<Reservation>> GetAll()
        {
            var reservations = new List<Reservation>();
            return reservations;
        }

        [HttpGet("{id}")]
        public async Task<Reservation> GetById(int id)
        {
            var reservation = new Reservation();
            return reservation;
        }

        [HttpPost]
        public async Task<Reservation> Create([FromBody] Reservation reservation)
        {
            return reservation;
        }

        [HttpPut("{id}")]
        public async Task<Reservation> Update(int id, [FromBody] Reservation updated)
        {
            return updated;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}


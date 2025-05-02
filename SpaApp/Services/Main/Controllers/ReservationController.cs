using Main.Dtos;
using Main.Managers;
using Main.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SpaApp.models;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationManager _reservationManager;

        public ReservationController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;
        }

        [HttpGet]
        public async Task<IEnumerable<ReservationDTO>> GetReservations()
        {
            var reservations = await _reservationManager.GetReservationsAsync();
            return reservations;
        }

        [HttpGet("{id}")]
        public async Task<ReservationDTO> GetReservation(Guid id)
        {
            var reservation = await _reservationManager.GetReservationAsync(id);
            return reservation;
        }

        [HttpPost]
        public async Task<ReservationDTO> SaveUpdateReservation([FromBody] ReservationDTO reservation)
        {
            var savedReservation = await _reservationManager.SaveUpdateReservationAsync(reservation);
            return savedReservation;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _reservationManager.DeleteReservationAsync(id);
            return result ? Ok() : BadRequest();
        }
    }
}


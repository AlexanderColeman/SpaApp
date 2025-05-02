using Main.Database;
using Main.Dtos;
using Main.Managers.Interfaces;
using Microsoft.EntityFrameworkCore;
using SpaApp.models;

namespace Main.Managers
{
    public class ReservationManager : IReservationManager
    {
        private readonly ReservationDbContext _context;

        public ReservationManager(ReservationDbContext context)
        {
            _context = context;
        }

        public async Task<ReservationDTO> GetReservationAsync(Guid id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
                throw new InvalidOperationException($"Reservation with Id '{id}' not found.");

            return new ReservationDTO
            {
                Id = reservation.Id,
                CustomerName = reservation.CustomerName,
                CreatedDate = reservation.CreatedDate,
                NumberOfGuests = reservation.NumberOfGuests
            };
        }

        public async Task<ICollection<ReservationDTO>> GetReservationsAsync()
        {
            var reservations = await _context.Reservations.ToListAsync();
            return reservations.Select(r => new ReservationDTO
            {
                Id = r.Id,
                CustomerName = r.CustomerName,
                CreatedDate = r.CreatedDate,
                NumberOfGuests = r.NumberOfGuests
            }).ToList();
        }

        public async Task<ReservationDTO> SaveUpdateReservationAsync(ReservationDTO reservationDto)
        {
            var reservation = new Reservation 
            { 
                Id = reservationDto.Id,
                CustomerName = reservationDto.CustomerName,
                CreatedDate = reservationDto.CreatedDate,
                NumberOfGuests = reservationDto.NumberOfGuests
            };

            if (reservation.Id == null) 
            {
                await _context.AddAsync(reservation);
            } 
            else
            {
                reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == reservationDto.Id);
                if (reservation != null) 
                {
                    _context.Remove(reservation);
                    await _context.AddAsync(reservation);
                }
            }

            await _context.SaveChangesAsync();
            return reservationDto;
        }

        public async Task<bool> DeleteReservationAsync(Guid id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            if (reservation == null)
                return false;

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

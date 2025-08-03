using Main.Dtos;
using SpaApp.models;

namespace Main.Managers.Interfaces
{
    public interface IReservationManager
    {
        Task<ReservationDTO> GetReservationAsync(Guid id);
        Task<ICollection<ReservationDTO>> GetReservationsAsync();
        Task<ReservationDTO> SaveUpdateReservationAsync(ReservationDTO reservationDto);
        Task<bool> DeleteReservationAsync(Guid id);
    }
}

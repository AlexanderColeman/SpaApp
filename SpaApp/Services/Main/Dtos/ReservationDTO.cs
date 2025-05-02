namespace Main.Dtos
{
    public class ReservationDTO
    {
        public Guid? Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTimeOffset CreatedDate { get; set; }
        public int NumberOfGuests { get; set; }
        
    }
}

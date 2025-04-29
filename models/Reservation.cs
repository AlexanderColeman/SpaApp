namespace SpaApp.models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTimeOffset CreatedDate { get; set; }
        public int NumberOfGuests { get; set; }
    }
}

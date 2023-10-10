namespace TicketBooking.Models
{
    public class TicketBookingStoreDatabaseSettings : ITicketBookingStoreDatabaseSettings
    {
        public string TicketBookingCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}

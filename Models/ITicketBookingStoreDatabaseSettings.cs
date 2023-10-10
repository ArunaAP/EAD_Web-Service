namespace TicketBooking.Models
{
    public interface ITicketBookingStoreDatabaseSettings
    {
        string TicketBookingCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

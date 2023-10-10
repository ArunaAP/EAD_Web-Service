namespace TicketBooking.Models
{
    public interface ITravellerStoreDatabaseSettings
    {
        string TravellerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

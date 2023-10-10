namespace TicketBooking.Models
{
    public class TravellerStoreDatabaseSettings : ITravellerStoreDatabaseSettings
    {
        public string TravellerCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}

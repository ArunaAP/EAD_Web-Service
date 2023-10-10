namespace TicketBooking.Models
{
    public interface ITrainStoreDatabaseSettings
    {
        string TrainCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

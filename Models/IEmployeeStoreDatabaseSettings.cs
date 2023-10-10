namespace TicketBooking.Models
{
    public interface IEmployeeStoreDatabaseSettings
    {
        string EmployeeCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

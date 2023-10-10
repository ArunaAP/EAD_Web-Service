namespace TicketBooking.Models
{
    public class EmployeeStoreDatabaseSettings : IEmployeeStoreDatabaseSettings
    {
        public string EmployeeCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}

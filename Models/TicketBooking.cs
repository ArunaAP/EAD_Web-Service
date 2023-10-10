using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TicketBooking.Models
{
    [BsonIgnoreExtraElements]
    public class TicketBookingManage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("customerName")]
        public string CustomerName { get; set; } = string.Empty;

        [BsonElement("trainNumber")] // Changed property name to "trainNumber"
        public string TrainNumber { get; set; } = string.Empty;

        [BsonElement("departureCity")]
        public string DepartureCity { get; set; } = string.Empty;

        [BsonElement("arrivalCity")]
        public string ArrivalCity { get; set; } = string.Empty;

        [BsonElement("departureDate")]
        public DateTime DepartureDate { get; set; } = DateTime.MinValue;

        [BsonElement("arrivalDate")]
        public DateTime ArrivalDate { get; set; } = DateTime.MinValue;

        [BsonElement("ticketPrice")]
        public decimal TicketPrice { get; set; } = 0.0m;
    }
}

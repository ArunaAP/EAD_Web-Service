using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TicketBooking.Models
{
    [BsonIgnoreExtraElements]
    public class TravelerProfile
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)] // Assuming NIC is a string
        public string NIC { get; set; } = String.Empty;

        [BsonElement("firstName")]
        public string FirstName { get; set; } = String.Empty;

        [BsonElement("lastName")]
        public string LastName { get; set; } = String.Empty;

        [BsonElement("gender")]
        public string Gender { get; set; } = String.Empty;

        [BsonElement("age")]
        public int Age { get; set; }

        // Add any other properties relevant to a traveler's profile
    }
}

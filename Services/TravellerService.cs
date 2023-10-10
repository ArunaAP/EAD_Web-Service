
using TicketBooking.Models;
using MongoDB.Driver;

namespace TicketBooking.Services
{
    public class TravellerService : ITravelerService
    {
        private readonly IMongoCollection<TravelerProfile> _travelerProfiles;

        public TravellerService(ITravellerStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _travelerProfiles = database.GetCollection<TravelerProfile>(settings.TravellerCollectionName);
        }

        public TravelerProfile CreateTraveler(TravelerProfile traveler)
        {
            _travelerProfiles.InsertOne(traveler);
            return traveler;
        }

        public List<TravelerProfile> GetTravelers()
        {
            return _travelerProfiles.Find(traveler => true).ToList();
        }

        public TravelerProfile GetTravelerByNIC(string nic)
        {
            return _travelerProfiles.Find(traveler => traveler.NIC == nic).FirstOrDefault();
        }

        public void RemoveTraveler(string nic)
        {
            _travelerProfiles.DeleteOne(traveler => traveler.NIC == nic);
        }

        public void UpdateTraveler(string nic, TravelerProfile traveler)
        {
            _travelerProfiles.ReplaceOne(existingTraveler => existingTraveler.NIC == nic, traveler);
        }
    }
}

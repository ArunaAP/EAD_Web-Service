using TicketBooking.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace TicketBooking.Services
{
    public class TrainService : ITrainService
    {
        private readonly IMongoCollection<Train> _trains;

        public TrainService(ITrainStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _trains = database.GetCollection<Train>(settings.TrainCollectionName);
        }

        public Train CreateTrain(Train train)
        {
            _trains.InsertOne(train);
            return train;
        }

        public List<Train> GetTrains()
        {
            return _trains.Find(train => true).ToList();
        }

        public Train GetTrain(string id)
        {
            return _trains.Find(train => train.Id == id).FirstOrDefault();
        }

        public void RemoveTrain(string id)
        {
            _trains.DeleteOne(train => train.Id == id);
        }

        public void UpdateTrain(string id, Train train)
        {
            _trains.ReplaceOne(existingTrain => existingTrain.Id == id, train);
        }
    }
}

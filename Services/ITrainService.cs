using TicketBooking.Models;
using System.Collections.Generic;

namespace TicketBooking.Services
{
    public interface ITrainService
    {
        List<Train> GetTrains();
        Train GetTrain(string id);
        Train CreateTrain(Train train);
        void UpdateTrain(string id, Train train);
        void RemoveTrain(string id);
    }
}

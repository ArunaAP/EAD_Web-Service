using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Services;
using System.Collections.Generic;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService trainService;

        public TrainController(ITrainService trainService)
        {
            this.trainService = trainService;
        }

        // GET: api/Train
        [HttpGet]
        public ActionResult<List<Train>> Get()
        {
            return trainService.GetTrains();
        }

        // GET api/Train/5
        [HttpGet("{id}")]
        public ActionResult<Train> Get(string id)
        {
            var train = trainService.GetTrain(id);

            if (train == null)
            {
                return NotFound($"Train with Id = {id} not found");
            }

            return train;
        }

        // POST api/Train
        [HttpPost]
        public ActionResult<Train> Post([FromBody] Train train)
        {
            trainService.CreateTrain(train);

            return CreatedAtAction(nameof(Get), new { id = train.Id }, train);
        }

        // PUT api/Train/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Train train)
        {
            var existingTrain = trainService.GetTrain(id);

            if (existingTrain == null)
            {
                return NotFound($"Train with Id = {id} not found");
            }

            trainService.UpdateTrain(id, train);

            return NoContent();
        }

        // DELETE api/Train/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var train = trainService.GetTrain(id);

            if (train == null)
            {
                return NotFound($"Train with Id = {id} not found");
            }

            trainService.RemoveTrain(train.Id);

            return Ok($"Train with Id = {id} deleted");
        }
    }
}

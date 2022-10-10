using System;
using System.Collections.Generic;
using System.Linq;
using Transport.Iy.Models;

namespace Transport.Iy.Services
{

    public class ItinerariesService : IItinerariesService
    {
        private readonly int batchSize = 20;
        private int skip=0;
        private readonly IOrderService _orderService;
        private readonly ISecheduleService _schedelueservice;

        public ItinerariesService(IOrderService orderService, ISecheduleService secheduleService)
        {
            _orderService = orderService;
            _schedelueservice = secheduleService;
        }

        /// <summary>
        /// Assigne boxes to the flight based on schedule and batch size
        /// </summary>
        public void PrintItineraries()
        {
            var schedule = _schedelueservice.GetFlightShcedule();
            var boxesForToronto = _orderService.GetOrderFromJson().Where(order => order.destination == Constants.Constants.TORONTO_CODE);
            var boxesForCalgary = _orderService.GetOrderFromJson().Where(order => order.destination == Constants.Constants.CALGARY_CODE);
            var boxesForVancouver = _orderService.GetOrderFromJson().Where(order => order.destination == Constants.Constants.VANCOUVER_CODE);
            var boxesNotScheduled = _orderService.GetOrderFromJson().Where(order =>
            order.destination != Constants.Constants.VANCOUVER_CODE &&
            order.destination != Constants.Constants.TORONTO_CODE &&
            order.destination != Constants.Constants.CALGARY_CODE);

          var itineraries = new List<ItineraryModel>();
        
          // Assignes boxes for each fligh per capacity and for the days running
          ProcessBatch(schedule, boxesForToronto, itineraries, Constants.Constants.TORONTO_CODE);
          ProcessBatch(schedule, boxesForCalgary, itineraries, Constants.Constants.CALGARY_CODE);
          ProcessBatch(schedule, boxesForVancouver, itineraries, Constants.Constants.VANCOUVER_CODE);


            /// Private methods to put common logic for process bacth for each flight and making Itinerary
            void ProcessBatch(List<FlightModel> schedule, IEnumerable<Order> boxesForDestination, List<ItineraryModel> itineraries, string destination)
            {
                foreach (var flight in schedule.Where(x => x.Destination == destination ))
                {
                    
                        foreach (var box in boxesForDestination.Skip(skip).Take(batchSize))
                        {
                          
                        if (itineraries.Count(i => i.Day == flight.Day && i.FlightNumber == flight.FlightNumber && i.Destination == flight.Destination) <= batchSize)
                        {
                            itineraries.Add(new ItineraryModel()
                            {
                                Day = flight.Day,
                                Destination = flight.Destination,
                                FlightNumber = flight.FlightNumber,
                                OrderNumber = box.orderNumber,
                                Source = flight.Source
                            });
                        }
                                        
                                        }
                    skip += batchSize;


                }
                skip = 0;
            }

            // Pinting all the itineraries to console
            foreach (var itinerary in itineraries)
            {
                Console.WriteLine($"order: {itinerary.OrderNumber} flightNumber: {itinerary.FlightNumber}, departure: {itinerary.Source}, arrival: {itinerary.Destination}, day: {itinerary.Day}");
            }
            // Lookping thorugh the items whihc have destination other that flight schedule
            foreach (var box in boxesNotScheduled)
            {
                Console.WriteLine($"order: {box.orderNumber}, flightNumber: not scheduled");
            }
        }
    }
}

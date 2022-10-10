using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Iy.Services
{
    public class FlightService : IFlightService
    {
        private readonly ISecheduleService _service;
        public FlightService(ISecheduleService service)
        {
            _service = service;
        }
        /// <summary>
        /// Prints flight schedule to console
        /// </summary>
        public void PrintSchedule()
        {
            foreach (var flight in _service.GetFlightShcedule())
            {
                Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.Source}, arrival: {flight.Destination}, day: {flight.Day}");
            }

        }
    }
}

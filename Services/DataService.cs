using System.Collections.Generic;
using Transport.Iy.Models;

namespace Transport.Iy.Services
{
    public class DataService
    {
    /// <summary>
    /// Private methods to Perpare load/prepare flight schedule
    /// </summary>
    /// <returns></returns>
        private static List<FlightModel> SetFlightShcedule()
        {
            List<FlightModel> fligts = new()
            {
                // Added should for day one 
                AddFlight(1, Constants.Constants.MONTREAL_CODE, Constants.Constants.TORONTO_CODE, 1),
                AddFlight(1, Constants.Constants.MONTREAL_CODE, Constants.Constants.CALGARY_CODE, 2),
                AddFlight(1, Constants.Constants.MONTREAL_CODE, Constants.Constants.VANCOUVER_CODE, 3),

                //Schedule for Day 2
                AddFlight(2, Constants.Constants.MONTREAL_CODE, Constants.Constants.TORONTO_CODE, 4),
                AddFlight(2, Constants.Constants.MONTREAL_CODE, Constants.Constants.CALGARY_CODE, 5),
                AddFlight(2, Constants.Constants.MONTREAL_CODE, Constants.Constants.VANCOUVER_CODE, 6)
            };
            return fligts;
        }

        private static FlightModel AddFlight(int day, string sourceCode, string destinationCode, int flightNumber)
        {
            return new FlightModel() { Day = day, Source = sourceCode, Destination = destinationCode, FlightNumber = flightNumber };
        }

        /// <summary>
        /// Pulic method retunrs fligher schedules 
        /// </summary>
        /// <returns></returns>
        public static List<FlightModel> GetFlightModels()
        {
            return SetFlightShcedule();
        }
    }
}

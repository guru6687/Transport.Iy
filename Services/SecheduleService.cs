using System;
using System.Collections.Generic;
using Transport.Iy.Models;

namespace Transport.Iy.Services
{
    public class SecheduleService : ISecheduleService
    {
        public List<FlightModel> GetFlightShcedule()
        {
            return DataService.GetFlightModels();
        }

     
    }
}

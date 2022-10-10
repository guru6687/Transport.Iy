using System.Collections.Generic;
using Transport.Iy.Models;

namespace Transport.Iy.Services
{
    public interface ISecheduleService
    {
        List<FlightModel> GetFlightShcedule();
    }
}
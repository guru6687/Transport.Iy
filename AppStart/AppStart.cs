using System;
using Transport.Iy.Services;

namespace Transport.Iy.AppStart
{
    public class AppStart
    {
        private readonly IFlightService _flightService;
        private readonly IItinerariesService _itinerariesService;

        public AppStart(IFlightService flightService, IItinerariesService itinerariesService)
        {
            _flightService = flightService;
            _itinerariesService = itinerariesService;
        }

        public void Run()
        {
            Console.WriteLine("Use options below to load information");
            Console.WriteLine();
            Console.WriteLine($"For Flight Schedule: Enter {1}");
            Console.WriteLine();
            Console.WriteLine($"For Flight itineraries: Enter {2}");
            Console.WriteLine();
            Console.WriteLine($"Enter {10} To Exit: ");
            int userInput;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Please enter only numeric value");
                    return;
                }
                switch (userInput)
                {
                    case 1:
                        _flightService.PrintSchedule();
                        break;
                    case 2:
                        _itinerariesService.PrintItineraries();
                        break;
                    default:
                        Console.WriteLine($"Entered value: {userInput} in not valid command");
                        break;
                }

            }
            while (userInput != 10);     
        }
    }
}

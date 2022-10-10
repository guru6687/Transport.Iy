﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Iy.Models
{
    public class ItineraryModel
    {
        public int FlightNumber { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public int Day { get; set; }

        public string OrderNumber { get; set; }

    }
}

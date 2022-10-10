using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Iy.Models
{

    //public class OrderModel
    //{
    //    public string destination { get; set; }

    //}
    //public class Boxes
    //{
    //   List<OrderModel> orders = new List<OrderModel>();
        
    //        [JsonProperty("jobcodes")]
    //        public Dictionary<string, JobCode> JobCodes { get; set; }
        
    //}

    public class Order
    {
        public string orderNumber { get; set; }

       
        public string destination { get; set; }

    }
    public class Destination
    {
        [JsonProperty("destination")]
        public string destination { get; set; }
    }
  }

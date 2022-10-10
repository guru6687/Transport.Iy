using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Transport.Iy.Models;

namespace Transport.Iy.Services
{
    public class OrderService : IOrderService
    {
        /// <summary>
        /// Read the orders from the json file
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrderFromJson()
        {
            string text = File.ReadAllText(@"./orders.json");
            dynamic boxes = JsonConvert.DeserializeObject(text);
            var Orders = new List<Order>();
            foreach (var box in boxes)
            {
                var orderNumber = ((Newtonsoft.Json.Linq.JProperty)box).Name;
                var destination = ((Newtonsoft.Json.Linq.JProperty)box).Value;
                
                Orders.Add(new Order()
                {
                    orderNumber = orderNumber,
                    destination = JsonConvert.DeserializeObject<Destination>(destination.ToString()).destination
                });

            }
            return Orders;
        }
    }
}

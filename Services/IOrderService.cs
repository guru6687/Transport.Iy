using System.Collections.Generic;
using Transport.Iy.Models;

namespace Transport.Iy.Services
{
    public interface IOrderService
    {
        List<Order> GetOrderFromJson();
    }
}
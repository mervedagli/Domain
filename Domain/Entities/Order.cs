using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public int Id { get; set; } 
        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }  
        public ICollection<OrderDetail> OrderDetails { get; set; }   

        public void AddDetail(OrderDetail orderDetail)
        {
            OrderDetails.Add(orderDetail);
            
        }

        public void RemoveDetail(OrderDetail orderDetail)
        {
            OrderDetails.Remove(orderDetail);
        }
        
    }
}

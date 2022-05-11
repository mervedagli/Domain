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
        private readonly ICollection<OrderDetail> _orderDetails = new List<OrderDetail>();
        private int _status = 0;

        public Order()
        {
            //
            //
            //
            //OrderDetails = new List<OrderDetail>();
            //_orderDetails = new List<OrderDetail>();
        }
        public int Id { get; set; }
        //public int ID { get; set; }
        //public int OrderId { get; set; }
        //public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public Status Status { get; set; }

        public IEnumerable<OrderDetail> OrderDetails
        {
            get
            {
                return _orderDetails;
            }
        }

        public void AddDetail(OrderDetail orderDetail)
        {
            //OrderDetails.Add(orderDetail);
            _orderDetails.Add(orderDetail);
        }

        public void RemoveDetail(OrderDetail orderDetail)
        {
            //OrderDetails.Remove(orderDetail);
            _orderDetails.Remove(orderDetail);
        }

        public void ClearDetails()
        {
            //_orderDetails = new List<OrderDetail>();
            _orderDetails.Clear();
        }
    }
}

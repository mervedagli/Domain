using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess
{
    public class Program
    {
        public static void Main()
        {
            var order = new Order();
            var detail01 = new OrderDetail();

            order.AddDetail(detail01);
            order.RemoveDetail(detail01);
            order.ClearDetails();
            

            //order.OrderDetails.Add(new OrderDetail() { });
            //order.OrderDetails = null;
        }
    }
}

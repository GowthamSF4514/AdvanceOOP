using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public enum OrderStatus{Default,Initiated,Ordered,Cancelled}
    public class OrderDetails
    {
        private static int s_orderId=3000;
        public string OrderId { get; }
        public string CustomerId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderDetails(string userId,double totalPrice,DateTime orderDate,  OrderStatus orderStarus){
            s_orderId++;
            OrderId="OID"+s_orderId;
            CustomerId=userId;
            TotalPrice=totalPrice;
            OrderDate=orderDate; 
            OrderStatus=orderStarus;
        }
        public OrderDetails(string order){
            string[] order1=order.Split(",",StringSplitOptions.RemoveEmptyEntries);
            OrderId=order1[0];
            s_orderId=int.Parse(order1[0].Remove(0,3));
            CustomerId=order1[1];
            TotalPrice=double.Parse(order1[2]);
            OrderDate=DateTime.ParseExact(order1[3],"dd/MM/yyyy",null); 
            OrderStatus=Enum.Parse<OrderStatus>(order1[4],true);
        }
    }
}
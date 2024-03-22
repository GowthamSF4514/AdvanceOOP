using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public class ItemDetails
    {
        private static int s_itemId=100;
        public string ItemId { get; }
        public string OrderId { get; set; }
        public string FoodId { get; set; }
        public double OrderPrice { get; set; }
        public int PurchaseCount { get; set; }
        public ItemDetails(string orderId,string foodId,int orderQuantity,double orderPrice){
            s_itemId++;
            ItemId="TID"+s_itemId;
            OrderId=orderId;
            FoodId=foodId;
            OrderPrice=orderPrice;
            PurchaseCount=orderQuantity;       
            }
        public ItemDetails(string item){
            string[] item1=item.Split(",",StringSplitOptions.RemoveEmptyEntries);

            ItemId=item1[0];
            s_itemId=int.Parse(item1[0].Remove(0,4));
            OrderId=item1[1];
            FoodId=item1[2];  
            PurchaseCount=int.Parse(item1[3]); 
            OrderPrice=double.Parse(item1[4]);      
            }
    }
}
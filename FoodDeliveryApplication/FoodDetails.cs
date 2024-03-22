using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public class FoodDetails
    {
         private static int s_foodId=100;
        public string FoodId { get; }
        public string FoodName { get; set; }
        public double PricePerQuantity { get; set; }
        public int QuantityAvailable { get; set; }
        public FoodDetails(string foodName,double price,int availableQuantity){
            s_foodId++;
            FoodId="FID"+s_foodId;
            FoodName=foodName;
            PricePerQuantity=price;
            QuantityAvailable=availableQuantity;
        }
        public FoodDetails(string food){
            string[] food1=food.Split(",",StringSplitOptions.RemoveEmptyEntries);
            FoodId=food1[0];
            s_foodId=int.Parse(food1[0].Remove(0,3));
            FoodName=food1[1];
            PricePerQuantity=double.Parse(food1[2]);
            QuantityAvailable=int.Parse(food1[3]);
        }
    }
}
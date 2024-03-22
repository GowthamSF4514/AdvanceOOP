using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public class FileHandling
    {
        public static void Create(){
            if(!Directory.Exists("FoodDeliveryManagement")){
                Directory.CreateDirectory("FoodDeliveryManagement");
            }
            if(!File.Exists("FoodDeliveryManagement/CustomerDetails.csv")){
                File.Create("FoodDeliveryManagement/CustomerDetails.csv").Close();
            }
            if(!File.Exists("FoodDeliveryManagement/OrderDetails.csv")){
                File.Create("FoodDeliveryManagement/OrderDetails.csv").Close();
            }
            if(!File.Exists("FoodDeliveryManagement/ItemDetails.csv")){
                File.Create("FoodDeliveryManagement/ItemDetails.csv").Close();
            }
            if(!File.Exists("FoodDeliveryManagement/FoodDetails.csv")){
                File.Create("FoodDeliveryManagement/FoodDetails.csv").Close();
            }
        }

        public static void WriteToCsv(){
            string[] customerArray=new string[Operations.listOfCustomerDetails.Count];
            for(int i=0;i<Operations.listOfCustomerDetails.Count;i++){
                string customer=Operations.listOfCustomerDetails[i].CustomerId+","+Operations.listOfCustomerDetails[i].WalletBalance+","+Operations.listOfCustomerDetails[i].Name+","+Operations.listOfCustomerDetails[i].FatherName+","+Operations.listOfCustomerDetails[i].Gender+","+Operations.listOfCustomerDetails[i].Mobile+","+Operations.listOfCustomerDetails[i].Dob.ToString("dd/MM/yyyy")+","+Operations.listOfCustomerDetails[i].MailId+","+Operations.listOfCustomerDetails[i].Location;
                customerArray[i]=customer;
            }
            File.WriteAllLines("FoodDeliveryManagement/CustomerDetails.csv",customerArray);

            string[] orderArray=new string[Operations.listOfOrderDetails.Count];
            for(int i=0;i<Operations.listOfOrderDetails.Count;i++){
                string order=Operations.listOfOrderDetails[i].OrderId+","+Operations.listOfOrderDetails[i].CustomerId+","+Operations.listOfOrderDetails[i].TotalPrice+","+Operations.listOfOrderDetails[i].OrderDate.ToString("dd/MM/yyyy")+","+Operations.listOfOrderDetails[i].OrderStatus;
                orderArray[i]=order;
            }
            File.WriteAllLines("FoodDeliveryManagement/OrderDetails.csv",orderArray);

            string[] foodArray=new string[Operations.listOfFoodDetails.Count];
            for(int i=0;i<Operations.listOfFoodDetails.Count;i++){
                string food=Operations.listOfFoodDetails[i].FoodId+","+Operations.listOfFoodDetails[i].FoodName+","+Operations.listOfFoodDetails[i].PricePerQuantity+","+Operations.listOfFoodDetails[i].QuantityAvailable;
                foodArray[i]=food;
            }
            File.WriteAllLines("FoodDeliveryManagement/FoodDetails.csv",foodArray);

            string[] itemArray=new string[Operations.listOfItemDetails.Count];
            for(int i=0;i<Operations.listOfItemDetails.Count;i++){
                string item=Operations.listOfItemDetails[i].ItemId+","+Operations.listOfItemDetails[i].OrderId+","+Operations.listOfItemDetails[i].FoodId+","+Operations.listOfItemDetails[i].PurchaseCount+","+Operations.listOfItemDetails[i].OrderPrice;
                itemArray[i]=item;
            }
            File.WriteAllLines("FoodDeliveryManagement/ItemDetails.csv",itemArray);
        }

        public static void ReadFromCsv(){
            string[] customerArray=File.ReadAllLines("FoodDeliveryManagement/CustomerDetails.csv");
            for(int i=0;i<customerArray.Length;i++){
                CustomerDetails customer=new CustomerDetails(customerArray[i]);
                Operations.listOfCustomerDetails.Add(customer);
            }

            string[] orderArray=File.ReadAllLines("FoodDeliveryManagement/OrderDetails.csv");
            for(int i=0;i<orderArray.Length;i++){
                OrderDetails order=new OrderDetails(orderArray[i]);
                Operations.listOfOrderDetails.Add(order);
            }

            string[] itemArray=File.ReadAllLines("FoodDeliveryManagement/ItemDetails.csv");
            for(int i=0;i<itemArray.Length;i++){
                ItemDetails item=new ItemDetails(itemArray[i]);
                Operations.listOfItemDetails.Add(item);
            }

            string[] foodArray=File.ReadAllLines("FoodDeliveryManagement/FoodDetails.csv");
            for(int i=0;i<foodArray.Length;i++){
                FoodDetails food=new FoodDetails(foodArray[i]);
                Operations.listOfFoodDetails.Add(food);
            }
        }
    }
}
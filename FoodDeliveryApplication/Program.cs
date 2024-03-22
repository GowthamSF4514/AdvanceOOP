// See https://aka.ms/new-console-template for more information
using System;
using static FoodDeliveryApplication.FileHandling;
using static FoodDeliveryApplication.Operations;
namespace FoodDeliveryApplication;
class Program{
    public static void Main(string[] args)
    {
        Create();
        ReadFromCsv();
        Mainmenu();
        WriteToCsv();
    }
}

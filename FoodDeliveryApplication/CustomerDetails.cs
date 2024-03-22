using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public class CustomerDetails:PersonalDetails,IBalance
    {
        private double _balance;
        private static int s_customerId=1000;
        public string CustomerId { get; }
        public double WalletBalance { get{return _balance;} }
        public void WalletRecharge(double amount){
            _balance+=amount;
        }
        public void DeductBalance(double amount){
            _balance-=amount;
        }
        public CustomerDetails(double balance,string name,string fatherName,Genders gender,string mobile,DateTime dob,string mailId,string location):base( name, fatherName, gender, mobile, dob, mailId, location){
            s_customerId++;
            CustomerId="CID"+s_customerId;
            _balance=balance;
        }
        public CustomerDetails(string customer){
            string[] customer1=customer.Split(",",StringSplitOptions.RemoveEmptyEntries);
            CustomerId=customer1[0];
            s_customerId=int.Parse(customer1[0].Remove(0,3));
            _balance=double.Parse(customer1[1]);
            Name=customer1[2];
            FatherName=customer1[3];
            Gender=Enum.Parse<Genders>(customer1[4],true);
            Mobile=customer1[5];
            Dob=DateTime.ParseExact(customer1[6],"dd/MM/yyyy",null);
            MailId=customer1[7];
            Location=customer1[8];
        }
    }
}
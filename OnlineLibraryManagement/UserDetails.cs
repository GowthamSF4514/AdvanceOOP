using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public enum Genders{Select,Male,Female,Transgender}
    public enum Departments{Select,ECE,EEE,CSE}
    public class UserDetails
    {
        private static int s_userId=3000;
        private int _walletBalance;
        public string UserId { get;  }
        public string UserName { get; set; }
        public Genders Gender {get; set;}
        public Departments Department{get; set;}
        public string MobileNumber { get; set; }
        public string  MailId { get; set; }
        public int WalletBalance { get{return _walletBalance;} set{_walletBalance=value;} }
        public UserDetails(string name,Genders gender, Departments department, string mobileNumber, string mailId, int walletBalance)
        {
            s_userId++;
            UserId="SF"+s_userId;
            UserName=name;
            Gender=gender;
            Department=department;
            MobileNumber=mobileNumber;
            MailId=mailId;
            WalletBalance=walletBalance;
        }
        //recharge users wallet with param
        public void WalletRecharge(int amount)
        {
            WalletBalance+=amount;
        }
        //deduct from user wallet with param
        public void DeductBalance(int amount)
        {
            WalletBalance+=amount;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    
    public enum Genders { Select, Male, Female, Transgender }
    public class PersonalDetails
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Genders Gender { get; set; }
        public string Mobile { get; set; }
        public DateTime Dob { get; set; }
        public string MailId { get; set; }
        public string Location { get; set; }
        public PersonalDetails(string name,string fatherName,Genders gender,string mobile,DateTime dob,string mailId,string location){
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            Mobile=mobile;
            Dob=dob;
            MailId=mailId;
            Location=location;
        }
        public PersonalDetails(){
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public class Operations
    {
        public static CustomList<CustomerDetails> listOfCustomerDetails=new CustomList<CustomerDetails>();
        public static CustomList<FoodDetails> listOfFoodDetails=new CustomList<FoodDetails>();
        public static CustomList<ItemDetails> listOfItemDetails=new CustomList<ItemDetails>();
        public static CustomList<OrderDetails> listOfOrderDetails=new CustomList<OrderDetails>();
        public static CustomerDetails currentCustomer;
        public static void Mainmenu()
        {
            //to display main menu contents to user
            Console.WriteLine("------------------ONLINE FOOD DELIVERY---------------------");
            int choice;
            do
            {

                Console.WriteLine("***************** MAIN MENU *********************");
                Console.WriteLine("1.User Registration\n2.User Login\n3.Exit");
                //ask user his choice
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            //go to registration method()
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            //go to user login() method
                            Login();
                            break;
                        }
                    case 3:
                        {
                            //quit the program if user enters '3'
                            Console.WriteLine("************ EXITED! ******************");
                            break;
                        }
                    default:
                        {
                            //display invalid choice , if user enters other than 1 to 3
                            Console.WriteLine("Invalid Choice! Please enter correct options .");
                            break;
                        }
                }

            } while (choice != 3);
        }
         public static void Registration()
        {
            //ask the user necessary details and register him as a user
            Console.WriteLine("**********WELCOME TO REGISTRATION PAGE! **********");
            Console.WriteLine("Please enter your Details !");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Father's Name: ");
            string fatherName = Console.ReadLine();
            Console.Write("Gender: ");
            Genders gender = Enum.Parse<Genders>(Console.ReadLine(), true);
            Console.Write("Mobile Number +91: ");
            string mobile = Console.ReadLine();
            Console.Write("DOB: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Maild ID: ");
            string mailId = Console.ReadLine();
            Console.Write("Location: ");
            string location=Console.ReadLine();
            Console.Write("Balance you'd like to put in your Wallet Balance: ");
            double balance = double.Parse(Console.ReadLine());
            //now create userdetails obj with provided details and add it to its respective MyList
            CustomerDetails customer = new CustomerDetails(balance,name, fatherName, gender, mobile,dob, mailId, location);
            listOfCustomerDetails.Add(customer);
            //display registerted user's userID
            Console.WriteLine("Registration Successfull! your user ID is " + customer.CustomerId);
            Console.WriteLine();
        }
        public static void Login()
        {
            Console.WriteLine("**********WELCOME TO LOGIN PAGE! *************");
            //ask user his user id , if valid then display submenu contents. else, if it fails , display invalid id
            Console.Write("Enter your Customer ID: ");
            string customerId = Console.ReadLine().ToUpper();
            bool isValidId = false;
            //traverse each obj in MyList of userdetails to check for valid id
            foreach (CustomerDetails customer in listOfCustomerDetails)
            {
                if (customer.CustomerId == customerId)
                {
                    isValidId = true;
                    Console.WriteLine("Login successfull! ");
                    Console.WriteLine();
                    //go to submenu method , since login is successfull
                    currentCustomer = customer;
                    Submenu();
                }
            }
            //if user id not found , display invalid id using flag variable
            if (!isValidId)
            {
                Console.WriteLine("Invalid ID! please enter valid User ID.");
            }
        }

        public static void Submenu()
        {
            //display submenu contents to user
            char choice;
            do
            {
                Console.WriteLine("********WELCOME TO SUBMENU! ************");
                Console.WriteLine("a. Show My Profile\nb. Order Food\nc. Cancel Order\nd. Modify Order \ne. Order History\nf. Recharge Wallet\ng. Show WalletBalance\nh. Exit");
                //ask user his choice
                Console.Write("Enter your choice: ");
                choice = char.Parse(Console.ReadLine().ToLower());
                switch (choice)
                {
                    case 'a':
                        {
                            //go to showprofile method
                            ShowMyProfile();
                            break;
                        }
                    case 'b':
                        {
                            //go to food order method
                            //FoodOrder1();
                            break;
                        }
                    case 'c':
                        {
                            //go to modify order method
                            //ModifyOrder();
                            break;
                        }
                    case 'd':
                        {
                            //go to cancel order method
                            //CancelOrder();
                            break;
                        }
                    case 'e':
                        {
                            //go to order history method
                            //OrderHistory();
                            break;
                        }
                    case 'f':
                        {
                            //call wallet recharge method
                            WalletRecharge();
                            break;
                        }
                    case 'g':
                        {
                            //call show balance method
                            ShowWalletBalance();
                            break;
                        }
                    case 'h':
                        {
                            //exit from submenu
                            Console.WriteLine("********EXITED FROM SUBMENU*********");
                            Console.WriteLine();
                            break;
                        }
                    default:
                        {
                            //display invalid choice
                            Console.WriteLine("Invalid choice! please enter correct options!");
                            Console.WriteLine();
                            break;
                        }
                }
            } while (choice != 'h');
        }

        public static void WalletRecharge()
        {
            //ask user the amount they  wanna recharge
            Console.Write("Enter the amount u wanna recharge: ");
            double amount = double.Parse(Console.ReadLine());
            currentCustomer.WalletRecharge(amount);
            ShowWalletBalance();
        }

        public static void ShowWalletBalance()
        {
            //show users current _balance
            Console.WriteLine("Your current wallet balance is Rs." + currentCustomer.WalletBalance);
        }
        public static void ShowMyProfile()
        {
            //show current logged in user's details
            Console.WriteLine("-------------USER PROFILE---------------");
            Console.WriteLine("Customer ID: " + currentCustomer.CustomerId);
            Console.WriteLine("Name: " + currentCustomer.Name);
            Console.WriteLine("Father's Name: " + currentCustomer.FatherName);
            Console.WriteLine("Mobile Number: " + currentCustomer.Mobile);
            Console.WriteLine("Gender: " + currentCustomer.Gender);
            Console.WriteLine("Maild ID: " + currentCustomer.MailId);
            Console.WriteLine("Dob: " + currentCustomer.Dob.ToString("dd/MM/yyyy"));
            Console.WriteLine("Location: " + currentCustomer.Location);
            ShowWalletBalance();
            Console.WriteLine();
        }
    }
}
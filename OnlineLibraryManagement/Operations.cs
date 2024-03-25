using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public class Operations
    {
        public static List<UserDetails> listOfUserDetails = new List<UserDetails>();
        public static List<BookDetails> listOfBookDetails = new List<BookDetails>();
        public static List<BorrowDetails> listOfBorrowDetails = new List<BorrowDetails>();
        public static UserDetails currentUser;
        public static void MainMenu()
        {
            int choice = 3;
            do
            {
                //display mainmenu contents
                Console.WriteLine("------------------SYNCFUSION COLLEGE LIBRARY PORTAL-------------------");
                Console.WriteLine("**** Main menu *****");
                Console.WriteLine("1.UserRegistration\n2.UserLogin\n3.Exit");
                //ask user for mainmenu choice
                Console.Write("Enter any option: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("--------------EXITED-------------");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Option!");
                            break;
                        }
                }

            } while (choice != 3);
        }

        public static void DefaultDatas()
        {
            //adding some default values to all classes list
            UserDetails user1 = new UserDetails("Ravichandran", Genders.Male, Departments.EEE, "9938388333", "ravi@gmail.com", 100);
            listOfUserDetails.Add(user1);
            UserDetails user2 = new UserDetails("Priyadharshini", Genders.Female, Departments.CSE, "9944444455", "priya@gmail.com", 150);
            listOfUserDetails.Add(user2);
            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            listOfBookDetails.Add(book1);
            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            listOfBookDetails.Add(book2);
            BookDetails book3 = new BookDetails("CSS", "Author1", 3);
            listOfBookDetails.Add(book3);
            BookDetails book4 = new BookDetails("JS", "Author1", 3);
            listOfBookDetails.Add(book4);
            BookDetails book5 = new BookDetails("TS", "Author2", 2);
            listOfBookDetails.Add(book5);
            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", new DateTime(2023, 09, 10), 2, Status.Borrowed, 0);
            listOfBorrowDetails.Add(borrow1);
            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", new DateTime(2023, 09, 12), 1, Status.Borrowed, 0);
            listOfBorrowDetails.Add(borrow2);
            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", new DateTime(2023, 09, 14), 1, Status.Returned, 16);
            listOfBorrowDetails.Add(borrow3);
            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", new DateTime(2023, 09, 11), 2, Status.Borrowed, 0);
            listOfBorrowDetails.Add(borrow4);
            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", new DateTime(2023, 09, 09), 1, Status.Returned, 20);
            listOfBorrowDetails.Add(borrow5);

        }
        public static void Registration()
        {
            //add new user to userdetails list
            Console.WriteLine("_____REGISTRATION_______");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Gender: ");
            Genders gender = Enum.Parse<Genders>(Console.ReadLine(), true);
            Console.Write("Department: ");
            Departments department = Enum.Parse<Departments>(Console.ReadLine(), true);
            Console.Write("Mobile: ");
            string mobile = Console.ReadLine();
            Console.Write("Mail ID: ");
            string mail = Console.ReadLine();
            Console.Write("Amount for WalletBalance: ");
            int walletBalance = int.Parse(Console.ReadLine());
            UserDetails user = new UserDetails(name, gender, department, mobile, mail, walletBalance);
            listOfUserDetails.Add(user);
            Console.WriteLine("Registration successfull! ur userId is " + user.UserId);
        }

        public static void Login()
        {
            //if user enter correct user id then login .. else display invalid "userId"
            Console.WriteLine("__________________LOGIN____________________");
            Console.Write("Enter ur UserID: ");
            string userId = Console.ReadLine();
            bool isIdPresent = false;
            foreach (UserDetails user in listOfUserDetails)
            {
                if (user.UserId == userId)
                {
                    isIdPresent = true;
                    currentUser = user;
                    Console.WriteLine("Login Successfull!");
                    //call submenu if login is successfull
                    submenu();
                    break;
                }
            }
            if (!isIdPresent)
            {
                Console.WriteLine("Invalid ID!");
            }
        }
        public static void submenu()
        {
            int choice = 5;

            do
            {
                Console.WriteLine("***********************************************");
                Console.WriteLine("1.Borrowbook\n2.ShowBorrowedhistory\n3.ReturnBooks\n4.WalletRecharge\n5.Exit");
                //ask user for submenu choice
                Console.Write("Enter any option: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Borrowbook();
                            break;
                        }
                    case 2:
                        {
                            BorrowedHistory();
                            break;
                        }
                    case 3:
                        {
                            ReturnBooks();
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Enter the amount to recharge: ");
                            int amount = int.Parse(Console.ReadLine());
                            currentUser.WalletRecharge(amount);
                            Console.WriteLine("Current Wallet Balance is Rs." + currentUser.WalletBalance);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("--------------EXITED-------------");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Option!");
                            break;
                        }
                }
            } while (choice != 5);

        }
        public static void BorrowedHistory()
        {
            string line = "-----------------------------------------------------------------------------------------";
            bool isNoBorrowedHistory = false;
            Console.WriteLine(line);
            Console.WriteLine($"|{"BorrowID",-10}|{"Book ID",-10}|{"User ID",-10}|{"Borrowed Date",-10}|{"Borrowed Book Count",-10}|{"Status",-6}|{"Paid Fine Amount",-10}|");
            Console.WriteLine(line);
            foreach (BorrowDetails borrow in listOfBorrowDetails)
            {
                if (borrow.UserId == currentUser.UserId)
                {
                    isNoBorrowedHistory = true;
                    Console.WriteLine($"|{borrow.BorrowId,-10}|{borrow.BookId,-10}|{borrow.UserId,-10}|{borrow.BorrowedDate.ToString("dd/MM/yyyy"),-12}|{borrow.BorrowBookCount,-17}|{borrow.BookStatus,-10}|{borrow.PaidFineAmount,-10}|");
                    Console.WriteLine(line);
                }
            }
            if (!isNoBorrowedHistory)
            {
                Console.WriteLine("No borrowed history found!");
            }
        }
        public static void Borrowbook()
        {
            //printing available books
            string line = "-----------------------------------------------------------------------------------------";
            Console.WriteLine(line);
            Console.WriteLine($"|{"BookID",-10}|{"Book Name",-10}|{"Author Name",-10}|{"Book Count",-10}|");
            Console.WriteLine(line);
            foreach (BookDetails book in listOfBookDetails)
            {
                Console.WriteLine($"|{book.BookId,-10}|{book.BookName,-10}|{book.AuthorName,-10}|{book.BookCount,-10}|");
                Console.WriteLine(line);
            }
            //ask user the book they wanna borrow
            Console.Write("Enter the Book ID u wanna borrow :");
            string bookId = Console.ReadLine();
            bool isBookAvailable = false;
            int bookCount;
            foreach (BookDetails book in listOfBookDetails)
            {
                if (bookId == book.BookId)
                {
                    isBookAvailable = true;
                    int userBorrowedBookCount = 0;
                    //ask user to enter count of book
                    Console.Write("Enter the book count u wanna borrow: ");
                    bookCount = int.Parse(Console.ReadLine());
                    if (bookCount <= book.BookCount)
                    {
                        foreach (BorrowDetails checkBorrowCount in listOfBorrowDetails)
                        {
                            if (currentUser.UserId == checkBorrowCount.UserId && checkBorrowCount.BookStatus==Status.Borrowed)
                            {
                                userBorrowedBookCount += checkBorrowCount.BorrowBookCount;
                            }
                        }
                        if (userBorrowedBookCount + bookCount > 3 )
                        {
                            Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {userBorrowedBookCount - bookCount} and requested count is {bookCount}, which exceeds 3 ");
                            break;
                        }
                        else
                        {
                            BorrowDetails borrowObj = new BorrowDetails(bookId, currentUser.UserId, DateTime.Now.Date, bookCount, Status.Borrowed, 0);
                            listOfBorrowDetails.Add(borrowObj);
                            Console.WriteLine("Book borrowed succesfully! ur borrow ID is " + borrowObj.BorrowId);
                            book.BookCount -= bookCount;
                            break;
                        }

                    }

                    else
                    {
                        Console.WriteLine("Book not available for selected count");
                        foreach (BorrowDetails borrow in listOfBorrowDetails)
                        {
                            if (borrow.BookId == bookId)
                            {
                                Console.WriteLine("Book will be available on " + borrow.BorrowedDate.AddDays(15).ToString("dd/MM/yyyy"));
                                break;
                            }
                        }
                    }

                }
            }
            if (!isBookAvailable)
            {
                Console.WriteLine("Invalid Book Id");
            }

        }
        public static void ReturnBooks()
        {
            string line = "-----------------------------------------------------------------------------------------";
            bool isNoBorrowedHistory = false;
            Console.WriteLine(line);
            Console.WriteLine($"|{"BorrowID",-10}|{"Book ID",-10}|{"User ID",-10}|{"Borrowed Date",-10}|{"Borrowed Book Count",-10}|{"Return Date",-6}|{"Fine Amount",-10}|{"Paid Fine Amount",-10}|");
            Console.WriteLine(line);
            foreach (BorrowDetails borrow in listOfBorrowDetails)
            {
                if (borrow.UserId == currentUser.UserId && borrow.BookStatus == Status.Borrowed)
                {
                    isNoBorrowedHistory = true;
                    int fineAmount = 0;
                    TimeSpan diff = DateTime.Now - borrow.BorrowedDate;
                    if (diff.TotalDays > 15)
                    {
                        fineAmount = (int)diff.TotalDays;
                    }
                    Console.WriteLine($"|{borrow.BorrowId,-10}|{borrow.BookId,-10}|{borrow.UserId,-10}|{borrow.BorrowedDate.ToString("dd/MM/yyyy"),-12}|{borrow.BorrowBookCount,-17}|{borrow.BorrowedDate.AddDays(15).ToString("dd/MM/yyy"),-10}|{fineAmount,-10}|{borrow.PaidFineAmount}");
                    Console.WriteLine(line);
                }
            }
            if (!isNoBorrowedHistory)
            {
                Console.WriteLine("No books borrowed!");
            }
            else
            {
                bool isBorrowedIdPresent = false;
                Console.Write("Enter the borrowed ID u wanna return: ");
                string borrowedId = Console.ReadLine();
                foreach (BorrowDetails returnbook in listOfBorrowDetails)
                {
                    if (borrowedId == returnbook.BorrowId)
                    {
                        isBorrowedIdPresent = true;
                        TimeSpan diff = DateTime.Now - returnbook.BorrowedDate;
                        if (diff.TotalDays > 15)
                        {
                            if (currentUser.WalletBalance >= diff.TotalDays)
                            {
                                currentUser.DeductBalance((int)diff.TotalDays);
                                returnbook.BookStatus = Status.Returned;
                                returnbook.PaidFineAmount = (int)diff.TotalDays;
                                Console.WriteLine("Book returned Successfully!");
                                foreach (BookDetails book in listOfBookDetails)
                                {
                                    if (returnbook.BookId == book.BookId)
                                    {
                                        book.BookCount += returnbook.BorrowBookCount;
                                        break;

                                    }
                                }
                                break;

                            }
                            else
                            {
                                Console.WriteLine("Insufficient Balance! please recharge ur wallet.");
                            }
                            break;
                        }
                        else
                        {
                            currentUser.DeductBalance((int)diff.TotalDays);
                            returnbook.BookStatus = Status.Returned;
                            returnbook.PaidFineAmount = (int)diff.TotalDays;
                            Console.WriteLine("Book returned Successfully!");
                            foreach (BookDetails book in listOfBookDetails)
                            {
                                if (returnbook.BookId == book.BookId)
                                {
                                    book.BookCount += returnbook.BorrowBookCount;
                                    break;

                                }
                            }
                            break;

                        }
                    }
                }
                if (!isBorrowedIdPresent)
                {
                    Console.WriteLine("Invalid borrow ID");
                }
            }

        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public enum Status{Default,Borrowed,Returned}
    public class BorrowDetails
    {
        private static int s_borrowId=2000;
        public string BorrowId { get;  }
        public string BookId { get; set; }
        public string UserId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public int BorrowBookCount { get; set; }
        public Status BookStatus{get; set;}
        public int PaidFineAmount { get; set; }
        public BorrowDetails(string bookId, string userId, DateTime borrowedDate, int borrowBookCount,Status bookStatus, int fineAmount)
        {
            s_borrowId++;
            BorrowId="LB"+s_borrowId;
            BookId=bookId;
            UserId=userId;
            BorrowedDate=borrowedDate;
            BookStatus=bookStatus;
            PaidFineAmount=fineAmount;
            BorrowBookCount=borrowBookCount;

        }
    }
}
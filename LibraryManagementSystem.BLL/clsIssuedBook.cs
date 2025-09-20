using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL
{
    public class clsIssuedBook {

        public enum enMode { AddNew, Update }
        public enMode Mode { get; private set; }

        // Properties
        public int ID { get; private set; }
        public int CopyID { get; set; }
        public clsBookCopy Copy { get; set; }
        public int MemberID { get; set; }
        public clsMember MemberInfo { get; set; }
        public int IssuedBy { get; set; } 
        public clsUser IssuedUser { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; private set; }

        // Constructor for new IssuedBook
        public clsIssuedBook() {
            ID = -1;
            CopyID = -1;
            MemberID = -1;
            IssuedBy = -1;
            IssueDate = DateTime.Now;
            DueDate = DateTime.Now;
            ReturnDate = DateTime.Now;
            IsReturned = false;

            Mode = enMode.AddNew;
        }

        // Private constructor for existing IssuedBook
        private clsIssuedBook(int ID, int copyID, int memberID, int issuedBy, DateTime issueDate, 
                    DateTime dueDate, DateTime returnDate, bool isReturned) {
            this.ID = ID;
            this.CopyID = copyID;
            this.Copy = clsBookCopy.Find(this.CopyID);
            this.MemberID = memberID;
            this.MemberInfo = clsMember.Find(this.MemberID);
            this.IssuedBy = issuedBy;
            this.IssuedUser = clsUser.Find(this.IssuedBy);
            this.IssueDate = issueDate;
            this.DueDate = dueDate;
            this.ReturnDate = returnDate;
            this.IsReturned = isReturned;

            Mode = enMode.Update;
        }

        private bool _AddNewIssuedBook() {
            this.ID = clsIssuedBookData.AddNewIssuedBook(this.CopyID, this.MemberID, this.IssuedBy, this.DueDate);
            return (this.ID != -1);
        }

        private bool _UpdateIssuedBook() {
            return clsIssuedBookData.UpdateIssuedBook(this.ID, this.CopyID, this.MemberID, this.DueDate, this.ReturnDate, this.IsReturned);
        }

        // 🔹 Find
        public static clsIssuedBook Find(int issueID) {
            DateTime issueDate = DateTime.Now, dueDate = DateTime.Now, returnDate = DateTime.Now;
            bool isReturned = false;
            int copyID = -1, memberID = -1, issuedBy = -1;

            bool isFound = clsIssuedBookData.GetIssuedBookInfoByID(issueID, ref copyID, ref memberID, ref issuedBy, ref issueDate, ref dueDate, ref returnDate, ref isReturned);

            if (!isFound) return null;

            return new clsIssuedBook(issueID, copyID, memberID, issuedBy, issueDate, dueDate, returnDate, isReturned);
        }

        // 🔹 Save (Insert or Update)
        public bool Save() {
            switch (Mode) {
                case enMode.AddNew:
                    if (_AddNewIssuedBook()){
                        Mode = enMode.Update;
                        return true;
                    }else{
                        return false;
                    }
                case enMode.Update:
                    return _UpdateIssuedBook();
            }
            return false;
        }

        // 🔹 Delete
        public static bool Delete(int issueID) {
            return clsIssuedBookData.DeleteIssuedBook(issueID);
        }


        // 🔹 Get all IssuedBooks
        public static DataTable GetAllIssuedBooks() {
            return clsIssuedBookData.GetAllIssuedBooks();
        }

        public static bool MarkBookAsReturned(int issueID) {
            return clsIssuedBookData.MarkBookAsReturned(issueID);
        }

        public static bool IsBookReturned(int issueID) {
            return clsIssuedBookData.IsBookReturned(issueID);
        }

    }
}

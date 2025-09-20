using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibraryManagementSystem.BLL
{
    public class clsBookCopy {

        public enum enMode { AddNew, Update }
        public enMode Mode { get; private set; }

        public enum enStatus : byte { Available = 1, Issued = 2, Damaged = 3, Lost = 4 }

        // Properties
        public int ID { get; private set; }
        public int BookID { get; set; }
        public clsBook Book { get; private set; }
        public enStatus Status { get; set; } 
        public DateTime DateAdded { get; private set; }

        // Constructor for new BookCopy
        public clsBookCopy() {
            ID = -1;
            BookID = -1;
            Status = enStatus.Available;
            DateAdded = DateTime.Now;

            Mode = enMode.AddNew;
        }

        // Private constructor for existing BookCopy
        private clsBookCopy(int copyID, int bookID, enStatus status, DateTime dateAdded) {
            this.ID = copyID;
            this.BookID = bookID;
            this.Book = clsBook.Find(this.BookID);
            this.Status = status;
            this.DateAdded = dateAdded;

            Mode = enMode.Update;
        }

        private bool _AddNewBookCopy() {
            this.ID = clsBookCopyData.AddNewBookCopy(this.BookID, (byte)this.Status);
            return (this.ID != -1);
        }

        private bool _UpdateBookCopy() {
            return clsBookCopyData.UpdateBookCopy(this.ID, this.BookID, (byte)this.Status);
        }

        // 🔹 Find
        public static clsBookCopy Find(int copyID) {
            DateTime dateAdded = DateTime.Now;
            byte status = (byte)enStatus.Available;
            int bookID = -1;

            bool isFound = clsBookCopyData.GetBookCopyInfoByID(copyID, ref bookID, ref status, ref dateAdded);

            if (!isFound) return null;

            return new clsBookCopy(copyID, bookID, (enStatus)status, dateAdded);
        }

        // 🔹 Save (Insert or Update)
        public bool Save() {
            switch (Mode) {
                case enMode.AddNew:
                    if (_AddNewBookCopy()){
                        Mode = enMode.Update;
                        return true;
                    }else{
                        return false;
                    }
                case enMode.Update:
                    return _UpdateBookCopy();
            }
            return false;
        }

        // 🔹 Delete
        public static bool Delete(int copyID) {
            return clsBookCopyData.DeleteBookCopy(copyID);
        }

        public bool UpdateStatus(enStatus status) {
            return clsBookCopyData.UpdateBookCopyStatus(this.ID, (byte)status);
        }

        // 🔹 Get all BookCopies
        public static DataTable GetAllBookCopies() {
            return clsBookCopyData.GetAllBookCopies();
        }

        public static bool IsBookIssued(int copyID) {
            return clsBookCopyData.IsBookIssued(copyID);
        }

        public static bool IsBookAvailable(int copyID) {
            return clsBookCopyData.IsBookAvailable(copyID);
        }

    }
}

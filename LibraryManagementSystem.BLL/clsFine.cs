using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL
{
    public class clsFine {

        public enum enMode { AddNew, Update }
        public enMode Mode { get; private set; }

        // Properties
        public int ID { get; private set; }
        public int IssueID { get; set; }
        public float Amount { get; set; } 
        public bool Paid { get; set; }
        public DateTime DatePaid { get; private set; }

        // Constructor for new Fine
        public clsFine() {
            ID = -1;
            IssueID = -1;
            Amount = 0.0f;
            Paid = false;
            DatePaid = DateTime.Now;

            Mode = enMode.AddNew;
        }

        // Private constructor for existing Fine
        private clsFine(int fineID, int issueID, float amount, bool paid, DateTime datePaid) {
            this.ID = fineID;
            this.IssueID = issueID;
            this.Amount = amount;
            this.Paid = paid;
            this.DatePaid = datePaid;

            Mode = enMode.Update;
        }

        private bool _AddNewFine() {
            this.ID = clsFineData.AddNewFine(this.IssueID);
            return (this.ID != -1);
        }

        //private bool _UpdateFine() {
        //    //return clsFineData.UpdateFine(this.ID, this.Amount, this.Paid, this.DatePaid);
        //}

        // 🔹 Find
        public static clsFine Find(int fineID) {
            DateTime datePaid = DateTime.Now;
            float amount = 0.0f;
            int issueID = -1;
            bool paid = false;

            bool isFound = clsFineData.GetFineInfoByID(fineID, ref issueID, ref amount, ref paid, ref datePaid);

            if (!isFound) return null;

            return new clsFine(fineID, issueID, amount, paid, datePaid);
        }

        // 🔹 Save (Insert or Update)
        public bool Save() {
            switch (Mode) {
                case enMode.AddNew:
                    if (_AddNewFine()){
                        Mode = enMode.Update;
                        return true;
                    }else{
                        return false;
                    }
                case enMode.Update:
                    return false;
                    //return _UpdateFine();
            }
            return false;
        }

        // 🔹 Delete
        public static bool Delete(int fineID) {
            return clsFineData.DeleteFine(fineID);
        }

        // 🔹 Get all BookCopies
        public static DataTable GetAllFines() {
            return clsFineData.GetAllFines();
        }

        public static bool PayFine(int fineID) {
            return clsFineData.PayFine(fineID);
        }
    }
}

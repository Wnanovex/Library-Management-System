using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibraryManagementSystem.BLL
{
    public class clsMember : clsPerson {

        public enum enMode { AddNew, Update }
        public enMode Mode { get; private set; }

        // Properties
        public int ID { get; private set; }
        public int PersonID { get; private set; } 
        public DateTime DateJoined { get; private set; }

        // Constructor for new Member
        public clsMember() : base() {
            ID = -1;
            PersonID = -1;
            DateJoined = DateTime.Now;

            Mode = enMode.AddNew;
        }

        // Private constructor for existing Member
        private clsMember(int personID_Base, string firstName, string lastName, DateTime dateOfBirth,
                          string gender, string email, string phone,
                          string address, string city, DateTime createdAt, DateTime updatedAt,
                int memberID, int personID, DateTime dateJoined)
                : base(personID_Base, firstName, lastName, dateOfBirth, gender, email, phone, address, city, createdAt, updatedAt)
        {
            this.ID = memberID;
            this.PersonID = personID;
            this.DateJoined = dateJoined;

            Mode = enMode.Update;
        }

        private bool _AddNewMember() {
            this.ID = clsMemberData.AddNewMember(this.PersonID);
            return (this.ID != -1);
        }

        //private bool _UpdateMember() {
        //    return clsMemberData.UpdateMember(this.MemberID, this.PersonID, this.Membername, this.Password ,this.Role, this.isActive);
        //}


        // 🔹 Find
        public static clsMember Find(int memberID) {
            DateTime dateJoined = DateTime.Now;
            int personID = -1;

            bool isFound = clsMemberData.GetMemberInfoByID(memberID, ref personID, ref dateJoined);

            if (!isFound) return null;

            clsPerson person = clsPerson.Find(personID);

            return new clsMember(person.ID, person.FirstName, person.LastName, person.DateOfBirth, person.Gender,
                person.Email, person.Phone, person.Address, person.City, person.CreatedAt, person.UpdatedAt,
                memberID, personID, dateJoined);
        }

        public static clsMember FindByPersonID(int personID) {
            DateTime dateJoined = DateTime.Now;
            int memberID = -1;

            bool isFound = clsMemberData.GetMemberInfoByPersonID(ref memberID, personID, ref dateJoined);

            if (!isFound) return null;

            clsPerson person = clsPerson.Find(personID);

            return new clsMember(person.ID, person.FirstName, person.LastName, person.DateOfBirth, person.Gender,
                person.Email, person.Phone, person.Address, person.City, person.CreatedAt, person.UpdatedAt,
                memberID, personID, dateJoined);
        }


        // 🔹 Save (Insert or Update)
        public bool Save() {
            base.Mode = (clsPerson.enMode) Mode;
            if (!base.Save()) return false;
            this.PersonID = base.ID;

            switch (Mode) {
                case enMode.AddNew:
                    if (_AddNewMember()){
                        Mode = enMode.Update;
                        return true;
                    }else{
                        return false;
                    }
                case enMode.Update:
                    //return _UpdateMember();
                    return true;
            }
            return false;
        }

        // 🔹 Delete
        public bool Delete() {
            if (!clsMemberData.DeleteMember(this.ID)) return false;
            return base.Delete();
        }

        // 🔹 Exists
        public static bool isMemberExist(int memberID) {
            return clsMemberData.IsMemberExist(memberID);
        }

        // 🔹 Get all Members
        public static DataTable GetAllMembers() {
            return clsMemberData.GetAllMembers();
        }


    }
}

using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace LibraryManagementSystem.BLL
{
    public class clsPerson {

        public enum enMode { AddNew, Update }
        public enMode Mode { get; set; }

        // Properties
        public int ID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }  // "M" / "F"
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public string FullName => $"{FirstName} {LastName}";

        // Constructor for new person
        public clsPerson() {
            ID = -1;
            FirstName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            Gender = null;
            Email = "";
            Phone = "";
            Address = "";
            City = "";
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

            Mode = enMode.AddNew;
        }

        // Private constructor for existing person
        protected clsPerson(int personID, string firstName, string lastName, DateTime dateOfBirth,
                          string gender, string email, string phone,
                          string address, string city, DateTime createdAt, DateTime updatedAt) {
            ID = personID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;

            Mode = enMode.Update;
        }

        private bool _AddNewPerson() {
            this.ID = clsPersonData.AddNewPerson(
                this.FirstName,this.LastName ,this.DateOfBirth,
                this.Gender, this.Email, this.Phone, this.Address, this.City);
            return (this.ID != -1);
        }

        private bool _UpdatePerson() {
            return clsPersonData.UpdatePerson(
                this.ID, this.FirstName, this.LastName ,this.DateOfBirth,
                this.Gender, this.Email, this.Phone, this.Address, this.City);
        }

        // 🔹 Find
        public static clsPerson Find(int personID) {
            string firstName = "", lastName = "", gender = "", email = "", phone = "", address = "", city = "";
            DateTime dateOfBirth = DateTime.Now;
            DateTime createdAt = DateTime.Now, updatedAt = DateTime.Now;

            bool isFound = clsPersonData.GetPersonInfoByID(personID,
                ref firstName, ref lastName, ref dateOfBirth,
                ref gender, ref email, ref phone,
                ref address, ref city, ref createdAt, ref updatedAt);

            if (!isFound) return null;

            return new clsPerson(personID, firstName, lastName, dateOfBirth, gender, email, phone, address, city, createdAt, updatedAt);
        }

        // 🔹 Save (Insert or Update)
        public bool Save() {
            switch (Mode) {
                case enMode.AddNew:
                    if (_AddNewPerson()){
                        Mode = enMode.Update;
                        return true;
                    }else{
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }

        // 🔹 Delete
        public bool Delete() {
            return clsPersonData.DeletePerson(this.ID);
        }

        // 🔹 Exists
        public static bool isPersonExists(int personID) {
            return clsPersonData.IsPersonExist(personID);
        }

        // 🔹 Get all people
        public static DataTable GetAllPeople() {
            return clsPersonData.GetAllPeople();
        }

    }
}

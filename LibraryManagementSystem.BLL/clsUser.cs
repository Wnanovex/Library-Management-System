using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL
{
    public class clsUser : clsPerson {

        public enum enMode { AddNew, Update }
        public enMode Mode { get; private set; }

        // Properties
        public int ID { get; private set; }
        public int PersonID { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte Role { get; set; } 
        public DateTime LastLogin { get; private set; }
        public bool isActive { get; set; }

        // Constructor for new user
        public clsUser() : base() {
            this.ID = -1;
            PersonID = -1;
            Username = "";
            Password = "";
            Role = 0;
            LastLogin = DateTime.Now;
            isActive = false;

            Mode = enMode.AddNew;
        }

        // Private constructor for existing user
        private clsUser(int personID_Base, string firstName, string lastName, DateTime dateOfBirth,
                          string gender, string email, string phone,
                          string address, string city, DateTime createdAt, DateTime updatedAt,
            int userID, int personID, string username, string password, byte role, DateTime lastLogin, bool isActive)
            : base(personID_Base, firstName, lastName, dateOfBirth, gender, email, phone, address, city, createdAt, updatedAt)
        {
            this.ID = userID;
            this.PersonID = personID;
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.LastLogin = lastLogin;
            this.isActive = isActive;

            Mode = enMode.Update;
        }

        private bool _AddNewUser() {
            this.ID = clsUserData.AddNewUser(this.PersonID,this.Username ,this.Password, this.Role, this.isActive);
            return (this.ID != -1);
        }

        private bool _UpdateUser() {
            return clsUserData.UpdateUser(this.ID, this.Username, this.Password ,this.Role, this.isActive);
        }

        // 🔹 Find
        public static clsUser Find(int userID) {
            string username = "", password = "";
            DateTime lastLogin = DateTime.Now;
            byte role = 0;
            bool isActive = false;
            int personID = -1;

            bool isFound = clsUserData.GetUserInfoByID(userID, ref personID, ref username, ref password, ref role, ref lastLogin, ref isActive);

            if (!isFound) return null;

            clsPerson person = clsPerson.Find(personID);

            return new clsUser(person.ID, person.FirstName, person.LastName, person.DateOfBirth, person.Gender,
                person.Email, person.Phone, person.Address, person.City, person.CreatedAt, person.UpdatedAt,
                userID, personID, username, password, role, lastLogin, isActive);
        }

        public static clsUser FindByPersonID(int personID) {
            string username = "", password = "";
            DateTime lastLogin = DateTime.Now;
            byte role = 0;
            bool isActive = false;
            int userID = -1;

            bool isFound = clsUserData.GetUserInfoByPersonID(ref userID, personID, ref username, ref password, ref role, ref lastLogin, ref isActive);

            if (!isFound) return null;

            clsPerson person = clsPerson.Find(personID);

            return new clsUser(person.ID, person.FirstName, person.LastName, person.DateOfBirth, person.Gender,
                person.Email, person.Phone, person.Address, person.City, person.CreatedAt, person.UpdatedAt,
                userID, personID, username, password, role, lastLogin, isActive);
        }

        public static clsUser Find(string username, string password) {
            DateTime lastLogin = DateTime.Now;
            byte role = 0;
            bool isActive = false;
            int personID = -1, userID = -1;

            bool isFound = clsUserData.GetUserInfoByUsernameAndPassword(ref userID, ref personID, username, password, ref role, ref lastLogin, ref isActive);

            if (!isFound) return null;

            clsPerson person = clsPerson.Find(personID);

            return new clsUser(person.ID, person.FirstName, person.LastName, person.DateOfBirth, person.Gender,
                person.Email, person.Phone, person.Address, person.City, person.CreatedAt, person.UpdatedAt,
                userID, personID, username, password, role, lastLogin, isActive);
        }

        // 🔹 Save (Insert or Update)
        public bool Save() {
            base.Mode = (clsPerson.enMode) Mode;
            if (!base.Save()) return false;
            this.PersonID = base.ID;

            switch (Mode) {
                case enMode.AddNew:
                    if (_AddNewUser()){
                        Mode = enMode.Update;
                        return true;
                    }else{
                        return false;
                    }
                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }

        // 🔹 Delete
        public bool Delete() {            
            if (!clsUserData.DeleteUser(this.ID)) return false;
            return base.Delete();
        }

        // 🔹 Exists
        public static bool isUserExist(int userID) {
            return clsUserData.IsUserExist(userID);
        }

        // 🔹 Get all users
        public static DataTable GetAllUsers() {
            return clsUserData.GetAllUsers();
        }

        public bool ChangePassword(string new_password) {
            bool isSuccessed = clsUserData.ChangePassword(this.ID, new_password);
            if(isSuccessed) this.Password = new_password;
            return isSuccessed;
        }

    }
}

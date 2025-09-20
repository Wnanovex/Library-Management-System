using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL
{
    public class clsAuthor : clsPerson {

        public enum enMode { AddNew, Update }
        public enMode Mode { get; private set; }

        // Properties
        public int ID { get; private set; }
        public int PersonID { get; private set; }
        public string Biography { get; set; }

        // Constructor for new author
        public clsAuthor() : base() {
            ID = -1;
            PersonID = -1;
            Biography = "";

            Mode = enMode.AddNew;
        }

        // Private constructor for existing author
        private clsAuthor(int personID_Base, string firstName, string lastName, DateTime dateOfBirth,
                          string gender, string email, string phone,
                          string address, string city, DateTime createdAt, DateTime updatedAt,
            int authorID, int personID, string biography) 
            : base(personID_Base, firstName, lastName, dateOfBirth, gender, email, phone, address, city, createdAt, updatedAt)
        {
            this.ID = authorID;
            this.PersonID = personID;
            this.Biography = biography;

            Mode = enMode.Update;
        }

        private bool _AddNewAuthor() {
            this.ID = clsAuthorData.AddNewAuthor(this.PersonID,this.Biography);
            return (this.ID != -1);
        }

        private bool _UpdateAuthor() {
            return clsAuthorData.UpdateAuthor(this.ID, this.Biography);
        }

        // 🔹 Find
        public static clsAuthor Find(int authorID) {
            string biography = "";
            int personID = -1;

            bool isFound = clsAuthorData.GetAuthorInfoByID(authorID, ref personID, ref biography);

            if (!isFound) return null;

            clsPerson person = clsPerson.Find(personID);

            return new clsAuthor(person.ID, person.FirstName, person.LastName, person.DateOfBirth, person.Gender,
                person.Email, person.Phone, person.Address, person.City, person.CreatedAt, person.UpdatedAt,
                authorID, personID, biography);
        }

        public static clsAuthor FindByPersonID(int personID) {
            string biography = "";
            int authorID = -1;

            bool isFound = clsAuthorData.GetAuthorInfoByPersonID(ref authorID, personID, ref biography);

            if (!isFound) return null;

            clsPerson person = clsPerson.Find(personID);

            return new clsAuthor(person.ID, person.FirstName, person.LastName, person.DateOfBirth, person.Gender,
                person.Email, person.Phone, person.Address, person.City, person.CreatedAt, person.UpdatedAt,
                authorID, personID, biography);
        }

        // 🔹 Save (Insert or Update)
        public bool Save() {
            base.Mode = (clsPerson.enMode) Mode;
            if (!base.Save()) return false;
            this.PersonID = base.ID;

            switch (Mode) {
                case enMode.AddNew:
                    if (_AddNewAuthor()){
                        Mode = enMode.Update;
                        return true;
                    }else{
                        return false;
                    }
                case enMode.Update:
                    return _UpdateAuthor();
            }
            return false;
        }

        // 🔹 Delete
        public bool Delete() {
            if (!clsAuthorData.DeleteAuthor(this.ID)) return false;
            return base.Delete();
        }

        // 🔹 Exists
        public static bool isAuthorExist(int authorID) {
            return clsAuthorData.IsAuthorExist(authorID);
        }

        // 🔹 Get all authors
        public static DataTable GetAllAuthors() {
            return clsAuthorData.GetAllAuthors();
        }


    }
}

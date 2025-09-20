using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace LibraryManagementSystem.BLL
{
    public class clsBook {

        public enum enMode { AddNew, Update }
        public enMode Mode { get; private set; }

        // Properties
        public int ID { get; private set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int CategoryID { get; set; }
        public clsCategory Category { get; private set; }
        public int AuthorID { get; set; }
        public clsAuthor Author { get; private set; }
        public string Edition { get; set; }
        public int PublishedYear { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public int TotalCopies { get; set; }
        public string ShelfLocation { get; set; }
        public float DailyRate { get; set; }
        public string ImageName { get; set; }
        public DateTime DateAdded { get; private set; }

        // Constructor for new Book
        public clsBook() {
            ID = -1;
            Title = "";
            ISBN = "";
            CategoryID = -1;
            AuthorID = -1;
            Edition = "";
            PublishedYear = -1;
            Language = "";
            Description = "";
            TotalCopies = -1;
            ShelfLocation = "";
            DailyRate = 0.0f;
            ImageName = "";
            DateAdded = DateTime.Now;

            Mode = enMode.AddNew;
        }

        // Private constructor for existing Book
        private clsBook(int bookID, string title, string ISBN, int categoryID, int authorID, 
            string edition, int publishedYear, string language, string description, 
            int totalCopies, string shelfLocation, float dailyRate, string ImageName, DateTime dateAdded) 
        {
            this.ID = bookID;
            this.Title = title;
            this.ISBN = ISBN;
            this.CategoryID = categoryID;
            this.Category = clsCategory.Find(this.CategoryID);
            this.AuthorID = authorID;
            this.Author = clsAuthor.Find(this.AuthorID);
            this.Edition = edition;
            this.PublishedYear = publishedYear;
            this.Language = language;
            this.Description = description;
            this.TotalCopies = totalCopies;
            this.ShelfLocation = shelfLocation;
            this.DailyRate = dailyRate;
            this.ImageName = ImageName;
            this.DateAdded = dateAdded;

            Mode = enMode.Update;
        }

        private bool _AddNewBook() {
            this.ID = clsBookData.AddNewBook(this.Title,this.ISBN ,this.CategoryID, this.AuthorID, 
                                this.Edition, this.PublishedYear, this.Language, this.Description, 
                                this.TotalCopies, this.ShelfLocation, this.DailyRate, this.ImageName);
            return (this.ID != -1);
        }

        private bool _UpdateBook() {
            return clsBookData.UpdateBook(this.ID, this.Title,this.ISBN ,this.CategoryID, this.AuthorID, 
                                this.Edition, this.PublishedYear, this.Language, this.Description, 
                                this.TotalCopies, this.ShelfLocation, this.DailyRate, this.ImageName);
        }

        // 🔹 Find
        public static clsBook Find(int bookID) {
            string title = "", ISBN = "", edition = "", language = "", description = "", shelfLocation = "", imageName = "";
            DateTime dateAdded = DateTime.Now;
            int categoryID = -1, authorID = -1, publishedYear = -1, totalCopies = -1;
            float dailyRate = 0.0f;

            bool isFound = clsBookData.GetBookInfoByID(bookID, ref title, ref ISBN, ref categoryID, ref authorID, 
                            ref edition, ref publishedYear, ref language, ref description, ref totalCopies,
                            ref shelfLocation, ref dailyRate, ref imageName, ref dateAdded);

            if (!isFound) return null;

            return new clsBook(bookID, title, ISBN, categoryID, authorID, 
                            edition, publishedYear, language, description, totalCopies,
                            shelfLocation, dailyRate, imageName, dateAdded);
        }

        // 🔹 Save (Insert or Update)
        public bool Save() {
            switch (Mode) {
                case enMode.AddNew:
                    if (_AddNewBook()){
                        Mode = enMode.Update;
                        return true;
                    }else{
                        return false;
                    }
                case enMode.Update:
                    return _UpdateBook();
            }
            return false;
        }

        // 🔹 Delete
        public bool Delete() {
            return clsBookData.DeleteBook(this.ID);
        }

        // 🔹 Exists
        public static bool isBookExist(int bookID) {
            return clsBookData.IsBookExist(bookID);
        }

        // 🔹 Get all Books
        public static DataTable GetAllBooks() {
            return clsBookData.GetAllBooks();
        }

        public static DataTable GetAllBooksByCategoryID() {
            return clsBookData.GetAllBooksByCategoryID();
        }

    }
}

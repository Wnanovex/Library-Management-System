using LibraryManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibraryManagementSystem.BLL
{
    public class clsCategory {

        public enum enMode { AddNew, Update }
        public enMode Mode { get; private set; }

        // Properties
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Constructor for new Category
        public clsCategory() {
            ID = -1;
            Name = "";
            Description = "";

            Mode = enMode.AddNew;
        }

        // Private constructor for existing Category
        private clsCategory(int categoryID, string name, string description) {
            this.ID = categoryID;
            this.Name = name;
            this.Description = description;

            Mode = enMode.Update;
        }

        private bool _AddNewCategory() {
            this.ID = clsCategoryData.AddNewCategory(this.Name,this.Description);
            return (this.ID != -1);
        }

        private bool _UpdateCategory() {
            return clsCategoryData.UpdateCategory(this.ID, this.Name, this.Description);
        }

        // 🔹 Find
        public static clsCategory Find(int categoryID) {
            string name = "", description = "";

            bool isFound = clsCategoryData.GetCategoryInfoByID(categoryID, ref name, ref description);

            if (!isFound) return null;

            return new clsCategory(categoryID, name, description);
        }

        public static clsCategory FindByPersonID(string name) {
            string description = "";
            int categoryID = -1;

            bool isFound = clsCategoryData.GetCategoryInfoByName(ref categoryID, name, ref description);

            if (!isFound) return null;

            return new clsCategory(categoryID, name, description);
        }

        // 🔹 Save (Insert or Update)
        public bool Save() {
            switch (Mode) {
                case enMode.AddNew:
                    if (_AddNewCategory()){
                        Mode = enMode.Update;
                        return true;
                    }else{
                        return false;
                    }
                case enMode.Update:
                    return _UpdateCategory();
            }
            return false;
        }

        // 🔹 Delete
        public static bool Delete(int CategoryID) {
            return clsCategoryData.DeleteCategory(CategoryID);
        }


        // 🔹 Get all Categories
        public static DataTable GetAllCategories() {
            return clsCategoryData.GetAllCategories();
        }


    }
}

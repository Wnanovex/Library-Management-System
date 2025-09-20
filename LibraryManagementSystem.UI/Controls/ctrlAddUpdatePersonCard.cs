using DVLD.Global_Classes;
using LibraryManagementSystem.BLL;
using LibraryManagementSystem.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Controls
{
    public partial class ctrlAddUpdatePersonCard : UserControl
    {
         // Declare a delegate
        //public delegate void DataBackEventHandler(object sender, int PersonID);
        //// Declare an event using the delegate
        //public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGender { Male = 0, Female = 1 };

        private enMode _Mode = enMode.AddNew;
        private int _PersonID = -1;
        clsPerson _Person;

        //public clsPerson PersonInfo  {
        //    get { return _Person; }
        //}

        public string FirstName {
            get { return txtFirstName.Text; }
        }
        public string LastName {
            get { return txtLastName.Text; }
        }
        public DateTime DateOfBirth {
            get { return dtpDateOfBirth.Value; }
        }
        public string Gender {
            get { return rbMale.Checked ? "M" : "F"; }
        }
        public string Email {
            get { return txtEmail.Text; }
        }
        public string Phone {
            get { return txtPhone.Text; }
        }
        public string Address {
            get { return txtAddress.Text; }
        }
        public string City {
            get { return txtCity.Text; }
        }
           

        public ctrlAddUpdatePersonCard() {
            InitializeComponent();
        }

        public void ResetDefualtValues() {
            //this will initialize the reset the defaule values
            lblPersonIDValue.Text = "N/A";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            dtpDateOfBirth.Value = DateTime.Now;
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
        }

        public void LoadPersonData(int PersonID) {
            _PersonID = PersonID;
            _Mode = enMode.Update;
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null) {
                MessageBox.Show("No Person with ID = " + _PersonID ,"Person Not Found",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            

            //the following code will not be executed if the person was not found
            lblPersonIDValue.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            
            if (_Person.Gender == "M")
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtCity.Text = _Person.City;
        }

        private void ctrlAddUpdatePersonCard_Load(object sender, EventArgs e) {
            if (_Mode == enMode.AddNew)
                ResetDefualtValues();
        }

        public bool ValidateInputs() {
            if (!clsValidation.IsValidName(txtFirstName.Text)) {
                errorProvider1.SetError(txtFirstName, "First name is invalid.");
                txtFirstName.Focus();
                return false;
            }else
                errorProvider1.SetError(txtFirstName, "");

            if (!clsValidation.IsValidName(txtLastName.Text)) {
                errorProvider1.SetError(txtLastName, "Last name is invalid.");
                txtFirstName.Focus();
                return false;
            }else
                errorProvider1.SetError(txtLastName, "");

            if (!clsValidation.IsValidDate(dtpDateOfBirth.Value)) {
                errorProvider1.SetError(dtpDateOfBirth, "Date of birth must be at least 10 years ago.");
                return false;
            }else
                errorProvider1.SetError(dtpDateOfBirth, "");

            if (!clsValidation.IsValidPhone(txtPhone.Text)) {
                errorProvider1.SetError(txtPhone, "Phone number must be digits only (7–15).");
                txtPhone.Focus();
                return false;
            }else
                errorProvider1.SetError(txtPhone, "");

            if (!clsValidation.IsValidEmail(txtEmail.Text)) {
                errorProvider1.SetError(txtEmail, "Invalid email format.");
                txtEmail.Focus();
                return false;
            }else
                errorProvider1.SetError(txtEmail, "");

            if (!clsValidation.IsValidTextBox(txtAddress.Text)) {
                errorProvider1.SetError(txtAddress, "Address is required");
                txtAddress.Focus();
                return false;
            }else
                errorProvider1.SetError(txtAddress, "");

            if (!clsValidation.IsValidTextBox(txtCity.Text)) {
                errorProvider1.SetError(txtCity, "City is required.");
                txtCity.Focus();
                return false;
            }else
                errorProvider1.SetError(txtCity, "");

            return true;
        }
    }
}

using LibraryManagementSystem.BLL;
using LibraryManagementSystem.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Controls
{
    public partial class ctrlPersonalInfoCard : UserControl
    {
        private clsPerson _Person;

        private int _PersonID = -1;

        public int PersonID {
            get { return _PersonID; }   
        }

        public clsPerson SelectedPersonInfo {
            get { return _Person; }
        }

        public ctrlPersonalInfoCard() {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID) {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null) {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
            _FillPersonInfo();
        }

        private void _FillPersonInfo() {
            _PersonID = _Person.ID;
            lblPersonIDValue.Text=_Person.ID.ToString();
            lblFullNameValue.Text = _Person.FullName;
            lblDateOfBirthValue.Text = _Person.DateOfBirth.ToShortDateString();
            lblGenderValue.Text = _Person.Gender == "M" ? "Male" : "Female";
            lblEmailValue.Text = _Person.Email;
            lblPhoneValue.Text = _Person.Phone;
            lblCityValue.Text = _Person.City;
            lblAddressValue.Text= _Person.Address;
        }

        public void ResetPersonInfo() {
            _PersonID = -1;
            lblPersonIDValue.Text = "[????]";
            lblFullNameValue.Text = "[????]";
            lblDateOfBirthValue.Text = "[????]";
            lblGenderValue.Text = "[????]";
            lblEmailValue.Text = "[????]";
            lblPhoneValue.Text = "[????]";
            lblCityValue.Text = "[????]";
            lblAddressValue.Text = "[????]";  
        }

    }
}

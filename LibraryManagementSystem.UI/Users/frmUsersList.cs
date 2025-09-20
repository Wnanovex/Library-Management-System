using DVLD.Global_Classes;
using Guna.UI2.WinForms;
using LibraryManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Users
{
    public partial class frmUsersList : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private static DataTable _dtUsers;

        private clsUser _User = new clsUser();

        public frmUsersList() {
            InitializeComponent();
        }

        private void _ResetDefualtValues() {
            ctrlAddUpdatePersonCard1.ResetDefualtValues();
            lblUserIDValue.Text = "N/A";
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            chkIsActive.Checked = false;

            _User = new clsUser();
            _Mode = enMode.AddNew;
            lblTitle.Text = "Add New User";
        }

        public bool ValidateInputs() {
            if (!clsValidation.IsValidTextBox(txtUsername.Text)) {
                errorProvider1.SetError(txtUsername, "Username is required.");
                txtUsername.Focus();
                return false;
            }else
                errorProvider1.SetError(txtUsername, "");

            if (!clsValidation.IsValidTextBox(txtPassword.Text)) {
                errorProvider1.SetError(txtPassword, "Password is required.");
                txtPassword.Focus();
                return false;
            }else
                errorProvider1.SetError(txtPassword, "");

            if (!clsValidation.IsValidTextBox(txtConfirmPassword.Text)) {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password is required.");
                txtConfirmPassword.Focus();
                return false;
            }else
                errorProvider1.SetError(txtConfirmPassword, "");

            if (txtConfirmPassword.Text != txtPassword.Text) {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password Not much Password");
                txtConfirmPassword.Focus();
                return false;
            }else
                errorProvider1.SetError(txtConfirmPassword, "");

            return true;
        }

        private void frmUsersList_Load(object sender, EventArgs e) {
            _dtUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtUsers;
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!ctrlAddUpdatePersonCard1.ValidateInputs() || !ValidateInputs()) return;

            _User.FirstName = ctrlAddUpdatePersonCard1.FirstName;
            _User.LastName = ctrlAddUpdatePersonCard1.LastName;
            _User.DateOfBirth = ctrlAddUpdatePersonCard1.DateOfBirth;
            _User.Gender = ctrlAddUpdatePersonCard1.Gender;
            _User.Email = ctrlAddUpdatePersonCard1.Email;
            _User.Phone = ctrlAddUpdatePersonCard1.Phone;
            _User.Address = ctrlAddUpdatePersonCard1.Address;
            _User.City = ctrlAddUpdatePersonCard1.City;

            _User.Username = txtUsername.Text;
            _User.Password = txtPassword.Text;
            _User.Role = 1;
            _User.isActive = chkIsActive.Checked;

            switch(_Mode) {
                case enMode.AddNew:
                    if (_User.Save()) {
                        MessageBox.Show("User Added Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        frmUsersList_Load(null, null);
                    }else
                        MessageBox.Show("User Not Added" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case enMode.Update:
                    if (_User.Save()) {
                        MessageBox.Show("User Updated Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        frmUsersList_Load(null, null);
                    }else
                        MessageBox.Show("User Not Updated" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
            }        
        }

        private void _LoadUserData() {
            lblUserIDValue.Text = _User.ID.ToString();
            txtUsername.Text = _User.Username;
            txtPassword.Text = _User.Password;
            chkIsActive.Checked = _User.isActive;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            _ResetDefualtValues();
            _User = clsUser.Find((int)dgvUsers.CurrentRow.Cells[0].Value);
            lblTitle.Text = "Edit User";
            ctrlAddUpdatePersonCard1.LoadPersonData(_User.PersonID);
            _LoadUserData();
            _Mode = enMode.Update;
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e) {
            _User = clsUser.Find((int)dgvUsers.CurrentRow.Cells[0].Value); 
            if(MessageBox.Show("Are you sure you want to delete User [" + dgvUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                if (_User.Delete()) {
                    MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmUsersList_Load(null, null);
                }else
                    MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            _ResetDefualtValues();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e) {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible) {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e) {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text) {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None") {
                _dtUsers.DefaultView.RowFilter = "";
                //lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "UserID")
                //in this case we deal with integer not string.             
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
       
             //lblRecordsCount.Text= dgvPeople.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e) {
            //we allow number incase User id is selected.
            if (cbFilterBy.Text=="User ID")
              e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

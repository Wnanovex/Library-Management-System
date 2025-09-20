using DVLD.Global_Classes;
using LibraryManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Authors
{
    public partial class frmAuthorsList : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private static DataTable _dtAuthors;

        private clsAuthor _Author = new clsAuthor();

        public frmAuthorsList() {
            InitializeComponent();
        }

        private void _ResetDefualtValues() {
            ctrlAddUpdatePersonCard1.ResetDefualtValues();
            lblAuthorsIDValue.Text = "N/A";
            txtBiography.Clear();
            _Author = new clsAuthor();
            _Mode = enMode.AddNew;
            lblTitle.Text = "Add New Author";
        }

        public bool ValidateInputs() {
            if (!clsValidation.IsValidTextBox(txtBiography.Text)) {
                errorProvider1.SetError(txtBiography, "Biography is required.");
                txtBiography.Focus();
                return false;
            }else
                errorProvider1.SetError(txtBiography, "");

            return true;
        }

        private void frmAuthorsList_Load(object sender, EventArgs e) {
            _dtAuthors = clsAuthor.GetAllAuthors();
            dgvAuthors.DataSource = _dtAuthors;
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!ctrlAddUpdatePersonCard1.ValidateInputs() || !ValidateInputs()) return;

            _Author.FirstName = ctrlAddUpdatePersonCard1.FirstName;
            _Author.LastName = ctrlAddUpdatePersonCard1.LastName;
            _Author.DateOfBirth = ctrlAddUpdatePersonCard1.DateOfBirth;
            _Author.Gender = ctrlAddUpdatePersonCard1.Gender;
            _Author.Email = ctrlAddUpdatePersonCard1.Email;
            _Author.Phone = ctrlAddUpdatePersonCard1.Phone;
            _Author.Address = ctrlAddUpdatePersonCard1.Address;
            _Author.City = ctrlAddUpdatePersonCard1.City;

            _Author.Biography = txtBiography.Text;

            switch(_Mode) {
                case enMode.AddNew:
                    if (_Author.Save()) {
                        MessageBox.Show("Author Added Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        frmAuthorsList_Load(null, null);
                    }else
                        MessageBox.Show("Author Not Added" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case enMode.Update:
                    if (_Author.Save()) {
                        MessageBox.Show("Author Updated Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        frmAuthorsList_Load(null, null);
                    }else
                        MessageBox.Show("Author Not Updated" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
            }
            _ResetDefualtValues();
        }

        private void _LoadAuthorData() {
            lblAuthorsIDValue.Text = _Author.ID.ToString();
            txtBiography.Text = _Author.Biography;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            _ResetDefualtValues();
            _Author = clsAuthor.Find((int)dgvAuthors.CurrentRow.Cells[0].Value);
            lblTitle.Text = "Edit Author";
            ctrlAddUpdatePersonCard1.LoadPersonData(_Author.PersonID);
            _LoadAuthorData();
            _Mode = enMode.Update;
        }

        private void deleteAuthorToolStripMenuItem_Click(object sender, EventArgs e) {
            _Author = clsAuthor.Find((int)dgvAuthors.CurrentRow.Cells[0].Value); 
            if(MessageBox.Show("Are you sure you want to delete Author [" + dgvAuthors.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                if (_Author.Delete()) {
                    MessageBox.Show("Author has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmAuthorsList_Load(null, null);
                }else
                    MessageBox.Show("Author is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                case "Author ID":
                    FilterColumn = "AuthorID";
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
                _dtAuthors.DefaultView.RowFilter = "";
                //lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "AuthorID")
                //in this case we deal with integer not string.             
                _dtAuthors.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtAuthors.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
       
             //lblRecordsCount.Text= dgvPeople.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e) {
            //we allow number incase Author id is selected.
            if (cbFilterBy.Text=="Author ID")
              e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

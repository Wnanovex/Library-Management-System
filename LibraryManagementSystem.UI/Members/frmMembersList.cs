using DVLD.Global_Classes;
using LibraryManagementSystem.BLL;
using LibraryManagementSystem.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Members
{
    public partial class frmMembersList : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private static DataTable _dtMembers;

        private clsMember _Member = new clsMember();

        public frmMembersList() {
            InitializeComponent();
        }

        private void _ResetDefualtValues() {
            ctrlAddUpdatePersonCard1.ResetDefualtValues();
            lblMemberIDValue.Text = "N/A";
            _Member = new clsMember();
            _Mode = enMode.AddNew;
            lblTitle.Text = "Add New Member";
        }

        private void frmMembersList_Load(object sender, EventArgs e) {
            _dtMembers = clsMember.GetAllMembers();
            dgvMembers.DataSource = _dtMembers;
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!ctrlAddUpdatePersonCard1.ValidateInputs()) return;

            _Member.FirstName = ctrlAddUpdatePersonCard1.FirstName;
            _Member.LastName = ctrlAddUpdatePersonCard1.LastName;
            _Member.DateOfBirth = ctrlAddUpdatePersonCard1.DateOfBirth;
            _Member.Gender = ctrlAddUpdatePersonCard1.Gender;
            _Member.Email = ctrlAddUpdatePersonCard1.Email;
            _Member.Phone = ctrlAddUpdatePersonCard1.Phone;
            _Member.Address = ctrlAddUpdatePersonCard1.Address;
            _Member.City = ctrlAddUpdatePersonCard1.City;

            switch(_Mode) {
                case enMode.AddNew:
                    if (_Member.Save()) {
                        MessageBox.Show("Member Added Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        frmMembersList_Load(null, null);
                    }else
                        MessageBox.Show("Member Not Added" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case enMode.Update:
                    if (_Member.Save()) {
                        MessageBox.Show("Member Updated Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        frmMembersList_Load(null, null);
                    }else
                        MessageBox.Show("Member Not Updated" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
            }
            _ResetDefualtValues();
        }

        private void _LoadMemberData() {
            lblMemberIDValue.Text = _Member.ID.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            _ResetDefualtValues();
            _Member = clsMember.Find((int)dgvMembers.CurrentRow.Cells[0].Value);
            lblTitle.Text = "Edit Member";
            ctrlAddUpdatePersonCard1.LoadPersonData(_Member.PersonID);
            _LoadMemberData();
            _Mode = enMode.Update;
        }

        private void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e) {
            _Member = clsMember.Find((int)dgvMembers.CurrentRow.Cells[0].Value); 
            if(MessageBox.Show("Are you sure you want to delete Member [" + dgvMembers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                if (_Member.Delete()) {
                    MessageBox.Show("Member has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMembersList_Load(null, null);
                }else
                    MessageBox.Show("Member is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                case "Member ID":
                    FilterColumn = "MemberID";
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
                _dtMembers.DefaultView.RowFilter = "";
                //lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "MemberID")
                //in this case we deal with integer not string.             
                _dtMembers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtMembers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
       
             //lblRecordsCount.Text= dgvPeople.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e) {
            //we allow number incase Member id is selected.
            if (cbFilterBy.Text=="Member ID")
              e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

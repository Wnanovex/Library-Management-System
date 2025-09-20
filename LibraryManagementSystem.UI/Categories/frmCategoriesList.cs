using DVLD.Global_Classes;
using LibraryManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Categories
{
    public partial class frmCategoriesList : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private static DataTable _dtCategories;

        private clsCategory _Category = new clsCategory();

        public frmCategoriesList() {
            InitializeComponent();
        }

        private void _ResetDefualtValues() {
            lblCategoryIDValue.Text = "N/A";
            txtName.Clear();
            txtDescription.Clear();
            _Category = new clsCategory();
            _Mode = enMode.AddNew;
            lblTitle.Text = "Add New Category";
        }

        public bool ValidateInputs() {
            if (!clsValidation.IsValidTextBox(txtName.Text)) {
                errorProvider1.SetError(txtName, "Name is required.");
                txtName.Focus();
                return false;
            }else
                errorProvider1.SetError(txtName, "");

            if (!clsValidation.IsValidTextBox(txtDescription.Text)) {
                errorProvider1.SetError(txtDescription, "Description is required.");
                txtDescription.Focus();
                return false;
            }else
                errorProvider1.SetError(txtDescription, "");

            return true;
        }

        private void frmCategoriesList_Load(object sender, EventArgs e) {
            _dtCategories = clsCategory.GetAllCategories();
            dgvCategories.DataSource = _dtCategories;
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if(!ValidateInputs()) return;

            _Category.Name = txtName.Text;
            _Category.Description = txtDescription.Text;

            switch(_Mode) {
                case enMode.AddNew:
                    if (_Category.Save()) {
                        MessageBox.Show("Category Added Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        frmCategoriesList_Load(null, null);
                    }else
                        MessageBox.Show("Category Not Added" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case enMode.Update:
                    if (_Category.Save()) {
                        MessageBox.Show("Category Updated Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        frmCategoriesList_Load(null, null);
                    }else
                        MessageBox.Show("Category Not Updated" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
            }
            _ResetDefualtValues();
        }

        private void _LoadCategoryData() {
            lblCategoryIDValue.Text = _Category.ID.ToString();
            txtName.Text = _Category.Name;
            txtDescription.Text = _Category.Description;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            _ResetDefualtValues();
            _Category = clsCategory.Find((int)dgvCategories.CurrentRow.Cells[0].Value);
            lblTitle.Text = "Edit Category";
            _LoadCategoryData();
            _Mode = enMode.Update;
        }

        private void deleteCategoryToolStripMenuItem_Click(object sender, EventArgs e) {
            int CategoryID = (int)dgvCategories.CurrentRow.Cells[0].Value; 
            if(MessageBox.Show("Are you sure you want to delete Category [" + CategoryID + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                if (clsCategory.Delete(CategoryID)) {
                    MessageBox.Show("Category has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmCategoriesList_Load(null, null);
                }else
                    MessageBox.Show("Category is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                case "Category ID":
                    FilterColumn = "CategoryID";
                    break;
                case "Name":
                    FilterColumn = "Name";
                    break;
                case "Last Name":
                default:
                    FilterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None") {
                _dtCategories.DefaultView.RowFilter = "";
                //lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "CategoryID")
                //in this case we deal with integer not string.             
                _dtCategories.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtCategories.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
       
             //lblRecordsCount.Text= dgvPeople.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e) {
            //we allow number incase Category id is selected.
            if (cbFilterBy.Text=="Category ID")
              e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

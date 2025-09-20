using DVLD.Global_Classes;
using LibraryManagementSystem.BLL;
using LibraryManagementSystem.UI.Controls;
using LibraryManagementSystem.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace LibraryManagementSystem.UI.Books
{
    public partial class frmBooksList : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private static DataTable _dtBooks;

        private clsBook _Book = new clsBook();

        private string imageFileName;

        public frmBooksList() {
            InitializeComponent();
        }

        private void _ResetDefualtValues() {
            lblBookIDValue.Text = "N/A";
            txtTitle.Clear();
            txtISBN.Clear();
            txtEdition.Clear();
            txtPublishedYear.Clear();
            txtLanguage.Clear();
            txtShelfLocation.Clear();
            txtDailyRate.Clear();
            txtDescription.Clear();
            pbBookImage.Image = Resources.Logo_Project_AM;

            _FillCategoriesInComoboBox();
            _FillAuthorsInComoboBox();
            if(cbCategories.Items.Count != 0)
                cbCategories.SelectedIndex = 0;

            if(cbAuthors.Items.Count != 0)
            cbAuthors.SelectedIndex = 0;

            llRemoveImage.Visible = (pbBookImage.ImageLocation != null);

            _Book = new clsBook();
            _Mode = enMode.AddNew;
            lblTitle.Text = "Add New Book";
        }

        private void _FillCategoriesInComoboBox() {
            cbCategories.DataSource = clsCategory.GetAllCategories();
            cbCategories.DisplayMember = "Name";  // What the user sees
            cbCategories.ValueMember = "CategoryID";      // What you get as SelectedValue
        }

        private void _FillAuthorsInComoboBox() {
            cbAuthors.DataSource = clsAuthor.GetAllAuthors();
            cbAuthors.DisplayMember = "FullName";  // What the user sees
            cbAuthors.ValueMember = "AuthorID";      // What you get as SelectedValue
        }

        public bool ValidateInputs() {
            if (!clsValidation.IsValidTextBox(txtTitle.Text)) {
                errorProvider1.SetError(txtTitle, "Title is required.");
                txtTitle.Focus();
                return false;
            }else
                errorProvider1.SetError(txtTitle, "");

            if (!clsValidation.IsValidTextBox(txtISBN.Text)) {
                errorProvider1.SetError(txtISBN, "ISBN is required.");
                txtISBN.Focus();
                return false;
            }else
                errorProvider1.SetError(txtISBN, "");

            if (!clsValidation.IsValidTextBox(txtEdition.Text)) {
                errorProvider1.SetError(txtEdition, "Edition is required.");
                txtEdition.Focus();
                return false;
            }else
                errorProvider1.SetError(txtEdition, "");

            if (!clsValidation.IsValidTextBox(txtPublishedYear.Text)) {
                errorProvider1.SetError(txtPublishedYear, "Published Year is required.");
                txtPublishedYear.Focus();
                return false;
            }else
                errorProvider1.SetError(txtPublishedYear, "");

            if (!clsValidation.IsValidTextBox(txtLanguage.Text)) {
                errorProvider1.SetError(txtLanguage, "Language is required.");
                txtLanguage.Focus();
                return false;
            }else
                errorProvider1.SetError(txtLanguage, "");

            if (!clsValidation.IsValidTextBox(txtShelfLocation.Text)) {
                errorProvider1.SetError(txtShelfLocation, "Shelf Location is required.");
                txtShelfLocation.Focus();
                return false;
            }else
                errorProvider1.SetError(txtShelfLocation, "");

            if (!clsValidation.IsValidTextBox(txtDailyRate.Text)) {
                errorProvider1.SetError(txtDailyRate, "Daily Rate is required.");
                txtDailyRate.Focus();
                return false;
            }else
                errorProvider1.SetError(txtDailyRate, "");

            if (!clsValidation.IsValidTextBox(txtDescription.Text)) {
                errorProvider1.SetError(txtDescription, "Description is required.");
                txtDescription.Focus();
                return false;
            }else
                errorProvider1.SetError(txtDescription, "");

            return true;
        }

        private void frmBooksList_Load(object sender, EventArgs e) {
            _dtBooks = clsBook.GetAllBooks();
            dgvBooks.DataSource = _dtBooks;
            cbFilterBy.SelectedIndex = 0;

            if (!dgvBooks.Columns.Contains("btnAddCopies")) {
                // Create the button column
                DataGridViewButtonColumn btnAddCopies = new DataGridViewButtonColumn();
                btnAddCopies.HeaderText = "Action";
                btnAddCopies.Text = "Add Copies";
                btnAddCopies.Name = "btnAddCopies";
                btnAddCopies.UseColumnTextForButtonValue = true;

                // Add the button column
                dgvBooks.Columns.Insert(dgvBooks.Columns.Count - 1, btnAddCopies);

                // Set it to be the last column
                btnAddCopies.DisplayIndex = dgvBooks.Columns.Count - 1;
            }

            _ResetDefualtValues();
        }

        private bool _HandlePersonImage() {
            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and  place it in the images folder.      
            //_Person.ImageName contains the old Image, we check if it changed then we copy the new image
            if (_Book.ImageName != pbBookImage.ImageLocation) {
                if (_Book.ImageName != "") {
                //first we delete the old image from the folder in case there is any.
                    try{
                        File.Delete(_Book.ImageName);
                    }catch (IOException){
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbBookImage.ImageLocation != null) {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile=pbBookImage.ImageLocation;
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile, ref imageFileName)) {
                        pbBookImage.ImageLocation = SourceImageFile;
                         return true;
                    }else{
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if(!ValidateInputs()) return;

            if (!_HandlePersonImage()) {
                MessageBox.Show("Image Error","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _Book.Title = txtTitle.Text;
            _Book.ISBN = txtISBN.Text;
            _Book.CategoryID = Convert.ToInt32(cbCategories.SelectedValue);
            _Book.AuthorID = Convert.ToInt32(cbAuthors.SelectedValue);
            _Book.Edition = txtEdition.Text;
            _Book.PublishedYear = Convert.ToInt32(txtPublishedYear.Text);
            _Book.Language = txtLanguage.Text;
            _Book.ShelfLocation = txtShelfLocation.Text;
            _Book.DailyRate = Convert.ToSingle(txtDailyRate.Text);
            _Book.Description = txtDescription.Text;

            if (pbBookImage.ImageLocation != null)
                _Book.ImageName = imageFileName;
            else
                _Book.ImageName = "";

            switch(_Mode) {
                case enMode.AddNew:
                    if (_Book.Save()) {
                        MessageBox.Show("Book Added Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        frmBooksList_Load(null, null);
                    }else
                        MessageBox.Show("Book Not Added" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
                case enMode.Update:
                    if (_Book.Save()) {
                        MessageBox.Show("Book Updated Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        frmBooksList_Load(null, null);
                    }else
                        MessageBox.Show("Book Not Updated" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
            }
            _ResetDefualtValues();
        }

        private void _LoadBookData() {
            lblBookIDValue.Text = _Book.ID.ToString();
            txtTitle.Text = _Book.Title;
            txtISBN.Text = _Book.ISBN;
            cbCategories.SelectedValue = _Book.CategoryID;
            cbAuthors.SelectedValue = _Book.AuthorID;
            txtEdition.Text = _Book.Edition;
            txtPublishedYear.Text = _Book.PublishedYear.ToString();
            txtLanguage.Text = _Book.Language;
            txtShelfLocation.Text = _Book.ShelfLocation;
            txtDailyRate.Text = _Book.DailyRate.ToString();
            txtDescription.Text = _Book.Description;

            string DestinationFolder = @"C:\Library-Books-Images\";
            //load person image incase it was set.
            if (_Book.ImageName != "")
                pbBookImage.ImageLocation = DestinationFolder + _Book.ImageName;

            //hide/show the remove linke incase there is no image for the person.
            llRemoveImage.Visible = (_Book.ImageName != ""); 
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            _ResetDefualtValues();
            _Book = clsBook.Find((int)dgvBooks.CurrentRow.Cells[1].Value);
            lblTitle.Text = "Edit Book";
            _LoadBookData();
            _Mode = enMode.Update;
        }

        private void deleteBookToolStripMenuItem_Click(object sender, EventArgs e) {
            _Book = clsBook.Find((int)dgvBooks.CurrentRow.Cells[1].Value); 
            if(MessageBox.Show("Are you sure you want to delete Book [" + dgvBooks.CurrentRow.Cells[1].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                if (_Book.Delete()) {
                    MessageBox.Show("Book has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmBooksList_Load(null, null);
                }else
                    MessageBox.Show("Book is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                case "Book ID":
                    FilterColumn = "BookID";
                    break;
                case "Title":
                    FilterColumn = "Title";
                    break;
                case "ISBN":
                    FilterColumn = "ISBN";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None") {
                _dtBooks.DefaultView.RowFilter = "";
                //lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "BookID")
                //in this case we deal with integer not string.             
                _dtBooks.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtBooks.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
       
             //lblRecordsCount.Text= dgvPeople.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e) {
            //we allow number incase Book id is selected.
            if (cbFilterBy.Text=="Book ID")
              e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbBookImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            pbBookImage.ImageLocation = null;         
            pbBookImage.Image = Resources.Logo_Project_AM;
            llRemoveImage.Visible = false;
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            //if(dgvBooks.Rows.Count == 1) return;
            if (dgvBooks.Columns[e.ColumnIndex].Name == "btnAddCopies" && e.RowIndex >= 0) {
                int bookID = Convert.ToInt32(dgvBooks.Rows[e.RowIndex].Cells["BookID"].Value);
                string title = dgvBooks.Rows[e.RowIndex].Cells["Title"].Value.ToString();

                // Open Add Copies form or handle logic
                frmAddBookCopies form = new frmAddBookCopies(bookID, title);
                form.ShowDialog();
            }
        }

        private void txtPublishedYear_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtDailyRate_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.';
            if (e.KeyChar == '.')  {
                if (txtDailyRate.Text.Contains("."))
                    e.Handled = true; // Already has a dot
                return;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e) {
            frmShowBookdetails frm = new frmShowBookdetails((int)dgvBooks.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}
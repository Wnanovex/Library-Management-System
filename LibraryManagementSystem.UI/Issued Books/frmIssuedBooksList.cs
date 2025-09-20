using DVLD.Global_Classes;
using LibraryManagementSystem.BLL;
using LibraryManagementSystem.UI.Books;
using LibraryManagementSystem.UI.Members;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Issued_Books
{
    public partial class frmIssuedBooksList : Form
    {

        private static DataTable _dtIssuedBooks;

        private clsIssuedBook _IssuedBook = new clsIssuedBook();

        public frmIssuedBooksList() {
            InitializeComponent();
        }

         private void _ResetDefualtValues() {
            lblIssueIDValue.Text = "N/A";
            lblCopyIDValue.Text = "N/A";
            lblMemberIDValue.Text = "N/A";
            lblIssuedByValue.Text = "N/A";
            lblIssueDateValue.Text = "N/A";

            dtpDueDate.Value = DateTime.Now;

            _IssuedBook = new clsIssuedBook();
            btnSave.Enabled = false;
        }

        public bool ValidateInputs() {
            if (lblMemberIDValue.Text == "N/A") {
                errorProvider1.SetError(btnSelectMember, "MemberID is required. Select a Member!");
                btnSelectMember.Focus();
                return false;
            }else
                errorProvider1.SetError(btnSelectMember, "");

            return true;
        }

        private void frmIssuedBooksList_Load(object sender, EventArgs e) {
            _dtIssuedBooks = clsIssuedBook.GetAllIssuedBooks();
            dgvIssuedBooks.DataSource = _dtIssuedBooks;
            cbFilterBy.SelectedIndex = 0;

            _ResetDefualtValues();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if(!ValidateInputs()) return;

            _IssuedBook.MemberID = Convert.ToInt32(lblMemberIDValue.Text);
            _IssuedBook.DueDate = dtpDueDate.Value;

            if (_IssuedBook.Save()) {
                MessageBox.Show("Issue Updated Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                frmIssuedBooksList_Load(null, null);
            }else
                MessageBox.Show("Issue Not Updated" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            _ResetDefualtValues();
        }

        private void btnSelectMember_Click(object sender, EventArgs e) {
            frmFindMember frm = new frmFindMember();
            frm.ShowDialog();
            clsMember selectedMember = frm.SelectedMember;

            if (selectedMember != null) {
                // Now you can use the selected member data
                MessageBox.Show($"Selected: {selectedMember.FullName}");
                lblMemberIDValue.Text = selectedMember.ID.ToString();
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
                case "Issue ID":
                    FilterColumn = "IssueID";
                    break;
                case "Copy ID":
                    FilterColumn = "CopyID";
                    break;
                case "Member ID":
                    FilterColumn = "MemberID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None") {
                _dtIssuedBooks.DefaultView.RowFilter = "";
                return;
            }

            if (FilterColumn == "IssueID" || FilterColumn == "CopyID" || FilterColumn == "MemberID")
                //in this case we deal with integer not string.             
                _dtIssuedBooks.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtIssuedBooks.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e) {
            //we allow number incase Copy id is selected.
            if (cbFilterBy.Text=="Issue ID" || cbFilterBy.Text=="Copy ID" || cbFilterBy.Text=="Member ID")
              e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void LoadIssuedBookData() {
            lblIssueIDValue.Text = _IssuedBook.ID.ToString();
            lblCopyIDValue.Text = _IssuedBook.ID.ToString();
            lblMemberIDValue.Text = _IssuedBook.MemberID.ToString();
            lblIssuedByValue.Text = _IssuedBook.IssuedBy.ToString();
            lblIssueDateValue.Text = clsFormat.DateToShort(_IssuedBook.IssueDate);
            dtpDueDate.Value = _IssuedBook.DueDate;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {
            _ResetDefualtValues();
            _IssuedBook = clsIssuedBook.Find((int)dgvIssuedBooks.CurrentRow.Cells[0].Value);
            btnSave.Enabled = true;
            LoadIssuedBookData();
        }

        private void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e) {
            int issueID = (int)dgvIssuedBooks.CurrentRow.Cells[0].Value; 
            if(MessageBox.Show("Are you sure you want to delete Issued Book [" + issueID + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                if (clsIssuedBook.Delete(issueID)) {
                    MessageBox.Show("Issued Book has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmIssuedBooksList_Load(null, null);
                }else
                    MessageBox.Show("Issued Book is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e) {
            int issueID = (int)dgvIssuedBooks.CurrentRow.Cells[0].Value; 
            if(MessageBox.Show("Are you sure is book returned [" + issueID + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                if (clsIssuedBook.MarkBookAsReturned(issueID)) {
                    _IssuedBook = clsIssuedBook.Find(issueID);
                    _IssuedBook.Copy.UpdateStatus(clsBookCopy.enStatus.Available);
                    MessageBox.Show("book returned successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmIssuedBooksList_Load(null, null);
                }else
                    MessageBox.Show("book Not returned.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsIssuedBooks_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            int issueID = (int)dgvIssuedBooks.CurrentRow.Cells[0].Value;
            bool is_book_returned = clsIssuedBook.IsBookReturned(issueID);
            returnBookToolStripMenuItem.Enabled = !is_book_returned;
            editToolStripMenuItem.Enabled = !is_book_returned;
            //makeFineToolStripMenuItem.Enabled = !is_book_returned;
        }

        private void makeFineToolStripMenuItem_Click(object sender, EventArgs e) {
            int issueID = (int)dgvIssuedBooks.CurrentRow.Cells[0].Value; 
            if(MessageBox.Show("Are you sure you want to make a fine for Issue [" + issueID + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                clsFine fine = new clsFine();
                fine.IssueID = issueID;
                if (fine.Save()) {
                    MessageBox.Show("make a fine successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmIssuedBooksList_Load(null, null);
                }else
                    MessageBox.Show("Not make a fine.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e) {
            clsBookCopy copy = clsBookCopy.Find((int)dgvIssuedBooks.CurrentRow.Cells[1].Value);
            if (copy != null) {
                frmShowBookdetails frm = new frmShowBookdetails(copy.Book.ID);
                frm.ShowDialog();
            }
        }
    }
}

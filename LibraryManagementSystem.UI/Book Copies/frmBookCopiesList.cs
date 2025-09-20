using DVLD.Global_Classes;
using LibraryManagementSystem.BLL;
using LibraryManagementSystem.UI.Books;
using LibraryManagementSystem.UI.Controls;
using LibraryManagementSystem.UI.Members;
using LibraryManagementSystem.UI.Properties;
using System;
using System.Data;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace LibraryManagementSystem.UI.Book_Copies
{
    public partial class frmBookCopiesList : Form
    {
        private static DataTable _dtBookCopies;

        private clsBookCopy _Copy = new clsBookCopy();

        private clsIssuedBook _IssuedBook = new clsIssuedBook();

        public frmBookCopiesList() {
            InitializeComponent();
        }

        private void _ResetDefualtValues() {
            lblIssueIDValue.Text = "N/A";
            lblCopyIDValue.Text = "N/A";
            lblMemberIDValue.Text = "N/A";
            lblIssuedByValue.Text = "N/A";
            lblIssueDateValue.Text = "N/A";

            dtpDueDate.MinDate = DateTime.Now;
            dtpDueDate.Value = DateTime.Now;

            _Copy = new clsBookCopy();
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

        private void frmBookCopiesList_Load(object sender, EventArgs e) {
            _dtBookCopies = clsBookCopy.GetAllBookCopies();
            dgvBookCopies.DataSource = _dtBookCopies;
            cbFilterBy.SelectedIndex = 0;

            _ResetDefualtValues();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if(!ValidateInputs()) return;

            _IssuedBook.CopyID = Convert.ToInt32(lblCopyIDValue.Text);
            _IssuedBook.MemberID = Convert.ToInt32(lblMemberIDValue.Text);
            _IssuedBook.IssuedBy = clsGlobal.CurrentUser.ID;
            _IssuedBook.DueDate = dtpDueDate.Value;
          
            if (_IssuedBook.Save()) {
                _Copy.UpdateStatus(clsBookCopy.enStatus.Issued);
                MessageBox.Show("Issue Added Successfuly" ,"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                frmBookCopiesList_Load(null, null);
            }else
                MessageBox.Show("Issue Not Added" ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                   
            _ResetDefualtValues();
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
                case "Copy ID":
                    FilterColumn = "CopyID";
                    break;
                case "Book ID":
                    FilterColumn = "BookID";
                    break;
                case "Title":
                    FilterColumn = "Title";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None") {
                _dtBookCopies.DefaultView.RowFilter = "";
                return;
            }

            if (FilterColumn == "CopyID" || FilterColumn == "BookID")
                //in this case we deal with integer not string.             
                _dtBookCopies.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtBookCopies.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
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

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e) {
            _ResetDefualtValues();
            _Copy = clsBookCopy.Find((int)dgvBookCopies.CurrentRow.Cells[0].Value);
            btnSave.Enabled = true;
            lblCopyIDValue.Text = _Copy.ID.ToString();
            lblIssuedByValue.Text = clsGlobal.CurrentUser.ID.ToString();
            lblIssueDateValue.Text = DateTime.Now.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e) {
            //we allow number incase Copy id is selected.
            if (cbFilterBy.Text=="Copy ID" || cbFilterBy.Text=="Book ID")
              e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e) {
            int copyID = (int)dgvBookCopies.CurrentRow.Cells[0].Value; 
            if(MessageBox.Show("Are you sure you want to delete Book Copy [" + copyID + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                if (clsBookCopy.Delete(copyID)) {
                    MessageBox.Show("Book Copy has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmBookCopiesList_Load(null, null);
                }else
                    MessageBox.Show("Book Copy is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsBookCopies_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
            int copyID = (int)dgvBookCopies.CurrentRow.Cells[0].Value;
            issueBookToolStripMenuItem.Enabled = clsBookCopy.IsBookAvailable(copyID);
        }

        private void setBookDamagedToolStripMenuItem_Click(object sender, EventArgs e) {
            int copyID = (int)dgvBookCopies.CurrentRow.Cells[0].Value; 
            if(MessageBox.Show("Are you sure you want toset Book Copy Damaged [" + copyID + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                _Copy = clsBookCopy.Find(copyID);
                if (_Copy.UpdateStatus(clsBookCopy.enStatus.Damaged)) {
                    MessageBox.Show("Book Copy has been set in Damaged status successfully", "Successeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmBookCopiesList_Load(null, null);
                }else
                    MessageBox.Show("Book Copy Not set in Damaged status", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setBookLostToolStripMenuItem_Click(object sender, EventArgs e) {
            int copyID = (int)dgvBookCopies.CurrentRow.Cells[0].Value; 
            if(MessageBox.Show("Are you sure you want toset Book Copy Lost [" + copyID + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                _Copy = clsBookCopy.Find(copyID);
                if (_Copy.UpdateStatus(clsBookCopy.enStatus.Lost)) {
                    MessageBox.Show("Book Copy has been set in Lost status successfully", "Successeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmBookCopiesList_Load(null, null);
                }else
                    MessageBox.Show("Book Copy Not set in Lost status", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e) {
            frmShowBookdetails frm = new frmShowBookdetails((int)dgvBookCopies.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}

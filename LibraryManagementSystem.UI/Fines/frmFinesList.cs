using LibraryManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Fines
{
    public partial class frmFinesList : Form
    {
        private static DataTable _dtFines;

        private clsFine _Fine = new clsFine();

        public frmFinesList() {
            InitializeComponent();
        }

        private void frmFinesList_Load(object sender, EventArgs e) {
            _dtFines = clsFine.GetAllFines();
            dgvFines.DataSource = _dtFines;
            cbFilterBy.SelectedIndex = 0;
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
                case "Fine ID":
                    FilterColumn = "FineID";
                    break;
                case "Issue ID":
                    FilterColumn = "IssueID";
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
                _dtFines.DefaultView.RowFilter = "";
                return;
            }

            if (FilterColumn == "FineID" || FilterColumn == "IssueID" || FilterColumn == "MemberID")
                //in this case we deal with integer not string.             
                _dtFines.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtFines.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e) {
            //we allow number incase Copy id is selected.
            if (cbFilterBy.Text=="Fine ID" || cbFilterBy.Text=="Issue ID" || cbFilterBy.Text=="Member ID")
              e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void deleteFineToolStripMenuItem_Click(object sender, EventArgs e) {
            int fineID = (int)dgvFines.CurrentRow.Cells[0].Value; 
            if(MessageBox.Show("Are you sure you want to delete fine [" + fineID + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                if (clsFine.Delete(fineID)) {
                    MessageBox.Show("Fine has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmFinesList_Load(null, null);
                }else
                    MessageBox.Show("Fine is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void payFineToolStripMenuItem_Click(object sender, EventArgs e) {
            int fineID = (int)dgvFines.CurrentRow.Cells[0].Value; 
            if(MessageBox.Show("Are you sure is Member paied fine [" + fineID + "]", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                if (clsFine.PayFine(fineID)) {
                    MessageBox.Show("Fine has been paied successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmFinesList_Load(null, null);
                }else
                    MessageBox.Show("Fine has Not been paied.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using DVLD.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Users
{
    public partial class frmAccountSettings : Form
    {
        public frmAccountSettings() {
            InitializeComponent();
        }

        private void _ResetDefualtValues() {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus(); 
        }

        public bool ValidateInputs() {
            if (!clsValidation.IsValidTextBox(txtCurrentPassword.Text)) {
                errorProvider1.SetError(txtCurrentPassword, "Current Password is required.");
                txtCurrentPassword.Focus();
                return false;
            }else
                errorProvider1.SetError(txtCurrentPassword, "");

            if (!clsValidation.IsValidTextBox(txtNewPassword.Text)) {
                errorProvider1.SetError(txtNewPassword, "New Password is required.");
                txtNewPassword.Focus();
                return false;
            }else
                errorProvider1.SetError(txtNewPassword, "");

            if (!clsValidation.IsValidTextBox(txtConfirmPassword.Text)) {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password is required.");
                txtConfirmPassword.Focus();
                return false;
            }else
                errorProvider1.SetError(txtConfirmPassword, "");

            if (txtCurrentPassword.Text != clsGlobal.CurrentUser.Password) {
                errorProvider1.SetError(txtCurrentPassword, "Current Password is invalid");
                txtCurrentPassword.Focus();
                return false;
            }else
                errorProvider1.SetError(txtCurrentPassword, "");

            if (txtConfirmPassword.Text != txtNewPassword.Text) {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password Not much New Password");
                txtConfirmPassword.Focus();
                return false;
            }else
                errorProvider1.SetError(txtConfirmPassword, "");

            return true;
        }

        private void frmAccountSettings_Load(object sender, EventArgs e) {
            ctrlUserInfoCard1.LoadUserInfo(clsGlobal.CurrentUser.ID);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if(!ValidateInputs()) return;

            //if(txtCurrentPassword.Text != clsGlobal.CurrentUser.Password) {
            //    MessageBox.Show("The Current Password is Not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (clsGlobal.CurrentUser.ChangePassword(txtNewPassword.Text.Trim())) {
                MessageBox.Show("Password Changed Successfully.", "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information );
                _ResetDefualtValues();
            }else            
                MessageBox.Show("An Erro Occured, Password did not change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            _ResetDefualtValues();
        }
    }
}

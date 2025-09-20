using DVLD.Global_Classes;
using LibraryManagementSystem.BLL;
using System;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            
            clsUser user = clsUser.Find(username, password); // Try to find user

            if (user != null) {
                // Check if Remember Me is selected
                if (tsRememberMe.Checked)           
                    clsGlobal.RememberUsernameAndPassword(username, password); // Save credentials in Registry            
                else
                    clsGlobal.RememberUsernameAndPassword("", ""); // Clear saved credentials
                
                // Check if the account is active
                if (!user.isActive) {
                    MessageBox.Show("Your account is not active. Please contact the administrator.", "Inactive Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                // Set current user globally
                clsGlobal.CurrentUser = user;

                // Navigate to main form
                Form frm = new frmMain();
                frm.ShowDialog();
            }else {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            
        }

        private void frmLogin_Load(object sender, EventArgs e) {
            string savedUsername, savedPassword;
            clsGlobal.GetRememberedUsernameAndPassword(out savedUsername, out savedPassword);

            txtUsername.Text = savedUsername;
            txtPassword.Text = savedPassword;

            tsRememberMe.Checked = !string.IsNullOrEmpty(savedUsername); // Check if remember me should be toggled
        }
    }
}

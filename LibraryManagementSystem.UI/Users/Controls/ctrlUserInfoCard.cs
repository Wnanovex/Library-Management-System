using DVLD.Global_Classes;
using LibraryManagementSystem.BLL;
using System;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Users.Controls
{
    public partial class ctrlUserInfoCard : UserControl
    {
        private clsUser _User;
        private int _UserID = -1;

        public int UserID {
            get { return _UserID; }
        }

        public clsUser SelectedUserInfo {
            get { return _User; }
        }

        public ctrlUserInfoCard() {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID) {
            _User = clsUser.Find(UserID);
            if (_User == null){
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }

        private void _FillUserInfo() {
            ctrlPersonalInfoCard1.LoadPersonInfo(_User.PersonID);
            lblUserIDValue.Text = _User.ID.ToString();
            lblUsernameValue.Text = _User.Username;
            lblRoleValue.Text = _User.Role.ToString();
        }

        private void _ResetUserInfo() {           
            ctrlPersonalInfoCard1.ResetPersonInfo();
            lblUserIDValue.Text = "[???]";
            lblUsernameValue.Text = "[???]";
            lblRoleValue.Text = "[???]";
        }
    }
}

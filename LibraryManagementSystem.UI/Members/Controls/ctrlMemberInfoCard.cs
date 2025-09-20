using DVLD.Global_Classes;
using LibraryManagementSystem.BLL;
using System;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Members.Controls
{
    public partial class ctrlMemberInfoCard : UserControl
    {
        private clsMember _Member;
        private int _MemberID = -1;

        public int MemberID {
            get { return _MemberID; }
        }

        public clsMember SelectedMemberInfo {
            get { return _Member; }
        }

        public ctrlMemberInfoCard() {
            InitializeComponent();
        }

        public void LoadMemberInfo(int MemberID) {
            _Member = clsMember.Find(MemberID);
            if (_Member == null){
                _ResetMemberInfo();
                MessageBox.Show("No Member with MemberID = " + MemberID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillMemberInfo();
        }

        private void _FillMemberInfo() {
            ctrlPersonalInfoCard1.LoadPersonInfo(_Member.PersonID);
            lblMemberIDValue.Text = _Member.ID.ToString();
            lblDateJoinedValue.Text = clsFormat.DateToShort(_Member.DateJoined);            
        }

        private void _ResetMemberInfo() {           
            ctrlPersonalInfoCard1.ResetPersonInfo();
            lblMemberIDValue.Text = "[???]";
            lblDateJoinedValue.Text = "[???]";
        }
    }
}

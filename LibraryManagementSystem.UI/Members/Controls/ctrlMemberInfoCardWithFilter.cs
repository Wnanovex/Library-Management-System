using LibraryManagementSystem.BLL;
using System;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Members.Controls
{
    public partial class ctrlMemberInfoCardWithFilter : UserControl
    {
        public event EventHandler<clsMember> OnMemberSelected;

        //public void PublishNews() {
        //    if (OnPersonInfoAdded != null)
        //        OnPersonInfoAdded(this, _Person);
        //} 

        private bool _FilterEnabled = true;
        public bool FilterEnabled {
            get { return _FilterEnabled; }
            set {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public int MemberID   {
            get { return ctrlMemberInfoCard1.MemberID; }   
        }

        public clsMember SelectedMemberInfo {
            get { return ctrlMemberInfoCard1.SelectedMemberInfo; }
        }

        public ctrlMemberInfoCardWithFilter() {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID ) {
            cbFilterBy.SelectedIndex=1;
            txtFilterValue.Text =PersonID.ToString();
            FindNow();
        }

        private void FindNow() {
            switch (cbFilterBy.Text){
                case "Member ID":
                    ctrlMemberInfoCard1.LoadMemberInfo(int.Parse(txtFilterValue.Text));                  
                    break;
                //case "National No.":
                //    ctrlPersonCard1.LoadPersonInfo(txtFilterValue.Text);
                    //break;
                default:
                    break;
            }

            if (OnMemberSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnMemberSelected(this, ctrlMemberInfoCard1.SelectedMemberInfo);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e) {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            FindNow();
        }

        private void ctrlMemberInfoCardWithFilter_Load(object sender, EventArgs e) {
            cbFilterBy.SelectedIndex= 0;
            txtFilterValue.Focus();
        }
    }
}

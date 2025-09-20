using LibraryManagementSystem.BLL;
using System;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Members
{
    public partial class frmFindMember : Form
    {
        public clsMember SelectedMember { get; private set; }

        public frmFindMember() {
            InitializeComponent();
        }

        private void ctrlMemberInfoCardWithFilter1_OnMemberSelected(object sender, BLL.clsMember e) {
            SelectedMember = e;
            MessageBox.Show($"Full Name: {e.FullName}");
        }
    }
}

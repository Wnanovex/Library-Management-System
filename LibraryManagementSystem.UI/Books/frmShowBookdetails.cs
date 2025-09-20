using System;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI.Books
{
    public partial class frmShowBookdetails : Form
    {
        private int _BookID = -1;

        public frmShowBookdetails(int bookID) {
            InitializeComponent();
            _BookID = bookID;
        }

        private void frmShowBookdetails_Load(object sender, EventArgs e) {
            ctrlBookInfoCard1.LoadBookInfo(_BookID);
        }
    }
}

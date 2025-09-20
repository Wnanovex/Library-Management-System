using DVLD.Global_Classes;
using LibraryManagementSystem.BLL;
using LibraryManagementSystem.UI.Authors;
using LibraryManagementSystem.UI.Book_Copies;
using LibraryManagementSystem.UI.Books;
using LibraryManagementSystem.UI.Categories;
using LibraryManagementSystem.UI.Fines;
using LibraryManagementSystem.UI.Issued_Books;
using LibraryManagementSystem.UI.Login;
using LibraryManagementSystem.UI.Members;
using LibraryManagementSystem.UI.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.UI
{
    public partial class frmMain : Form
    {
        string location = "";
        Image activeTabImage = Properties.Resources.Rectangle_110 ; // Replace with your image resource

        public frmMain()  {
            InitializeComponent();
        }

        public void loadform(object Form) {
            if (this.pnlMain.Controls.Count > 0)
                this.pnlMain.Controls.Clear();
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            this.pnlMain.Tag = f;
            f.Show();

            UpdateTabColors();
        }

        private void ResetButtonStyles() {
            btnHome.BackColor = Color.Transparent;
            btnHome.BackgroundImage = null;
            btnBooks.BackColor = Color.Transparent;
            btnBooks.BackgroundImage = null;
            btnBookCopies.BackColor = Color.Transparent;
            btnBookCopies.BackgroundImage = null;
            btnIssuedBooks.BackColor = Color.Transparent;
            btnIssuedBooks.BackgroundImage = null;
            btnFines.BackColor = Color.Transparent;
            btnFines.BackgroundImage = null;
            btnCategories.BackColor = Color.Transparent;
            btnCategories.BackgroundImage = null;
            btnAuthors.BackColor = Color.Transparent;
            btnAuthors.BackgroundImage = null;
            btnMembers.BackColor = Color.Transparent;
            btnMembers.BackgroundImage = null;
            btnUsers.BackColor = Color.Transparent;
            btnUsers.BackgroundImage = null;
        }

        private void UpdateTabColors() {
            // Reset all button colors and images
            ResetButtonStyles();

            // Set the active button color and image
            switch (location) {
                case "home":                
                    btnHome.BackgroundImage = activeTabImage;
                    break;
                case "books":                 
                    btnBooks.BackgroundImage = activeTabImage;
                    break;
                case "bookCopies":
                    btnBookCopies.BackgroundImage = activeTabImage;
                    break;
                case "issuedBooks":
                    btnIssuedBooks.BackgroundImage = activeTabImage;
                    break;
                case "fines":
                    btnFines.BackgroundImage = activeTabImage;
                    break;
                case "categories":
                    btnCategories.BackgroundImage = activeTabImage;
                    break;
                case "authors":
                    btnAuthors.BackgroundImage = activeTabImage;
                    break;
                case "members":
                    btnMembers.BackgroundImage = activeTabImage;
                    break;
                case "users":
                    btnUsers.BackgroundImage = activeTabImage;
                    break;
            }
        }

        private void frmMain_Load(object sender, EventArgs e) {
            //dataGridView1.DataSource = clsPerson.GetAllPeople();
            lblUsername.Text = clsGlobal.CurrentUser.Username;
            loadform(new frmMainContent());
            location = "home";
            UpdateTabColors();
        }

        private void btnHome_Click(object sender, EventArgs e) {
            location = "home";
            loadform(new frmMainContent());
        }

        private void btnBooks_Click(object sender, EventArgs e) {
            location = "books";
            loadform(new frmBooksList());          
        }

        private void btnBookCopies_Click(object sender, EventArgs e) {
            location = "bookCopies";
            loadform(new frmBookCopiesList());
        }

        private void btnFines_Click(object sender, EventArgs e) {
            location = "fines";
            loadform(new frmFinesList());
        }

        private void btnAuthors_Click(object sender, EventArgs e) {
            location = "authors";
            loadform(new frmAuthorsList());
        }

        private void btnMembers_Click(object sender, EventArgs e) {
            location = "members";
            loadform(new frmMembersList());
        }

        private void btnUsers_Click(object sender, EventArgs e) {
            location = "users";
            loadform(new frmUsersList());
        }

        private void btnCategories_Click(object sender, EventArgs e) {
            location = "categories";
            loadform(new frmCategoriesList());
        }

        private void btnIssuedBooks_Click(object sender, EventArgs e) {
            location = "issuedBooks";
            loadform(new frmIssuedBooksList());
        }

        private void btnLogOut_Click(object sender, EventArgs e) {
            clsGlobal.CurrentUser = null;
            this.Close();
        }

        private void btnAccountSettings_Click(object sender, EventArgs e) {
            //location = "accountSettings";
            loadform(new frmAccountSettings());
        }

       
    }
}

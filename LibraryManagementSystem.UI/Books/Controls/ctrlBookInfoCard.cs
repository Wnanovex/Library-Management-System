using LibraryManagementSystem.BLL;
using System;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace LibraryManagementSystem.UI.Books.Controls
{
    public partial class ctrlBookInfoCard : UserControl
    {
        private clsBook _Book;

        private int _BookID = -1;

        public int BookID {
            get { return _BookID; }   
        }

        public clsBook SelectedBookInfo {
            get { return _Book; }
        }

        public ctrlBookInfoCard() {
            InitializeComponent();
        }

        public void LoadBookInfo(int BookID) {
            _Book = clsBook.Find(BookID);
            if (_Book == null) {
                ResetBookInfo();
                MessageBox.Show("No Book with BookID = " + BookID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
            _FillBookInfo();
        }

        private void _FillBookInfo() {
            _BookID = _Book.ID;
            lblBookIDValue.Text=_Book.ID.ToString();
            lblTitleValue.Text = _Book.Title;
            lblISBNValue.Text = _Book.ISBN;
            lblCategoryValue.Text = _Book.Category.Name;
            lblAuthorValue.Text = _Book.Author.FullName;
            lblEditionValue.Text = _Book.Edition;
            lblPublishedYearValue.Text = _Book.PublishedYear.ToString();
            lblLanguageValue.Text= _Book.Language;
            lblShelfLocationValue.Text = _Book.ShelfLocation;
            lblDailyRateValue.Text = _Book.DailyRate.ToString();
            lblDescriptionValue.Text = _Book.Description;
        }

        public void ResetBookInfo() {
            _BookID = -1;
            lblBookIDValue.Text = "[????]";
            lblTitleValue.Text = "[????]";
            lblISBNValue.Text = "[????]";
            lblCategoryValue.Text = "[????]";
            lblAuthorValue.Text = "[????]";
            lblEditionValue.Text = "[????]";
            lblPublishedYearValue.Text = "[????]";
            lblLanguageValue.Text = "[????]"; 
            lblShelfLocationValue.Text = "[????]";
            lblDailyRateValue.Text = "[????]";
            lblDescriptionValue.Text = "[????]";
        }
    }
}

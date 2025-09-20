using LibraryManagementSystem.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LibraryManagementSystem.UI.Books
{
    public partial class frmAddBookCopies : Form
    {
        private int _BookID;
        private string _Title;

        public frmAddBookCopies(int bookID, string title) {
            InitializeComponent();
            _BookID = bookID;
            _Title = title;
            this.Text = _Title;
            lblBookIDValue.Text = _BookID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            int numberOfCopies = (int)nudNumberOfCopies.Value;

            for (int i = 0; i < numberOfCopies; i++) {
                clsBookCopy copy = new clsBookCopy();
                copy.BookID = _BookID;

                if (!copy.Save()) {
                    MessageBox.Show($"Failed to add copy {i + 1}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show($"{numberOfCopies} copies of Book [{_BookID}] added successfully!", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}

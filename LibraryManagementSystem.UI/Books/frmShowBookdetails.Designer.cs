namespace LibraryManagementSystem.UI.Books
{
    partial class frmShowBookdetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlBookInfoCard1 = new LibraryManagementSystem.UI.Books.Controls.ctrlBookInfoCard();
            this.SuspendLayout();
            // 
            // ctrlBookInfoCard1
            // 
            this.ctrlBookInfoCard1.Location = new System.Drawing.Point(30, 30);
            this.ctrlBookInfoCard1.Name = "ctrlBookInfoCard1";
            this.ctrlBookInfoCard1.Size = new System.Drawing.Size(833, 497);
            this.ctrlBookInfoCard1.TabIndex = 0;
            // 
            // frmShowBookdetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(892, 580);
            this.Controls.Add(this.ctrlBookInfoCard1);
            this.Name = "frmShowBookdetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowBookdetails";
            this.Load += new System.EventHandler(this.frmShowBookdetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlBookInfoCard ctrlBookInfoCard1;
    }
}
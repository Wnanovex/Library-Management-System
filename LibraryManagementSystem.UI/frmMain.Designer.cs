namespace LibraryManagementSystem.UI
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnBookCopies = new Guna.UI2.WinForms.Guna2Button();
            this.btnBooks = new Guna.UI2.WinForms.Guna2Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.btnFines = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnIssuedBooks = new Guna.UI2.WinForms.Guna2Button();
            this.btnCategories = new Guna.UI2.WinForms.Guna2Button();
            this.btnUsers = new Guna.UI2.WinForms.Guna2Button();
            this.btnMembers = new Guna.UI2.WinForms.Guna2Button();
            this.btnAuthors = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBookCopies
            // 
            this.btnBookCopies.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBookCopies.BorderColor = System.Drawing.Color.White;
            this.btnBookCopies.BorderRadius = 10;
            this.btnBookCopies.BorderThickness = 2;
            this.btnBookCopies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBookCopies.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBookCopies.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBookCopies.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBookCopies.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBookCopies.FillColor = System.Drawing.Color.Transparent;
            this.btnBookCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookCopies.ForeColor = System.Drawing.Color.White;
            this.btnBookCopies.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBookCopies.Location = new System.Drawing.Point(13, 360);
            this.btnBookCopies.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBookCopies.Name = "btnBookCopies";
            this.btnBookCopies.ShadowDecoration.BorderRadius = 10;
            this.btnBookCopies.Size = new System.Drawing.Size(334, 51);
            this.btnBookCopies.TabIndex = 15;
            this.btnBookCopies.Text = "Book Copies";
            this.btnBookCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBookCopies.Click += new System.EventHandler(this.btnBookCopies_Click);
            // 
            // btnBooks
            // 
            this.btnBooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBooks.BorderColor = System.Drawing.Color.White;
            this.btnBooks.BorderRadius = 10;
            this.btnBooks.BorderThickness = 2;
            this.btnBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBooks.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBooks.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBooks.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBooks.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBooks.FillColor = System.Drawing.Color.Transparent;
            this.btnBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooks.ForeColor = System.Drawing.Color.White;
            this.btnBooks.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBooks.Location = new System.Drawing.Point(13, 299);
            this.btnBooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.ShadowDecoration.BorderRadius = 10;
            this.btnBooks.Size = new System.Drawing.Size(334, 51);
            this.btnBooks.TabIndex = 13;
            this.btnBooks.Text = "Books";
            this.btnBooks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUsername.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUsername.Location = new System.Drawing.Point(150, 846);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(86, 29);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "ADMIN";
            this.lblUsername.Click += new System.EventHandler(this.btnAccountSettings_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(63, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "MANAGEMENT SYSTEM";
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlSideBar.Controls.Add(this.btnFines);
            this.pnlSideBar.Controls.Add(this.btnLogOut);
            this.pnlSideBar.Controls.Add(this.btnIssuedBooks);
            this.pnlSideBar.Controls.Add(this.btnCategories);
            this.pnlSideBar.Controls.Add(this.btnUsers);
            this.pnlSideBar.Controls.Add(this.btnMembers);
            this.pnlSideBar.Controls.Add(this.btnAuthors);
            this.pnlSideBar.Controls.Add(this.pictureBox1);
            this.pnlSideBar.Controls.Add(this.btnBookCopies);
            this.pnlSideBar.Controls.Add(this.btnBooks);
            this.pnlSideBar.Controls.Add(this.btnHome);
            this.pnlSideBar.Controls.Add(this.pictureBox5);
            this.pnlSideBar.Controls.Add(this.lblUsername);
            this.pnlSideBar.Controls.Add(this.label2);
            this.pnlSideBar.Controls.Add(this.label1);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(369, 1002);
            this.pnlSideBar.TabIndex = 4;
            // 
            // btnFines
            // 
            this.btnFines.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFines.BorderColor = System.Drawing.Color.White;
            this.btnFines.BorderRadius = 10;
            this.btnFines.BorderThickness = 2;
            this.btnFines.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFines.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFines.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFines.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFines.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFines.FillColor = System.Drawing.Color.Transparent;
            this.btnFines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFines.ForeColor = System.Drawing.Color.White;
            this.btnFines.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFines.Location = new System.Drawing.Point(13, 485);
            this.btnFines.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFines.Name = "btnFines";
            this.btnFines.ShadowDecoration.BorderRadius = 10;
            this.btnFines.Size = new System.Drawing.Size(334, 51);
            this.btnFines.TabIndex = 24;
            this.btnFines.Text = "Fines";
            this.btnFines.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFines.Click += new System.EventHandler(this.btnFines_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BorderColor = System.Drawing.Color.White;
            this.btnLogOut.BorderThickness = 1;
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogOut.FillColor = System.Drawing.Color.Transparent;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.Red;
            this.btnLogOut.Location = new System.Drawing.Point(13, 912);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.ShadowDecoration.BorderRadius = 10;
            this.btnLogOut.Size = new System.Drawing.Size(334, 51);
            this.btnLogOut.TabIndex = 23;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnIssuedBooks
            // 
            this.btnIssuedBooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIssuedBooks.BorderColor = System.Drawing.Color.White;
            this.btnIssuedBooks.BorderRadius = 10;
            this.btnIssuedBooks.BorderThickness = 2;
            this.btnIssuedBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIssuedBooks.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIssuedBooks.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIssuedBooks.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIssuedBooks.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIssuedBooks.FillColor = System.Drawing.Color.Transparent;
            this.btnIssuedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssuedBooks.ForeColor = System.Drawing.Color.White;
            this.btnIssuedBooks.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnIssuedBooks.Location = new System.Drawing.Point(13, 421);
            this.btnIssuedBooks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIssuedBooks.Name = "btnIssuedBooks";
            this.btnIssuedBooks.ShadowDecoration.BorderRadius = 10;
            this.btnIssuedBooks.Size = new System.Drawing.Size(334, 51);
            this.btnIssuedBooks.TabIndex = 22;
            this.btnIssuedBooks.Text = "Issued Books";
            this.btnIssuedBooks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnIssuedBooks.Click += new System.EventHandler(this.btnIssuedBooks_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCategories.BorderColor = System.Drawing.Color.White;
            this.btnCategories.BorderRadius = 10;
            this.btnCategories.BorderThickness = 2;
            this.btnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategories.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCategories.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCategories.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCategories.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCategories.FillColor = System.Drawing.Color.Transparent;
            this.btnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.ForeColor = System.Drawing.Color.White;
            this.btnCategories.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCategories.Location = new System.Drawing.Point(13, 546);
            this.btnCategories.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.ShadowDecoration.BorderRadius = 10;
            this.btnCategories.Size = new System.Drawing.Size(334, 51);
            this.btnCategories.TabIndex = 21;
            this.btnCategories.Text = "Categories";
            this.btnCategories.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsers.BorderColor = System.Drawing.Color.White;
            this.btnUsers.BorderRadius = 10;
            this.btnUsers.BorderThickness = 2;
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUsers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUsers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUsers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUsers.FillColor = System.Drawing.Color.Transparent;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUsers.Location = new System.Drawing.Point(13, 729);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.ShadowDecoration.BorderRadius = 10;
            this.btnUsers.Size = new System.Drawing.Size(334, 51);
            this.btnUsers.TabIndex = 20;
            this.btnUsers.Text = "Users";
            this.btnUsers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnMembers
            // 
            this.btnMembers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMembers.BorderColor = System.Drawing.Color.White;
            this.btnMembers.BorderRadius = 10;
            this.btnMembers.BorderThickness = 2;
            this.btnMembers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMembers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMembers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMembers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMembers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMembers.FillColor = System.Drawing.Color.Transparent;
            this.btnMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembers.ForeColor = System.Drawing.Color.White;
            this.btnMembers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMembers.Location = new System.Drawing.Point(13, 668);
            this.btnMembers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.ShadowDecoration.BorderRadius = 10;
            this.btnMembers.Size = new System.Drawing.Size(334, 51);
            this.btnMembers.TabIndex = 19;
            this.btnMembers.Text = "Members";
            this.btnMembers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);
            // 
            // btnAuthors
            // 
            this.btnAuthors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAuthors.BorderColor = System.Drawing.Color.White;
            this.btnAuthors.BorderRadius = 10;
            this.btnAuthors.BorderThickness = 2;
            this.btnAuthors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuthors.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAuthors.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAuthors.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAuthors.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAuthors.FillColor = System.Drawing.Color.Transparent;
            this.btnAuthors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthors.ForeColor = System.Drawing.Color.White;
            this.btnAuthors.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAuthors.Location = new System.Drawing.Point(13, 607);
            this.btnAuthors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAuthors.Name = "btnAuthors";
            this.btnAuthors.ShadowDecoration.BorderRadius = 10;
            this.btnAuthors.Size = new System.Drawing.Size(334, 51);
            this.btnAuthors.TabIndex = 18;
            this.btnAuthors.Text = "Authors";
            this.btnAuthors.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAuthors.Click += new System.EventHandler(this.btnAuthors_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::LibraryManagementSystem.UI.Properties.Resources.library_management_system_img;
            this.pictureBox1.Location = new System.Drawing.Point(105, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = global::LibraryManagementSystem.UI.Properties.Resources.Rectangle_110;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.BorderColor = System.Drawing.Color.White;
            this.btnHome.BorderRadius = 10;
            this.btnHome.BorderThickness = 2;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHome.FillColor = System.Drawing.Color.Transparent;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHome.Location = new System.Drawing.Point(13, 238);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.ShadowDecoration.BorderRadius = 10;
            this.btnHome.Size = new System.Drawing.Size(334, 51);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = global::LibraryManagementSystem.UI.Properties.Resources.icon_account_circle;
            this.pictureBox5.Location = new System.Drawing.Point(68, 824);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(62, 65);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.btnAccountSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(59, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "LIBRARY";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.ForeColor = System.Drawing.Color.Black;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1481, 1002);
            this.pnlMain.TabIndex = 6;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1481, 1002);
            this.Controls.Add(this.pnlSideBar);
            this.Controls.Add(this.pnlMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlSideBar.ResumeLayout(false);
            this.pnlSideBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnBookCopies;
        private Guna.UI2.WinForms.Guna2Button btnBooks;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMain;
        private Guna.UI2.WinForms.Guna2Button btnUsers;
        private Guna.UI2.WinForms.Guna2Button btnMembers;
        private Guna.UI2.WinForms.Guna2Button btnAuthors;
        private Guna.UI2.WinForms.Guna2Button btnCategories;
        private Guna.UI2.WinForms.Guna2Button btnIssuedBooks;
        private Guna.UI2.WinForms.Guna2Button btnLogOut;
        private Guna.UI2.WinForms.Guna2Button btnFines;
    }
}


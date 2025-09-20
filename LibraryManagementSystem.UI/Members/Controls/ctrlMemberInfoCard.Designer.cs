namespace LibraryManagementSystem.UI.Members.Controls
{
    partial class ctrlMemberInfoCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblMemberIDValue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel11 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDateJoinedValue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ctrlPersonalInfoCard1 = new LibraryManagementSystem.UI.Controls.ctrlPersonalInfoCard();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.lblMemberIDValue);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel11);
            this.guna2GroupBox1.Controls.Add(this.lblDateJoinedValue);
            this.guna2GroupBox1.Controls.Add(this.guna2HtmlLabel4);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(3, 378);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(830, 127);
            this.guna2GroupBox1.TabIndex = 3;
            this.guna2GroupBox1.Text = "Member Information";
            // 
            // lblMemberIDValue
            // 
            this.lblMemberIDValue.BackColor = System.Drawing.Color.Transparent;
            this.lblMemberIDValue.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberIDValue.Location = new System.Drawing.Point(161, 66);
            this.lblMemberIDValue.Name = "lblMemberIDValue";
            this.lblMemberIDValue.Size = new System.Drawing.Size(61, 28);
            this.lblMemberIDValue.TabIndex = 69;
            this.lblMemberIDValue.Text = "[????]";
            // 
            // guna2HtmlLabel11
            // 
            this.guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel11.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel11.Location = new System.Drawing.Point(15, 66);
            this.guna2HtmlLabel11.Name = "guna2HtmlLabel11";
            this.guna2HtmlLabel11.Size = new System.Drawing.Size(113, 28);
            this.guna2HtmlLabel11.TabIndex = 68;
            this.guna2HtmlLabel11.Text = "MemberID:";
            // 
            // lblDateJoinedValue
            // 
            this.lblDateJoinedValue.BackColor = System.Drawing.Color.Transparent;
            this.lblDateJoinedValue.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateJoinedValue.Location = new System.Drawing.Point(611, 66);
            this.lblDateJoinedValue.Name = "lblDateJoinedValue";
            this.lblDateJoinedValue.Size = new System.Drawing.Size(61, 28);
            this.lblDateJoinedValue.TabIndex = 67;
            this.lblDateJoinedValue.Text = "[????]";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(451, 66);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(124, 28);
            this.guna2HtmlLabel4.TabIndex = 66;
            this.guna2HtmlLabel4.Text = "Date Joined:";
            // 
            // ctrlPersonalInfoCard1
            // 
            this.ctrlPersonalInfoCard1.Location = new System.Drawing.Point(3, 3);
            this.ctrlPersonalInfoCard1.Name = "ctrlPersonalInfoCard1";
            this.ctrlPersonalInfoCard1.Size = new System.Drawing.Size(832, 350);
            this.ctrlPersonalInfoCard1.TabIndex = 2;
            // 
            // ctrlMemberInfoCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.ctrlPersonalInfoCard1);
            this.Name = "ctrlMemberInfoCard";
            this.Size = new System.Drawing.Size(836, 512);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMemberIDValue;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel11;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDateJoinedValue;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private UI.Controls.ctrlPersonalInfoCard ctrlPersonalInfoCard1;
    }
}

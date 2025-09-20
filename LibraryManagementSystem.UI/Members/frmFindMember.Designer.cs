namespace LibraryManagementSystem.UI.Members
{
    partial class frmFindMember
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
            this.ctrlMemberInfoCardWithFilter1 = new LibraryManagementSystem.UI.Members.Controls.ctrlMemberInfoCardWithFilter();
            this.SuspendLayout();
            // 
            // ctrlMemberInfoCardWithFilter1
            // 
            this.ctrlMemberInfoCardWithFilter1.FilterEnabled = true;
            this.ctrlMemberInfoCardWithFilter1.Location = new System.Drawing.Point(69, 12);
            this.ctrlMemberInfoCardWithFilter1.Name = "ctrlMemberInfoCardWithFilter1";
            this.ctrlMemberInfoCardWithFilter1.Size = new System.Drawing.Size(838, 663);
            this.ctrlMemberInfoCardWithFilter1.TabIndex = 0;
            this.ctrlMemberInfoCardWithFilter1.OnMemberSelected += new System.EventHandler<LibraryManagementSystem.BLL.clsMember>(this.ctrlMemberInfoCardWithFilter1_OnMemberSelected);
            // 
            // frmFindMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(973, 709);
            this.Controls.Add(this.ctrlMemberInfoCardWithFilter1);
            this.Name = "frmFindMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFindMember";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlMemberInfoCardWithFilter ctrlMemberInfoCardWithFilter1;
    }
}
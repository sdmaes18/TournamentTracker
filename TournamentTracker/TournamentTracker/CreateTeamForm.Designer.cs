namespace TrackerUI
{
    partial class CreateTeamForm
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
            this.TeamNameValue = new System.Windows.Forms.TextBox();
            this.TeamNamelbl = new System.Windows.Forms.Label();
            this.Headerlbl = new System.Windows.Forms.Label();
            this.AddTeamMemberButton = new System.Windows.Forms.Button();
            this.SelectTeamMemberDropDown = new System.Windows.Forms.ComboBox();
            this.SelectTeamMemberlbl = new System.Windows.Forms.Label();
            this.AddNewMemberGroupBox = new System.Windows.Forms.GroupBox();
            this.CreateMemberButton = new System.Windows.Forms.Button();
            this.CellPhoneValue = new System.Windows.Forms.TextBox();
            this.CellPhonelbl = new System.Windows.Forms.Label();
            this.EmailValue = new System.Windows.Forms.TextBox();
            this.Emaillbl = new System.Windows.Forms.Label();
            this.LastNameValue = new System.Windows.Forms.TextBox();
            this.LastNamelbl = new System.Windows.Forms.Label();
            this.FirstNameValue = new System.Windows.Forms.TextBox();
            this.FirstNameLbl = new System.Windows.Forms.Label();
            this.TeamMembersListBox = new System.Windows.Forms.ListBox();
            this.DeleteSelectedMemberButton = new System.Windows.Forms.Button();
            this.CreateTeamButton = new System.Windows.Forms.Button();
            this.AddNewMemberGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TeamNameValue
            // 
            this.TeamNameValue.Location = new System.Drawing.Point(40, 132);
            this.TeamNameValue.Name = "TeamNameValue";
            this.TeamNameValue.Size = new System.Drawing.Size(395, 26);
            this.TeamNameValue.TabIndex = 13;
            // 
            // TeamNamelbl
            // 
            this.TeamNamelbl.AutoSize = true;
            this.TeamNamelbl.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.TeamNamelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.TeamNamelbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TeamNamelbl.Location = new System.Drawing.Point(33, 82);
            this.TeamNamelbl.Name = "TeamNamelbl";
            this.TeamNamelbl.Size = new System.Drawing.Size(164, 38);
            this.TeamNamelbl.TabIndex = 12;
            this.TeamNamelbl.Text = "Team Name";
            // 
            // Headerlbl
            // 
            this.Headerlbl.AutoSize = true;
            this.Headerlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Headerlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Headerlbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Headerlbl.Location = new System.Drawing.Point(33, 26);
            this.Headerlbl.Name = "Headerlbl";
            this.Headerlbl.Size = new System.Drawing.Size(203, 37);
            this.Headerlbl.TabIndex = 11;
            this.Headerlbl.Text = "Create Team";
            // 
            // AddTeamMemberButton
            // 
            this.AddTeamMemberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddTeamMemberButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AddTeamMemberButton.Location = new System.Drawing.Point(40, 266);
            this.AddTeamMemberButton.Name = "AddTeamMemberButton";
            this.AddTeamMemberButton.Size = new System.Drawing.Size(294, 44);
            this.AddTeamMemberButton.TabIndex = 19;
            this.AddTeamMemberButton.Text = "Add Member";
            this.AddTeamMemberButton.UseVisualStyleBackColor = true;
            this.AddTeamMemberButton.Click += new System.EventHandler(this.AddTeamMemberButton_Click);
            // 
            // SelectTeamMemberDropDown
            // 
            this.SelectTeamMemberDropDown.FormattingEnabled = true;
            this.SelectTeamMemberDropDown.Location = new System.Drawing.Point(40, 213);
            this.SelectTeamMemberDropDown.Name = "SelectTeamMemberDropDown";
            this.SelectTeamMemberDropDown.Size = new System.Drawing.Size(395, 28);
            this.SelectTeamMemberDropDown.TabIndex = 18;
            // 
            // SelectTeamMemberlbl
            // 
            this.SelectTeamMemberlbl.AutoSize = true;
            this.SelectTeamMemberlbl.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.SelectTeamMemberlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.SelectTeamMemberlbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SelectTeamMemberlbl.Location = new System.Drawing.Point(33, 172);
            this.SelectTeamMemberlbl.Name = "SelectTeamMemberlbl";
            this.SelectTeamMemberlbl.Size = new System.Drawing.Size(277, 38);
            this.SelectTeamMemberlbl.TabIndex = 17;
            this.SelectTeamMemberlbl.Text = "Select Team Member";
            // 
            // AddNewMemberGroupBox
            // 
            this.AddNewMemberGroupBox.Controls.Add(this.CreateMemberButton);
            this.AddNewMemberGroupBox.Controls.Add(this.CellPhoneValue);
            this.AddNewMemberGroupBox.Controls.Add(this.CellPhonelbl);
            this.AddNewMemberGroupBox.Controls.Add(this.EmailValue);
            this.AddNewMemberGroupBox.Controls.Add(this.Emaillbl);
            this.AddNewMemberGroupBox.Controls.Add(this.LastNameValue);
            this.AddNewMemberGroupBox.Controls.Add(this.LastNamelbl);
            this.AddNewMemberGroupBox.Controls.Add(this.FirstNameValue);
            this.AddNewMemberGroupBox.Controls.Add(this.FirstNameLbl);
            this.AddNewMemberGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewMemberGroupBox.Location = new System.Drawing.Point(40, 354);
            this.AddNewMemberGroupBox.Name = "AddNewMemberGroupBox";
            this.AddNewMemberGroupBox.Size = new System.Drawing.Size(395, 317);
            this.AddNewMemberGroupBox.TabIndex = 20;
            this.AddNewMemberGroupBox.TabStop = false;
            this.AddNewMemberGroupBox.Text = "Add New Member";
            // 
            // CreateMemberButton
            // 
            this.CreateMemberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CreateMemberButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CreateMemberButton.Location = new System.Drawing.Point(169, 250);
            this.CreateMemberButton.Name = "CreateMemberButton";
            this.CreateMemberButton.Size = new System.Drawing.Size(174, 44);
            this.CreateMemberButton.TabIndex = 21;
            this.CreateMemberButton.Text = "Create Member";
            this.CreateMemberButton.UseVisualStyleBackColor = true;
            this.CreateMemberButton.Click += new System.EventHandler(this.CreateMemberButton_Click);
            // 
            // CellPhoneValue
            // 
            this.CellPhoneValue.Location = new System.Drawing.Point(169, 180);
            this.CellPhoneValue.Name = "CellPhoneValue";
            this.CellPhoneValue.Size = new System.Drawing.Size(174, 35);
            this.CellPhoneValue.TabIndex = 28;
            // 
            // CellPhonelbl
            // 
            this.CellPhonelbl.AutoSize = true;
            this.CellPhonelbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.CellPhonelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.CellPhonelbl.Location = new System.Drawing.Point(6, 180);
            this.CellPhonelbl.Name = "CellPhonelbl";
            this.CellPhonelbl.Size = new System.Drawing.Size(130, 32);
            this.CellPhonelbl.TabIndex = 27;
            this.CellPhonelbl.Text = "Cell Phone";
            // 
            // EmailValue
            // 
            this.EmailValue.Location = new System.Drawing.Point(169, 129);
            this.EmailValue.Name = "EmailValue";
            this.EmailValue.Size = new System.Drawing.Size(174, 35);
            this.EmailValue.TabIndex = 26;
            // 
            // Emaillbl
            // 
            this.Emaillbl.AutoSize = true;
            this.Emaillbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Emaillbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Emaillbl.Location = new System.Drawing.Point(6, 129);
            this.Emaillbl.Name = "Emaillbl";
            this.Emaillbl.Size = new System.Drawing.Size(72, 32);
            this.Emaillbl.TabIndex = 25;
            this.Emaillbl.Text = "Email";
            // 
            // LastNameValue
            // 
            this.LastNameValue.Location = new System.Drawing.Point(169, 84);
            this.LastNameValue.Name = "LastNameValue";
            this.LastNameValue.Size = new System.Drawing.Size(174, 35);
            this.LastNameValue.TabIndex = 24;
            // 
            // LastNamelbl
            // 
            this.LastNamelbl.AutoSize = true;
            this.LastNamelbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.LastNamelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.LastNamelbl.Location = new System.Drawing.Point(6, 84);
            this.LastNamelbl.Name = "LastNamelbl";
            this.LastNamelbl.Size = new System.Drawing.Size(127, 32);
            this.LastNamelbl.TabIndex = 23;
            this.LastNamelbl.Text = "Last Name";
            // 
            // FirstNameValue
            // 
            this.FirstNameValue.Location = new System.Drawing.Point(169, 36);
            this.FirstNameValue.Name = "FirstNameValue";
            this.FirstNameValue.Size = new System.Drawing.Size(174, 35);
            this.FirstNameValue.TabIndex = 22;
            // 
            // FirstNameLbl
            // 
            this.FirstNameLbl.AutoSize = true;
            this.FirstNameLbl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FirstNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.FirstNameLbl.Location = new System.Drawing.Point(6, 36);
            this.FirstNameLbl.Name = "FirstNameLbl";
            this.FirstNameLbl.Size = new System.Drawing.Size(130, 32);
            this.FirstNameLbl.TabIndex = 21;
            this.FirstNameLbl.Text = "First Name";
            // 
            // TeamMembersListBox
            // 
            this.TeamMembersListBox.FormattingEnabled = true;
            this.TeamMembersListBox.ItemHeight = 20;
            this.TeamMembersListBox.Location = new System.Drawing.Point(507, 131);
            this.TeamMembersListBox.Name = "TeamMembersListBox";
            this.TeamMembersListBox.Size = new System.Drawing.Size(315, 544);
            this.TeamMembersListBox.TabIndex = 21;
            // 
            // DeleteSelectedMemberButton
            // 
            this.DeleteSelectedMemberButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.DeleteSelectedMemberButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DeleteSelectedMemberButton.Location = new System.Drawing.Point(839, 266);
            this.DeleteSelectedMemberButton.Name = "DeleteSelectedMemberButton";
            this.DeleteSelectedMemberButton.Size = new System.Drawing.Size(174, 92);
            this.DeleteSelectedMemberButton.TabIndex = 22;
            this.DeleteSelectedMemberButton.Text = "Remove Selected Member";
            this.DeleteSelectedMemberButton.UseVisualStyleBackColor = true;
            this.DeleteSelectedMemberButton.Click += new System.EventHandler(this.DeleteSelectedMemberButton_Click);
            // 
            // CreateTeamButton
            // 
            this.CreateTeamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CreateTeamButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CreateTeamButton.Location = new System.Drawing.Point(875, 574);
            this.CreateTeamButton.Name = "CreateTeamButton";
            this.CreateTeamButton.Size = new System.Drawing.Size(138, 74);
            this.CreateTeamButton.TabIndex = 23;
            this.CreateTeamButton.Text = "Create Team";
            this.CreateTeamButton.UseVisualStyleBackColor = true;
            this.CreateTeamButton.Click += new System.EventHandler(this.CreateTeamButton_Click);
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1043, 797);
            this.Controls.Add(this.CreateTeamButton);
            this.Controls.Add(this.DeleteSelectedMemberButton);
            this.Controls.Add(this.TeamMembersListBox);
            this.Controls.Add(this.AddNewMemberGroupBox);
            this.Controls.Add(this.AddTeamMemberButton);
            this.Controls.Add(this.SelectTeamMemberDropDown);
            this.Controls.Add(this.SelectTeamMemberlbl);
            this.Controls.Add(this.TeamNameValue);
            this.Controls.Add(this.TeamNamelbl);
            this.Controls.Add(this.Headerlbl);
            this.Name = "CreateTeamForm";
            this.Text = "Create Team";
            this.AddNewMemberGroupBox.ResumeLayout(false);
            this.AddNewMemberGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TeamNameValue;
        private System.Windows.Forms.Label TeamNamelbl;
        private System.Windows.Forms.Label Headerlbl;
        private System.Windows.Forms.Button AddTeamMemberButton;
        private System.Windows.Forms.ComboBox SelectTeamMemberDropDown;
        private System.Windows.Forms.Label SelectTeamMemberlbl;
        private System.Windows.Forms.GroupBox AddNewMemberGroupBox;
        private System.Windows.Forms.TextBox FirstNameValue;
        private System.Windows.Forms.Label FirstNameLbl;
        private System.Windows.Forms.TextBox EmailValue;
        private System.Windows.Forms.Label Emaillbl;
        private System.Windows.Forms.TextBox LastNameValue;
        private System.Windows.Forms.Label LastNamelbl;
        private System.Windows.Forms.TextBox CellPhoneValue;
        private System.Windows.Forms.Label CellPhonelbl;
        private System.Windows.Forms.Button CreateMemberButton;
        private System.Windows.Forms.ListBox TeamMembersListBox;
        private System.Windows.Forms.Button DeleteSelectedMemberButton;
        private System.Windows.Forms.Button CreateTeamButton;
    }
}
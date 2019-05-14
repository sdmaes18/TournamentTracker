namespace TrackerUI
{
    partial class CreateTournamentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTournamentForm));
            this.Headerlbl = new System.Windows.Forms.Label();
            this.TournamentNameValue = new System.Windows.Forms.TextBox();
            this.TournamentNamelbl = new System.Windows.Forms.Label();
            this.EntryFreeValue = new System.Windows.Forms.TextBox();
            this.EntryFeelbl = new System.Windows.Forms.Label();
            this.SelectTeamDropDown = new System.Windows.Forms.ComboBox();
            this.SelectTeamlbl = new System.Windows.Forms.Label();
            this.CreateNewTeamLink = new System.Windows.Forms.LinkLabel();
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.CreatePrizeButton = new System.Windows.Forms.Button();
            this.TournamentTeamsListBox = new System.Windows.Forms.ListBox();
            this.TournamentPlayersLbl = new System.Windows.Forms.Label();
            this.RemoveSelectedTeamButton = new System.Windows.Forms.Button();
            this.RemoveSelectedPrizebtn = new System.Windows.Forms.Button();
            this.DeleteTeamsPlayerLbl = new System.Windows.Forms.Label();
            this.PrizesListBox = new System.Windows.Forms.ListBox();
            this.CreateTournamentBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Headerlbl
            // 
            resources.ApplyResources(this.Headerlbl, "Headerlbl");
            this.Headerlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Headerlbl.Name = "Headerlbl";
            // 
            // TournamentNameValue
            // 
            resources.ApplyResources(this.TournamentNameValue, "TournamentNameValue");
            this.TournamentNameValue.Name = "TournamentNameValue";
            // 
            // TournamentNamelbl
            // 
            resources.ApplyResources(this.TournamentNamelbl, "TournamentNamelbl");
            this.TournamentNamelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.TournamentNamelbl.Name = "TournamentNamelbl";
            // 
            // EntryFreeValue
            // 
            resources.ApplyResources(this.EntryFreeValue, "EntryFreeValue");
            this.EntryFreeValue.Name = "EntryFreeValue";
            // 
            // EntryFeelbl
            // 
            resources.ApplyResources(this.EntryFeelbl, "EntryFeelbl");
            this.EntryFeelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.EntryFeelbl.Name = "EntryFeelbl";
            // 
            // SelectTeamDropDown
            // 
            this.SelectTeamDropDown.FormattingEnabled = true;
            resources.ApplyResources(this.SelectTeamDropDown, "SelectTeamDropDown");
            this.SelectTeamDropDown.Name = "SelectTeamDropDown";
            // 
            // SelectTeamlbl
            // 
            resources.ApplyResources(this.SelectTeamlbl, "SelectTeamlbl");
            this.SelectTeamlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.SelectTeamlbl.Name = "SelectTeamlbl";
            // 
            // CreateNewTeamLink
            // 
            resources.ApplyResources(this.CreateNewTeamLink, "CreateNewTeamLink");
            this.CreateNewTeamLink.Name = "CreateNewTeamLink";
            this.CreateNewTeamLink.TabStop = true;
            this.CreateNewTeamLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateNewTeamLink_LinkClicked);
            // 
            // AddTeamButton
            // 
            resources.ApplyResources(this.AddTeamButton, "AddTeamButton");
            this.AddTeamButton.Name = "AddTeamButton";
            this.AddTeamButton.UseVisualStyleBackColor = true;
            this.AddTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
            // 
            // CreatePrizeButton
            // 
            resources.ApplyResources(this.CreatePrizeButton, "CreatePrizeButton");
            this.CreatePrizeButton.Name = "CreatePrizeButton";
            this.CreatePrizeButton.UseVisualStyleBackColor = true;
            this.CreatePrizeButton.Click += new System.EventHandler(this.CreatePrizeButton_Click);
            // 
            // TournamentTeamsListBox
            // 
            this.TournamentTeamsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TournamentTeamsListBox.FormattingEnabled = true;
            resources.ApplyResources(this.TournamentTeamsListBox, "TournamentTeamsListBox");
            this.TournamentTeamsListBox.Name = "TournamentTeamsListBox";
            // 
            // TournamentPlayersLbl
            // 
            resources.ApplyResources(this.TournamentPlayersLbl, "TournamentPlayersLbl");
            this.TournamentPlayersLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.TournamentPlayersLbl.Name = "TournamentPlayersLbl";
            // 
            // RemoveSelectedTeamButton
            // 
            resources.ApplyResources(this.RemoveSelectedTeamButton, "RemoveSelectedTeamButton");
            this.RemoveSelectedTeamButton.Name = "RemoveSelectedTeamButton";
            this.RemoveSelectedTeamButton.UseVisualStyleBackColor = true;
            this.RemoveSelectedTeamButton.Click += new System.EventHandler(this.RemoveSelectedTeamButton_Click);
            // 
            // RemoveSelectedPrizebtn
            // 
            resources.ApplyResources(this.RemoveSelectedPrizebtn, "RemoveSelectedPrizebtn");
            this.RemoveSelectedPrizebtn.Name = "RemoveSelectedPrizebtn";
            this.RemoveSelectedPrizebtn.UseVisualStyleBackColor = true;
            this.RemoveSelectedPrizebtn.Click += new System.EventHandler(this.RemoveSelectedPrizebtn_Click);
            // 
            // DeleteTeamsPlayerLbl
            // 
            resources.ApplyResources(this.DeleteTeamsPlayerLbl, "DeleteTeamsPlayerLbl");
            this.DeleteTeamsPlayerLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.DeleteTeamsPlayerLbl.Name = "DeleteTeamsPlayerLbl";
            // 
            // PrizesListBox
            // 
            this.PrizesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PrizesListBox.FormattingEnabled = true;
            resources.ApplyResources(this.PrizesListBox, "PrizesListBox");
            this.PrizesListBox.Name = "PrizesListBox";
            // 
            // CreateTournamentBtn
            // 
            resources.ApplyResources(this.CreateTournamentBtn, "CreateTournamentBtn");
            this.CreateTournamentBtn.Name = "CreateTournamentBtn";
            this.CreateTournamentBtn.UseVisualStyleBackColor = true;
            this.CreateTournamentBtn.Click += new System.EventHandler(this.CreateTournamentBtn_Click);
            // 
            // CreateTournamentForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.CreateTournamentBtn);
            this.Controls.Add(this.RemoveSelectedPrizebtn);
            this.Controls.Add(this.DeleteTeamsPlayerLbl);
            this.Controls.Add(this.PrizesListBox);
            this.Controls.Add(this.RemoveSelectedTeamButton);
            this.Controls.Add(this.TournamentPlayersLbl);
            this.Controls.Add(this.TournamentTeamsListBox);
            this.Controls.Add(this.CreatePrizeButton);
            this.Controls.Add(this.AddTeamButton);
            this.Controls.Add(this.CreateNewTeamLink);
            this.Controls.Add(this.SelectTeamDropDown);
            this.Controls.Add(this.SelectTeamlbl);
            this.Controls.Add(this.EntryFreeValue);
            this.Controls.Add(this.EntryFeelbl);
            this.Controls.Add(this.TournamentNameValue);
            this.Controls.Add(this.TournamentNamelbl);
            this.Controls.Add(this.Headerlbl);
            this.Name = "CreateTournamentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Headerlbl;
        private System.Windows.Forms.TextBox TournamentNameValue;
        private System.Windows.Forms.Label TournamentNamelbl;
        private System.Windows.Forms.TextBox EntryFreeValue;
        private System.Windows.Forms.Label EntryFeelbl;
        private System.Windows.Forms.ComboBox SelectTeamDropDown;
        private System.Windows.Forms.Label SelectTeamlbl;
        private System.Windows.Forms.LinkLabel CreateNewTeamLink;
        private System.Windows.Forms.Button AddTeamButton;
        private System.Windows.Forms.Button CreatePrizeButton;
        private System.Windows.Forms.ListBox TournamentTeamsListBox;
        private System.Windows.Forms.Label TournamentPlayersLbl;
        private System.Windows.Forms.Button RemoveSelectedTeamButton;
        private System.Windows.Forms.Button RemoveSelectedPrizebtn;
        private System.Windows.Forms.Label DeleteTeamsPlayerLbl;
        private System.Windows.Forms.ListBox PrizesListBox;
        private System.Windows.Forms.Button CreateTournamentBtn;
    }
}
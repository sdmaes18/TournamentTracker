namespace TrackerUI
{
    partial class TournamentDashboardForm
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
            this.Headerlbl = new System.Windows.Forms.Label();
            this.LoadExisitingTournamentDropDown = new System.Windows.Forms.ComboBox();
            this.LoadExistingTournamentlbl = new System.Windows.Forms.Label();
            this.LoadTournamentButton = new System.Windows.Forms.Button();
            this.CreateTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Headerlbl
            // 
            this.Headerlbl.AutoSize = true;
            this.Headerlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Headerlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Headerlbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Headerlbl.Location = new System.Drawing.Point(128, 29);
            this.Headerlbl.Name = "Headerlbl";
            this.Headerlbl.Size = new System.Drawing.Size(361, 37);
            this.Headerlbl.TabIndex = 12;
            this.Headerlbl.Text = "Tournament DashBoard";
            this.Headerlbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoadExisitingTournamentDropDown
            // 
            this.LoadExisitingTournamentDropDown.FormattingEnabled = true;
            this.LoadExisitingTournamentDropDown.Location = new System.Drawing.Point(135, 158);
            this.LoadExisitingTournamentDropDown.Name = "LoadExisitingTournamentDropDown";
            this.LoadExisitingTournamentDropDown.Size = new System.Drawing.Size(354, 28);
            this.LoadExisitingTournamentDropDown.TabIndex = 20;
            // 
            // LoadExistingTournamentlbl
            // 
            this.LoadExistingTournamentlbl.AutoSize = true;
            this.LoadExistingTournamentlbl.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.LoadExistingTournamentlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.LoadExistingTournamentlbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LoadExistingTournamentlbl.Location = new System.Drawing.Point(155, 117);
            this.LoadExistingTournamentlbl.Name = "LoadExistingTournamentlbl";
            this.LoadExistingTournamentlbl.Size = new System.Drawing.Size(334, 38);
            this.LoadExistingTournamentlbl.TabIndex = 19;
            this.LoadExistingTournamentlbl.Text = "Load Existing Tournament";
            // 
            // LoadTournamentButton
            // 
            this.LoadTournamentButton.Location = new System.Drawing.Point(240, 205);
            this.LoadTournamentButton.Name = "LoadTournamentButton";
            this.LoadTournamentButton.Size = new System.Drawing.Size(178, 43);
            this.LoadTournamentButton.TabIndex = 21;
            this.LoadTournamentButton.Text = "Load Tournament";
            this.LoadTournamentButton.UseVisualStyleBackColor = true;
            // 
            // CreateTournamentButton
            // 
            this.CreateTournamentButton.Location = new System.Drawing.Point(194, 272);
            this.CreateTournamentButton.Name = "CreateTournamentButton";
            this.CreateTournamentButton.Size = new System.Drawing.Size(261, 82);
            this.CreateTournamentButton.TabIndex = 22;
            this.CreateTournamentButton.Text = "Create Tournament";
            this.CreateTournamentButton.UseVisualStyleBackColor = true;
            this.CreateTournamentButton.Click += new System.EventHandler(this.CreateTournamentButton_Click);
            // 
            // TournamentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(667, 405);
            this.Controls.Add(this.CreateTournamentButton);
            this.Controls.Add(this.LoadTournamentButton);
            this.Controls.Add(this.LoadExisitingTournamentDropDown);
            this.Controls.Add(this.LoadExistingTournamentlbl);
            this.Controls.Add(this.Headerlbl);
            this.Name = "TournamentDashboardForm";
            this.Text = "Tournament Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Headerlbl;
        private System.Windows.Forms.ComboBox LoadExisitingTournamentDropDown;
        private System.Windows.Forms.Label LoadExistingTournamentlbl;
        private System.Windows.Forms.Button LoadTournamentButton;
        private System.Windows.Forms.Button CreateTournamentButton;
    }
}
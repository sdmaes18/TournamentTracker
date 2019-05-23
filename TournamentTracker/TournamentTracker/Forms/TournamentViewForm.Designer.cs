namespace TrackerUI
{
    partial class TournamentViewForm
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
            this.TournamentNamelbl = new System.Windows.Forms.Label();
            this.Roundlbl = new System.Windows.Forms.Label();
            this.RoundDropDowncbox = new System.Windows.Forms.ComboBox();
            this.UnPlayOnlybox = new System.Windows.Forms.CheckBox();
            this.Matchuplbox = new System.Windows.Forms.ListBox();
            this.TeamOneName = new System.Windows.Forms.Label();
            this.TeamOneScorelbl = new System.Windows.Forms.Label();
            this.TeamOneScoreValuetbox = new System.Windows.Forms.TextBox();
            this.TeamTwoScoreValuetbox = new System.Windows.Forms.TextBox();
            this.TeamTwoScorelbl = new System.Windows.Forms.Label();
            this.TeamTwoNamelbl = new System.Windows.Forms.Label();
            this.Vslbl = new System.Windows.Forms.Label();
            this.Scorebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Headerlbl
            // 
            this.Headerlbl.AutoSize = true;
            this.Headerlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Headerlbl.Location = new System.Drawing.Point(43, 27);
            this.Headerlbl.Name = "Headerlbl";
            this.Headerlbl.Size = new System.Drawing.Size(206, 45);
            this.Headerlbl.TabIndex = 0;
            this.Headerlbl.Text = "Tournament: ";
            // 
            // TournamentNamelbl
            // 
            this.TournamentNamelbl.AutoSize = true;
            this.TournamentNamelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.TournamentNamelbl.Location = new System.Drawing.Point(238, 27);
            this.TournamentNamelbl.Name = "TournamentNamelbl";
            this.TournamentNamelbl.Size = new System.Drawing.Size(145, 45);
            this.TournamentNamelbl.TabIndex = 1;
            this.TournamentNamelbl.Text = "<none> ";
            // 
            // Roundlbl
            // 
            this.Roundlbl.AutoSize = true;
            this.Roundlbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Roundlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Roundlbl.Location = new System.Drawing.Point(54, 111);
            this.Roundlbl.Name = "Roundlbl";
            this.Roundlbl.Size = new System.Drawing.Size(111, 38);
            this.Roundlbl.TabIndex = 2;
            this.Roundlbl.Text = "Round: ";
            // 
            // RoundDropDowncbox
            // 
            this.RoundDropDowncbox.FormattingEnabled = true;
            this.RoundDropDowncbox.Location = new System.Drawing.Point(171, 111);
            this.RoundDropDowncbox.Name = "RoundDropDowncbox";
            this.RoundDropDowncbox.Size = new System.Drawing.Size(223, 53);
            this.RoundDropDowncbox.TabIndex = 3;
            this.RoundDropDowncbox.SelectedIndexChanged += new System.EventHandler(this.RoundDropDowncbox_SelectedIndexChanged);
            // 
            // UnPlayOnlybox
            // 
            this.UnPlayOnlybox.AutoSize = true;
            this.UnPlayOnlybox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UnPlayOnlybox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnPlayOnlybox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.UnPlayOnlybox.Location = new System.Drawing.Point(171, 170);
            this.UnPlayOnlybox.Name = "UnPlayOnlybox";
            this.UnPlayOnlybox.Size = new System.Drawing.Size(221, 42);
            this.UnPlayOnlybox.TabIndex = 4;
            this.UnPlayOnlybox.Text = "Unplayed Only";
            this.UnPlayOnlybox.UseVisualStyleBackColor = true;
            this.UnPlayOnlybox.CheckedChanged += new System.EventHandler(this.UnPlayOnlybox_CheckedChanged);
            // 
            // Matchuplbox
            // 
            this.Matchuplbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Matchuplbox.FormattingEnabled = true;
            this.Matchuplbox.ItemHeight = 45;
            this.Matchuplbox.Location = new System.Drawing.Point(49, 242);
            this.Matchuplbox.Name = "Matchuplbox";
            this.Matchuplbox.Size = new System.Drawing.Size(343, 272);
            this.Matchuplbox.TabIndex = 5;
            this.Matchuplbox.SelectedIndexChanged += new System.EventHandler(this.Matchuplbox_SelectedIndexChanged);
            // 
            // TeamOneName
            // 
            this.TeamOneName.AutoSize = true;
            this.TeamOneName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamOneName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.TeamOneName.Location = new System.Drawing.Point(460, 243);
            this.TeamOneName.Name = "TeamOneName";
            this.TeamOneName.Size = new System.Drawing.Size(172, 38);
            this.TeamOneName.TabIndex = 6;
            this.TeamOneName.Text = "<team one>";
            // 
            // TeamOneScorelbl
            // 
            this.TeamOneScorelbl.AutoSize = true;
            this.TeamOneScorelbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamOneScorelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.TeamOneScorelbl.Location = new System.Drawing.Point(460, 297);
            this.TeamOneScorelbl.Name = "TeamOneScorelbl";
            this.TeamOneScorelbl.Size = new System.Drawing.Size(86, 38);
            this.TeamOneScorelbl.TabIndex = 7;
            this.TeamOneScorelbl.Text = "Score";
            // 
            // TeamOneScoreValuetbox
            // 
            this.TeamOneScoreValuetbox.Location = new System.Drawing.Point(575, 297);
            this.TeamOneScoreValuetbox.Name = "TeamOneScoreValuetbox";
            this.TeamOneScoreValuetbox.Size = new System.Drawing.Size(174, 50);
            this.TeamOneScoreValuetbox.TabIndex = 8;
            // 
            // TeamTwoScoreValuetbox
            // 
            this.TeamTwoScoreValuetbox.Location = new System.Drawing.Point(575, 464);
            this.TeamTwoScoreValuetbox.Name = "TeamTwoScoreValuetbox";
            this.TeamTwoScoreValuetbox.Size = new System.Drawing.Size(174, 50);
            this.TeamTwoScoreValuetbox.TabIndex = 11;
            // 
            // TeamTwoScorelbl
            // 
            this.TeamTwoScorelbl.AutoSize = true;
            this.TeamTwoScorelbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamTwoScorelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.TeamTwoScorelbl.Location = new System.Drawing.Point(470, 464);
            this.TeamTwoScorelbl.Name = "TeamTwoScorelbl";
            this.TeamTwoScorelbl.Size = new System.Drawing.Size(86, 38);
            this.TeamTwoScorelbl.TabIndex = 10;
            this.TeamTwoScorelbl.Text = "Score";
            // 
            // TeamTwoNamelbl
            // 
            this.TeamTwoNamelbl.AutoSize = true;
            this.TeamTwoNamelbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamTwoNamelbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.TeamTwoNamelbl.Location = new System.Drawing.Point(460, 403);
            this.TeamTwoNamelbl.Name = "TeamTwoNamelbl";
            this.TeamTwoNamelbl.Size = new System.Drawing.Size(170, 38);
            this.TeamTwoNamelbl.TabIndex = 9;
            this.TeamTwoNamelbl.Text = "<team two>";
            this.TeamTwoNamelbl.UseWaitCursor = true;
            // 
            // Vslbl
            // 
            this.Vslbl.AutoSize = true;
            this.Vslbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vslbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Vslbl.Location = new System.Drawing.Point(647, 364);
            this.Vslbl.Name = "Vslbl";
            this.Vslbl.Size = new System.Drawing.Size(42, 38);
            this.Vslbl.TabIndex = 12;
            this.Vslbl.Text = "vs";
            this.Vslbl.UseWaitCursor = true;
            // 
            // Scorebtn
            // 
            this.Scorebtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Scorebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.Scorebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Scorebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Scorebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.Scorebtn.Location = new System.Drawing.Point(769, 364);
            this.Scorebtn.Name = "Scorebtn";
            this.Scorebtn.Size = new System.Drawing.Size(156, 82);
            this.Scorebtn.TabIndex = 13;
            this.Scorebtn.Text = "Score";
            this.Scorebtn.UseVisualStyleBackColor = true;
            this.Scorebtn.Click += new System.EventHandler(this.Scorebtn_Click);
            // 
            // TournamentViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(975, 548);
            this.Controls.Add(this.Scorebtn);
            this.Controls.Add(this.Vslbl);
            this.Controls.Add(this.TeamTwoScoreValuetbox);
            this.Controls.Add(this.TeamTwoScorelbl);
            this.Controls.Add(this.TeamTwoNamelbl);
            this.Controls.Add(this.TeamOneScoreValuetbox);
            this.Controls.Add(this.TeamOneScorelbl);
            this.Controls.Add(this.TeamOneName);
            this.Controls.Add(this.Matchuplbox);
            this.Controls.Add(this.UnPlayOnlybox);
            this.Controls.Add(this.RoundDropDowncbox);
            this.Controls.Add(this.Roundlbl);
            this.Controls.Add(this.TournamentNamelbl);
            this.Controls.Add(this.Headerlbl);
            this.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TournamentViewForm";
            this.Text = "vs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Headerlbl;
        private System.Windows.Forms.Label TournamentNamelbl;
        private System.Windows.Forms.Label Roundlbl;
        private System.Windows.Forms.ComboBox RoundDropDowncbox;
        private System.Windows.Forms.CheckBox UnPlayOnlybox;
        private System.Windows.Forms.ListBox Matchuplbox;
        private System.Windows.Forms.Label TeamOneName;
        private System.Windows.Forms.Label TeamOneScorelbl;
        private System.Windows.Forms.TextBox TeamOneScoreValuetbox;
        private System.Windows.Forms.TextBox TeamTwoScoreValuetbox;
        private System.Windows.Forms.Label TeamTwoScorelbl;
        private System.Windows.Forms.Label TeamTwoNamelbl;
        private System.Windows.Forms.Label Vslbl;
        private System.Windows.Forms.Button Scorebtn;
    }
}


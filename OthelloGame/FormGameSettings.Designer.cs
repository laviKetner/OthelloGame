namespace Ex02_Othelo
{
    partial class FormGameSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameSettings));
            this.button_SinglePlayer = new System.Windows.Forms.Button();
            this.button_TwoPlayers = new System.Windows.Forms.Button();
            this.PlayOnline_Button = new System.Windows.Forms.Button();
            this.LoadGame_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_SinglePlayer
            // 
            this.button_SinglePlayer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_SinglePlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_SinglePlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_SinglePlayer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_SinglePlayer.Font = new System.Drawing.Font("David", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SinglePlayer.ForeColor = System.Drawing.Color.SpringGreen;
            this.button_SinglePlayer.Location = new System.Drawing.Point(202, 55);
            this.button_SinglePlayer.Name = "button_SinglePlayer";
            this.button_SinglePlayer.Size = new System.Drawing.Size(219, 49);
            this.button_SinglePlayer.TabIndex = 0;
            this.button_SinglePlayer.Text = "Single Player";
            this.button_SinglePlayer.UseVisualStyleBackColor = false;
            this.button_SinglePlayer.Click += new System.EventHandler(this.button_SinglePlayer_Click);
            // 
            // button_TwoPlayers
            // 
            this.button_TwoPlayers.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_TwoPlayers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_TwoPlayers.Font = new System.Drawing.Font("David", 16.2F, System.Drawing.FontStyle.Bold);
            this.button_TwoPlayers.ForeColor = System.Drawing.Color.SpringGreen;
            this.button_TwoPlayers.Location = new System.Drawing.Point(202, 170);
            this.button_TwoPlayers.Name = "button_TwoPlayers";
            this.button_TwoPlayers.Size = new System.Drawing.Size(219, 49);
            this.button_TwoPlayers.TabIndex = 1;
            this.button_TwoPlayers.Text = "Two Players";
            this.button_TwoPlayers.UseVisualStyleBackColor = false;
            this.button_TwoPlayers.Click += new System.EventHandler(this.button_TwoPlayers_Click);
            // 
            // PlayOnline_Button
            // 
            this.PlayOnline_Button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PlayOnline_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PlayOnline_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.PlayOnline_Button.Font = new System.Drawing.Font("David", 16.2F, System.Drawing.FontStyle.Bold);
            this.PlayOnline_Button.ForeColor = System.Drawing.Color.SpringGreen;
            this.PlayOnline_Button.Location = new System.Drawing.Point(202, 292);
            this.PlayOnline_Button.Name = "PlayOnline_Button";
            this.PlayOnline_Button.Size = new System.Drawing.Size(219, 49);
            this.PlayOnline_Button.TabIndex = 2;
            this.PlayOnline_Button.Text = "Play Online";
            this.PlayOnline_Button.UseVisualStyleBackColor = false;
            // 
            // LoadGame_button
            // 
            this.LoadGame_button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LoadGame_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadGame_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LoadGame_button.Font = new System.Drawing.Font("David", 16.2F, System.Drawing.FontStyle.Bold);
            this.LoadGame_button.ForeColor = System.Drawing.Color.SpringGreen;
            this.LoadGame_button.Location = new System.Drawing.Point(202, 419);
            this.LoadGame_button.Name = "LoadGame_button";
            this.LoadGame_button.Size = new System.Drawing.Size(219, 49);
            this.LoadGame_button.TabIndex = 3;
            this.LoadGame_button.Text = "Load Game";
            this.LoadGame_button.UseVisualStyleBackColor = false;
            this.LoadGame_button.Click += new System.EventHandler(this.LoadGame_button_Click);
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(646, 544);
            this.Controls.Add(this.LoadGame_button);
            this.Controls.Add(this.PlayOnline_Button);
            this.Controls.Add(this.button_TwoPlayers);
            this.Controls.Add(this.button_SinglePlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello Game - by Lavi Ketner";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_SinglePlayer;
        private System.Windows.Forms.Button button_TwoPlayers;
        private System.Windows.Forms.Button PlayOnline_Button;
        private System.Windows.Forms.Button LoadGame_button;
    }
}
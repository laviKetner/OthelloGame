namespace Ex02_Othelo
{
    partial class FormSinglePlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSinglePlayer));
            this.button_Play = new System.Windows.Forms.Button();
            this.PlayerName_Label = new System.Windows.Forms.Label();
            this.Player1Name_TextBox = new System.Windows.Forms.TextBox();
            this.singlePlayer_Panel = new System.Windows.Forms.Panel();
            this.radioButton_6X6 = new System.Windows.Forms.RadioButton();
            this.radioButton_10X10 = new System.Windows.Forms.RadioButton();
            this.radioButton_8X8 = new System.Windows.Forms.RadioButton();
            this.BoardSize_groupBox = new System.Windows.Forms.GroupBox();
            this.Difficulty_Panel = new System.Windows.Forms.Panel();
            this.Easy_RadioButton = new System.Windows.Forms.RadioButton();
            this.Hard_RadioButton = new System.Windows.Forms.RadioButton();
            this.Medium_RadioButton = new System.Windows.Forms.RadioButton();
            this.Difficulty_GroupBox = new System.Windows.Forms.GroupBox();
            this.singlePlayer_Panel.SuspendLayout();
            this.Difficulty_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Play
            // 
            this.button_Play.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Play.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.button_Play, "button_Play");
            this.button_Play.ForeColor = System.Drawing.Color.SpringGreen;
            this.button_Play.Name = "button_Play";
            this.button_Play.UseVisualStyleBackColor = false;
            this.button_Play.Click += new System.EventHandler(this.button_Play_Click);
            // 
            // PlayerName_Label
            // 
            resources.ApplyResources(this.PlayerName_Label, "PlayerName_Label");
            this.PlayerName_Label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PlayerName_Label.ForeColor = System.Drawing.Color.SpringGreen;
            this.PlayerName_Label.Name = "PlayerName_Label";
            // 
            // Player1Name_TextBox
            // 
            this.Player1Name_TextBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Player1Name_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player1Name_TextBox.ForeColor = System.Drawing.Color.SpringGreen;
            resources.ApplyResources(this.Player1Name_TextBox, "Player1Name_TextBox");
            this.Player1Name_TextBox.Name = "Player1Name_TextBox";
            // 
            // singlePlayer_Panel
            // 
            this.singlePlayer_Panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.singlePlayer_Panel.Controls.Add(this.radioButton_6X6);
            this.singlePlayer_Panel.Controls.Add(this.radioButton_10X10);
            this.singlePlayer_Panel.Controls.Add(this.Player1Name_TextBox);
            this.singlePlayer_Panel.Controls.Add(this.radioButton_8X8);
            this.singlePlayer_Panel.Controls.Add(this.PlayerName_Label);
            this.singlePlayer_Panel.Controls.Add(this.BoardSize_groupBox);
            resources.ApplyResources(this.singlePlayer_Panel, "singlePlayer_Panel");
            this.singlePlayer_Panel.Name = "singlePlayer_Panel";
            // 
            // radioButton_6X6
            // 
            resources.ApplyResources(this.radioButton_6X6, "radioButton_6X6");
            this.radioButton_6X6.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_6X6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton_6X6.ForeColor = System.Drawing.Color.SpringGreen;
            this.radioButton_6X6.Name = "radioButton_6X6";
            this.radioButton_6X6.TabStop = true;
            this.radioButton_6X6.UseVisualStyleBackColor = false;
            // 
            // radioButton_10X10
            // 
            resources.ApplyResources(this.radioButton_10X10, "radioButton_10X10");
            this.radioButton_10X10.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_10X10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton_10X10.ForeColor = System.Drawing.Color.SpringGreen;
            this.radioButton_10X10.Name = "radioButton_10X10";
            this.radioButton_10X10.TabStop = true;
            this.radioButton_10X10.UseVisualStyleBackColor = false;
            // 
            // radioButton_8X8
            // 
            resources.ApplyResources(this.radioButton_8X8, "radioButton_8X8");
            this.radioButton_8X8.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_8X8.Checked = true;
            this.radioButton_8X8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton_8X8.ForeColor = System.Drawing.Color.SpringGreen;
            this.radioButton_8X8.Name = "radioButton_8X8";
            this.radioButton_8X8.TabStop = true;
            this.radioButton_8X8.UseVisualStyleBackColor = false;
            // 
            // BoardSize_groupBox
            // 
            this.BoardSize_groupBox.ForeColor = System.Drawing.Color.SpringGreen;
            resources.ApplyResources(this.BoardSize_groupBox, "BoardSize_groupBox");
            this.BoardSize_groupBox.Name = "BoardSize_groupBox";
            this.BoardSize_groupBox.TabStop = false;
            // 
            // Difficulty_Panel
            // 
            this.Difficulty_Panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Difficulty_Panel.Controls.Add(this.Easy_RadioButton);
            this.Difficulty_Panel.Controls.Add(this.Hard_RadioButton);
            this.Difficulty_Panel.Controls.Add(this.Medium_RadioButton);
            this.Difficulty_Panel.Controls.Add(this.Difficulty_GroupBox);
            resources.ApplyResources(this.Difficulty_Panel, "Difficulty_Panel");
            this.Difficulty_Panel.Name = "Difficulty_Panel";
            // 
            // Easy_RadioButton
            // 
            resources.ApplyResources(this.Easy_RadioButton, "Easy_RadioButton");
            this.Easy_RadioButton.BackColor = System.Drawing.Color.Transparent;
            this.Easy_RadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Easy_RadioButton.ForeColor = System.Drawing.Color.SpringGreen;
            this.Easy_RadioButton.Name = "Easy_RadioButton";
            this.Easy_RadioButton.TabStop = true;
            this.Easy_RadioButton.UseVisualStyleBackColor = false;
            // 
            // Hard_RadioButton
            // 
            resources.ApplyResources(this.Hard_RadioButton, "Hard_RadioButton");
            this.Hard_RadioButton.BackColor = System.Drawing.Color.Transparent;
            this.Hard_RadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Hard_RadioButton.ForeColor = System.Drawing.Color.SpringGreen;
            this.Hard_RadioButton.Name = "Hard_RadioButton";
            this.Hard_RadioButton.TabStop = true;
            this.Hard_RadioButton.UseVisualStyleBackColor = false;
            // 
            // Medium_RadioButton
            // 
            resources.ApplyResources(this.Medium_RadioButton, "Medium_RadioButton");
            this.Medium_RadioButton.BackColor = System.Drawing.Color.Transparent;
            this.Medium_RadioButton.Checked = true;
            this.Medium_RadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Medium_RadioButton.ForeColor = System.Drawing.Color.SpringGreen;
            this.Medium_RadioButton.Name = "Medium_RadioButton";
            this.Medium_RadioButton.TabStop = true;
            this.Medium_RadioButton.UseVisualStyleBackColor = false;
            // 
            // Difficulty_GroupBox
            // 
            this.Difficulty_GroupBox.BackColor = System.Drawing.Color.Transparent;
            this.Difficulty_GroupBox.ForeColor = System.Drawing.Color.SpringGreen;
            resources.ApplyResources(this.Difficulty_GroupBox, "Difficulty_GroupBox");
            this.Difficulty_GroupBox.Name = "Difficulty_GroupBox";
            this.Difficulty_GroupBox.TabStop = false;
            // 
            // FormSinglePlayer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Difficulty_Panel);
            this.Controls.Add(this.button_Play);
            this.Controls.Add(this.singlePlayer_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSinglePlayer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.singlePlayer_Panel.ResumeLayout(false);
            this.singlePlayer_Panel.PerformLayout();
            this.Difficulty_Panel.ResumeLayout(false);
            this.Difficulty_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Play;
        private System.Windows.Forms.Label PlayerName_Label;
        private System.Windows.Forms.TextBox Player1Name_TextBox;
        private System.Windows.Forms.Panel singlePlayer_Panel;
        private System.Windows.Forms.RadioButton radioButton_6X6;
        private System.Windows.Forms.RadioButton radioButton_10X10;
        private System.Windows.Forms.RadioButton radioButton_8X8;
        private System.Windows.Forms.GroupBox BoardSize_groupBox;
        private System.Windows.Forms.Panel Difficulty_Panel;
        private System.Windows.Forms.RadioButton Easy_RadioButton;
        private System.Windows.Forms.RadioButton Hard_RadioButton;
        private System.Windows.Forms.RadioButton Medium_RadioButton;
        private System.Windows.Forms.GroupBox Difficulty_GroupBox;
    }
}
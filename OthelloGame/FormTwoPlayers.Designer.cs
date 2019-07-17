namespace Ex02_Othelo
{
    partial class FormTwoPlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTwoPlayers));
            this.Play_Button = new System.Windows.Forms.Button();
            this.TwoPlayers_Panel = new System.Windows.Forms.Panel();
            this.Player2Name_TextBox = new System.Windows.Forms.TextBox();
            this.Player2Name_Label = new System.Windows.Forms.Label();
            this.radioButton_6X6 = new System.Windows.Forms.RadioButton();
            this.radioButton_10X10 = new System.Windows.Forms.RadioButton();
            this.Player1Name_TextBox = new System.Windows.Forms.TextBox();
            this.radioButton_8X8 = new System.Windows.Forms.RadioButton();
            this.Player1Name_Label = new System.Windows.Forms.Label();
            this.BoardSize_groupBox = new System.Windows.Forms.GroupBox();
            this.TwoPlayers_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Play_Button
            // 
            this.Play_Button.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Play_Button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Play_Button.Font = new System.Drawing.Font("David", 16.2F, System.Drawing.FontStyle.Bold);
            this.Play_Button.ForeColor = System.Drawing.Color.SpringGreen;
            this.Play_Button.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Play_Button.Location = new System.Drawing.Point(190, 305);
            this.Play_Button.Name = "Play_Button";
            this.Play_Button.Size = new System.Drawing.Size(168, 44);
            this.Play_Button.TabIndex = 5;
            this.Play_Button.Text = "Play!";
            this.Play_Button.UseVisualStyleBackColor = false;
            this.Play_Button.Click += new System.EventHandler(this.Play_Button_Click);
            // 
            // TwoPlayers_Panel
            // 
            this.TwoPlayers_Panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TwoPlayers_Panel.Controls.Add(this.radioButton_6X6);
            this.TwoPlayers_Panel.Controls.Add(this.radioButton_8X8);
            this.TwoPlayers_Panel.Controls.Add(this.radioButton_10X10);
            this.TwoPlayers_Panel.Controls.Add(this.BoardSize_groupBox);
            this.TwoPlayers_Panel.Controls.Add(this.Player2Name_TextBox);
            this.TwoPlayers_Panel.Controls.Add(this.Player2Name_Label);
            this.TwoPlayers_Panel.Controls.Add(this.Player1Name_TextBox);
            this.TwoPlayers_Panel.Controls.Add(this.Player1Name_Label);
            this.TwoPlayers_Panel.Location = new System.Drawing.Point(87, 75);
            this.TwoPlayers_Panel.Name = "TwoPlayers_Panel";
            this.TwoPlayers_Panel.Size = new System.Drawing.Size(376, 306);
            this.TwoPlayers_Panel.TabIndex = 13;
            // 
            // Player2Name_TextBox
            // 
            this.Player2Name_TextBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Player2Name_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player2Name_TextBox.ForeColor = System.Drawing.Color.SpringGreen;
            this.Player2Name_TextBox.Location = new System.Drawing.Point(172, 148);
            this.Player2Name_TextBox.Name = "Player2Name_TextBox";
            this.Player2Name_TextBox.Size = new System.Drawing.Size(193, 22);
            this.Player2Name_TextBox.TabIndex = 4;
            this.Player2Name_TextBox.Text = "player2";
            // 
            // Player2Name_Label
            // 
            this.Player2Name_Label.AutoSize = true;
            this.Player2Name_Label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Player2Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F);
            this.Player2Name_Label.ForeColor = System.Drawing.Color.SpringGreen;
            this.Player2Name_Label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Player2Name_Label.Location = new System.Drawing.Point(0, 145);
            this.Player2Name_Label.Name = "Player2Name_Label";
            this.Player2Name_Label.Size = new System.Drawing.Size(157, 26);
            this.Player2Name_Label.TabIndex = 10;
            this.Player2Name_Label.Text = "Player2 Name:";
            // 
            // radioButton_6X6
            // 
            this.radioButton_6X6.AutoSize = true;
            this.radioButton_6X6.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_6X6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton_6X6.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_6X6.ForeColor = System.Drawing.Color.SpringGreen;
            this.radioButton_6X6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_6X6.Location = new System.Drawing.Point(16, 28);
            this.radioButton_6X6.Name = "radioButton_6X6";
            this.radioButton_6X6.Size = new System.Drawing.Size(69, 23);
            this.radioButton_6X6.TabIndex = 0;
            this.radioButton_6X6.Text = "6 X 6";
            this.radioButton_6X6.UseVisualStyleBackColor = false;
            // 
            // radioButton_10X10
            // 
            this.radioButton_10X10.AutoSize = true;
            this.radioButton_10X10.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_10X10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton_10X10.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_10X10.ForeColor = System.Drawing.Color.SpringGreen;
            this.radioButton_10X10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_10X10.Location = new System.Drawing.Point(267, 28);
            this.radioButton_10X10.Name = "radioButton_10X10";
            this.radioButton_10X10.Size = new System.Drawing.Size(87, 23);
            this.radioButton_10X10.TabIndex = 2;
            this.radioButton_10X10.Text = "10 X 10";
            this.radioButton_10X10.UseVisualStyleBackColor = false;
            // 
            // Player1Name_TextBox
            // 
            this.Player1Name_TextBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Player1Name_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player1Name_TextBox.ForeColor = System.Drawing.Color.SpringGreen;
            this.Player1Name_TextBox.Location = new System.Drawing.Point(172, 111);
            this.Player1Name_TextBox.Name = "Player1Name_TextBox";
            this.Player1Name_TextBox.Size = new System.Drawing.Size(193, 22);
            this.Player1Name_TextBox.TabIndex = 3;
            this.Player1Name_TextBox.Text = "player1";
            // 
            // radioButton_8X8
            // 
            this.radioButton_8X8.AutoSize = true;
            this.radioButton_8X8.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_8X8.Checked = true;
            this.radioButton_8X8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton_8X8.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_8X8.ForeColor = System.Drawing.Color.SpringGreen;
            this.radioButton_8X8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_8X8.Location = new System.Drawing.Point(146, 28);
            this.radioButton_8X8.Name = "radioButton_8X8";
            this.radioButton_8X8.Size = new System.Drawing.Size(69, 23);
            this.radioButton_8X8.TabIndex = 1;
            this.radioButton_8X8.TabStop = true;
            this.radioButton_8X8.Text = "8 X 8";
            this.radioButton_8X8.UseVisualStyleBackColor = false;
            // 
            // Player1Name_Label
            // 
            this.Player1Name_Label.AutoSize = true;
            this.Player1Name_Label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Player1Name_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F);
            this.Player1Name_Label.ForeColor = System.Drawing.Color.SpringGreen;
            this.Player1Name_Label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Player1Name_Label.Location = new System.Drawing.Point(0, 108);
            this.Player1Name_Label.Name = "Player1Name_Label";
            this.Player1Name_Label.Size = new System.Drawing.Size(157, 26);
            this.Player1Name_Label.TabIndex = 0;
            this.Player1Name_Label.Text = "Player1 Name:";
            // 
            // BoardSize_groupBox
            // 
            this.BoardSize_groupBox.BackColor = System.Drawing.Color.Transparent;
            this.BoardSize_groupBox.ForeColor = System.Drawing.Color.SpringGreen;
            this.BoardSize_groupBox.Location = new System.Drawing.Point(7, 7);
            this.BoardSize_groupBox.Name = "BoardSize_groupBox";
            this.BoardSize_groupBox.Size = new System.Drawing.Size(358, 57);
            this.BoardSize_groupBox.TabIndex = 14;
            this.BoardSize_groupBox.TabStop = false;
            this.BoardSize_groupBox.Text = " Board size: ";
            // 
            // FormTwoPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(550, 463);
            this.Controls.Add(this.Play_Button);
            this.Controls.Add(this.TwoPlayers_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTwoPlayers";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OthlloGame - by Lavi Ketner";
            this.TwoPlayers_Panel.ResumeLayout(false);
            this.TwoPlayers_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Play_Button;
        private System.Windows.Forms.Panel TwoPlayers_Panel;
        private System.Windows.Forms.TextBox Player2Name_TextBox;
        private System.Windows.Forms.Label Player2Name_Label;
        private System.Windows.Forms.RadioButton radioButton_6X6;
        private System.Windows.Forms.RadioButton radioButton_10X10;
        private System.Windows.Forms.TextBox Player1Name_TextBox;
        private System.Windows.Forms.RadioButton radioButton_8X8;
        private System.Windows.Forms.Label Player1Name_Label;
        private System.Windows.Forms.GroupBox BoardSize_groupBox;
    }
}
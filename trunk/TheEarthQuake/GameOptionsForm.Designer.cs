namespace TheEarthQuake.GUI
{
    partial class GameOptionsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxBonusesOn = new System.Windows.Forms.CheckBox();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxSpecial = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxBomb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxLeft = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxDown = new System.Windows.Forms.TextBox();
            this.tbxRight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxTop = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbxPlayer = new System.Windows.Forms.ComboBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numSound = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numMusic = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grafika";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "T³o:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(61, 24);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxBonusesOn);
            this.groupBox2.Controls.Add(this.numSpeed);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 87);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gra";
            // 
            // cbxBonusesOn
            // 
            this.cbxBonusesOn.AutoSize = true;
            this.cbxBonusesOn.Location = new System.Drawing.Point(102, 54);
            this.cbxBonusesOn.Name = "cbxBonusesOn";
            this.cbxBonusesOn.Size = new System.Drawing.Size(61, 17);
            this.cbxBonusesOn.TabIndex = 6;
            this.cbxBonusesOn.Text = "Bonusy";
            this.cbxBonusesOn.UseVisualStyleBackColor = true;
            this.cbxBonusesOn.Click += new System.EventHandler(this.cbxBonusesOn_Click);
            // 
            // numSpeed
            // 
            this.numSpeed.Location = new System.Drawing.Point(102, 24);
            this.numSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(53, 20);
            this.numSpeed.TabIndex = 5;
            this.numSpeed.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSpeed.ValueChanged += new System.EventHandler(this.numSpeed_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Prêdkoœæ gry:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.tbxSpecial);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tbxBomb);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tbxLeft);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tbxDown);
            this.groupBox3.Controls.Add(this.tbxRight);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbxTop);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.cbxPlayer);
            this.groupBox3.Location = new System.Drawing.Point(266, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(420, 306);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sterowanie";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(242, 252);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Special:";
            // 
            // tbxSpecial
            // 
            this.tbxSpecial.Location = new System.Drawing.Point(291, 249);
            this.tbxSpecial.Name = "tbxSpecial";
            this.tbxSpecial.ReadOnly = true;
            this.tbxSpecial.Size = new System.Drawing.Size(113, 20);
            this.tbxSpecial.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(242, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Bomba:";
            // 
            // tbxBomb
            // 
            this.tbxBomb.Location = new System.Drawing.Point(291, 212);
            this.tbxBomb.Name = "tbxBomb";
            this.tbxBomb.ReadOnly = true;
            this.tbxBomb.Size = new System.Drawing.Size(113, 20);
            this.tbxBomb.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(242, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Lewo:";
            // 
            // tbxLeft
            // 
            this.tbxLeft.Location = new System.Drawing.Point(291, 174);
            this.tbxLeft.Name = "tbxLeft";
            this.tbxLeft.ReadOnly = true;
            this.tbxLeft.Size = new System.Drawing.Size(113, 20);
            this.tbxLeft.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(242, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Dó³:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Prawo:";
            // 
            // tbxDown
            // 
            this.tbxDown.Location = new System.Drawing.Point(291, 101);
            this.tbxDown.Name = "tbxDown";
            this.tbxDown.ReadOnly = true;
            this.tbxDown.Size = new System.Drawing.Size(113, 20);
            this.tbxDown.TabIndex = 7;
            // 
            // tbxRight
            // 
            this.tbxRight.Location = new System.Drawing.Point(291, 138);
            this.tbxRight.Name = "tbxRight";
            this.tbxRight.ReadOnly = true;
            this.tbxRight.Size = new System.Drawing.Size(113, 20);
            this.tbxRight.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Góra:";
            // 
            // tbxTop
            // 
            this.tbxTop.Location = new System.Drawing.Point(291, 64);
            this.tbxTop.Name = "tbxTop";
            this.tbxTop.ReadOnly = true;
            this.tbxTop.Size = new System.Drawing.Size(113, 20);
            this.tbxTop.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TheEarthQuake.GUI.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(18, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // cbxPlayer
            // 
            this.cbxPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlayer.FormattingEnabled = true;
            this.cbxPlayer.Items.AddRange(new object[] {
            "Gracz1",
            "Gracz2"});
            this.cbxPlayer.Location = new System.Drawing.Point(18, 19);
            this.cbxPlayer.Name = "cbxPlayer";
            this.cbxPlayer.Size = new System.Drawing.Size(260, 21);
            this.cbxPlayer.TabIndex = 0;
            this.cbxPlayer.SelectedIndexChanged += new System.EventHandler(this.cbxPlayer_SelectedIndexChanged);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(13, 346);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "Powrót";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.numSound);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.numMusic);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(12, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(247, 87);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dzwiêk";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(159, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "%";
            // 
            // numSound
            // 
            this.numSound.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSound.Location = new System.Drawing.Point(103, 51);
            this.numSound.Name = "numSound";
            this.numSound.Size = new System.Drawing.Size(53, 20);
            this.numSound.TabIndex = 8;
            this.numSound.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numSound.ValueChanged += new System.EventHandler(this.numSound_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(59, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Efekty:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(157, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "%";
            // 
            // numMusic
            // 
            this.numMusic.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMusic.Location = new System.Drawing.Point(103, 24);
            this.numMusic.Name = "numMusic";
            this.numMusic.Size = new System.Drawing.Size(53, 20);
            this.numMusic.TabIndex = 5;
            this.numMusic.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numMusic.ValueChanged += new System.EventHandler(this.numMusic_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(50, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Muzyka:";
            // 
            // GameOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 381);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameOptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opcje gry";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMusic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.CheckBox cbxBonusesOn;
        private System.Windows.Forms.ComboBox cbxPlayer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbxTop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxDown;
        private System.Windows.Forms.TextBox tbxRight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxLeft;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxBomb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxSpecial;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numMusic;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numSound;
        private System.Windows.Forms.Label label15;
    }
}
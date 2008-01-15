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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxBonusesOn = new System.Windows.Forms.CheckBox();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSpecial = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxBomb = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tbxTop = new System.Windows.Forms.TextBox();
            this.tbxLeft = new System.Windows.Forms.TextBox();
            this.tbxDown = new System.Windows.Forms.TextBox();
            this.tbxRight = new System.Windows.Forms.TextBox();
            this.cbxPlayer = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numSound = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numMusic = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbxBonusesOn);
            this.groupBox2.Controls.Add(this.numSpeed);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 87);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gra";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "%";
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
            this.numSpeed.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSpeed.Location = new System.Drawing.Point(102, 24);
            this.numSpeed.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(53, 20);
            this.numSpeed.TabIndex = 5;
            this.numSpeed.Value = new decimal(new int[] {
            10,
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
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbxSpecial);
            this.groupBox3.Controls.Add(this.pictureBox6);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tbxBomb);
            this.groupBox3.Controls.Add(this.pictureBox5);
            this.groupBox3.Controls.Add(this.tbxTop);
            this.groupBox3.Controls.Add(this.tbxLeft);
            this.groupBox3.Controls.Add(this.tbxDown);
            this.groupBox3.Controls.Add(this.tbxRight);
            this.groupBox3.Controls.Add(this.cbxPlayer);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Controls.Add(this.pictureBox4);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Location = new System.Drawing.Point(266, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(420, 356);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sterowanie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Special";
            // 
            // tbxSpecial
            // 
            this.tbxSpecial.Location = new System.Drawing.Point(62, 319);
            this.tbxSpecial.Name = "tbxSpecial";
            this.tbxSpecial.ReadOnly = true;
            this.tbxSpecial.Size = new System.Drawing.Size(70, 20);
            this.tbxSpecial.TabIndex = 22;
            this.tbxSpecial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSpecial_TextChanged);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::TheEarthQuake.GUI.Properties.Resources.detonator;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(61, 247);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(71, 66);
            this.pictureBox6.TabIndex = 23;
            this.pictureBox6.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Bomb";
            // 
            // tbxBomb
            // 
            this.tbxBomb.Location = new System.Drawing.Point(254, 319);
            this.tbxBomb.Name = "tbxBomb";
            this.tbxBomb.ReadOnly = true;
            this.tbxBomb.Size = new System.Drawing.Size(70, 20);
            this.tbxBomb.TabIndex = 13;
            this.tbxBomb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxBomb_TextChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::TheEarthQuake.GUI.Properties.Resources.explosion;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(253, 247);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(71, 66);
            this.pictureBox5.TabIndex = 20;
            this.pictureBox5.TabStop = false;
            // 
            // tbxTop
            // 
            this.tbxTop.Location = new System.Drawing.Point(175, 119);
            this.tbxTop.Name = "tbxTop";
            this.tbxTop.ReadOnly = true;
            this.tbxTop.Size = new System.Drawing.Size(39, 20);
            this.tbxTop.TabIndex = 2;
            this.tbxTop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxTop_KeyDown);
            // 
            // tbxLeft
            // 
            this.tbxLeft.Location = new System.Drawing.Point(98, 153);
            this.tbxLeft.Name = "tbxLeft";
            this.tbxLeft.ReadOnly = true;
            this.tbxLeft.Size = new System.Drawing.Size(50, 20);
            this.tbxLeft.TabIndex = 9;
            this.tbxLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxLeft_TextChanged);
            // 
            // tbxDown
            // 
            this.tbxDown.Location = new System.Drawing.Point(175, 185);
            this.tbxDown.Name = "tbxDown";
            this.tbxDown.ReadOnly = true;
            this.tbxDown.Size = new System.Drawing.Size(39, 20);
            this.tbxDown.TabIndex = 7;
            this.tbxDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDown_KeyDown);
            // 
            // tbxRight
            // 
            this.tbxRight.Location = new System.Drawing.Point(236, 153);
            this.tbxRight.Name = "tbxRight";
            this.tbxRight.ReadOnly = true;
            this.tbxRight.Size = new System.Drawing.Size(40, 20);
            this.tbxRight.TabIndex = 7;
            this.tbxRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxRight_TextChanged);
            // 
            // cbxPlayer
            // 
            this.cbxPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlayer.FormattingEnabled = true;
            this.cbxPlayer.Items.AddRange(new object[] {
            "Gracz1",
            "Gracz2"});
            this.cbxPlayer.Location = new System.Drawing.Point(61, 18);
            this.cbxPlayer.Name = "cbxPlayer";
            this.cbxPlayer.Size = new System.Drawing.Size(260, 21);
            this.cbxPlayer.TabIndex = 0;
            this.cbxPlayer.SelectedIndexChanged += new System.EventHandler(this.cbxPlayer_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::TheEarthQuake.GUI.Properties.Resources.right;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(224, 117);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(97, 93);
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::TheEarthQuake.GUI.Properties.Resources.left;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(61, 117);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(97, 93);
            this.pictureBox4.TabIndex = 19;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TheEarthQuake.GUI.Properties.Resources.up;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(145, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 93);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::TheEarthQuake.GUI.Properties.Resources.down;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(145, 179);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(97, 93);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
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
            this.groupBox4.Location = new System.Drawing.Point(13, 13);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameOptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opcje gry";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameOptionsForm_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMusic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.CheckBox cbxBonusesOn;
        private System.Windows.Forms.ComboBox cbxPlayer;
        private System.Windows.Forms.TextBox tbxTop;
        private System.Windows.Forms.TextBox tbxDown;
        private System.Windows.Forms.TextBox tbxRight;
        private System.Windows.Forms.TextBox tbxLeft;
        private System.Windows.Forms.TextBox tbxBomb;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numMusic;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numSound;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSpecial;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label4;
    }
}
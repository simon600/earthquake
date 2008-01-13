using System.Windows.Forms;

namespace TheEarthQuake.GUI
{
    partial class SelectPlayerForm : Form
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
            this.player1ClassesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.numberOfMineProgressBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.healthProgressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.speedProgressBar = new System.Windows.Forms.ProgressBar();
            this.powerProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.rangeProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.player2ClassesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.numberOfMineProgressBar2 = new System.Windows.Forms.ProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.healthProgressBar2 = new System.Windows.Forms.ProgressBar();
            this.label10 = new System.Windows.Forms.Label();
            this.speedProgressBar2 = new System.Windows.Forms.ProgressBar();
            this.powerProgressBar2 = new System.Windows.Forms.ProgressBar();
            this.label11 = new System.Windows.Forms.Label();
            this.rangeProgressBar2 = new System.Windows.Forms.ProgressBar();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.player1ClassesPanel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numberOfMineProgressBar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.healthProgressBar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.speedProgressBar);
            this.groupBox1.Controls.Add(this.powerProgressBar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rangeProgressBar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 201);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gracz 1";
            // 
            // player1ClassesPanel
            // 
            this.player1ClassesPanel.AutoScroll = true;
            this.player1ClassesPanel.Location = new System.Drawing.Point(6, 19);
            this.player1ClassesPanel.Name = "player1ClassesPanel";
            this.player1ClassesPanel.Size = new System.Drawing.Size(414, 169);
            this.player1ClassesPanel.TabIndex = 26;
            this.player1ClassesPanel.WrapContents = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Iloœæ min";
            // 
            // numberOfMineProgressBar
            // 
            this.numberOfMineProgressBar.Location = new System.Drawing.Point(516, 134);
            this.numberOfMineProgressBar.Name = "numberOfMineProgressBar";
            this.numberOfMineProgressBar.Size = new System.Drawing.Size(100, 23);
            this.numberOfMineProgressBar.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(477, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "¯ycie";
            // 
            // healthProgressBar
            // 
            this.healthProgressBar.Location = new System.Drawing.Point(516, 105);
            this.healthProgressBar.Name = "healthProgressBar";
            this.healthProgressBar.Size = new System.Drawing.Size(100, 23);
            this.healthProgressBar.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Zasiêg bomby";
            // 
            // speedProgressBar
            // 
            this.speedProgressBar.Location = new System.Drawing.Point(516, 19);
            this.speedProgressBar.Maximum = 10;
            this.speedProgressBar.Name = "speedProgressBar";
            this.speedProgressBar.Size = new System.Drawing.Size(100, 23);
            this.speedProgressBar.Step = 1;
            this.speedProgressBar.TabIndex = 16;
            // 
            // powerProgressBar
            // 
            this.powerProgressBar.Location = new System.Drawing.Point(516, 47);
            this.powerProgressBar.Name = "powerProgressBar";
            this.powerProgressBar.Size = new System.Drawing.Size(100, 23);
            this.powerProgressBar.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(448, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Moc bomby";
            // 
            // rangeProgressBar
            // 
            this.rangeProgressBar.Location = new System.Drawing.Point(516, 76);
            this.rangeProgressBar.Name = "rangeProgressBar";
            this.rangeProgressBar.Size = new System.Drawing.Size(100, 23);
            this.rangeProgressBar.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(457, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Szybkoœæ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(515, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Dalej";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 445);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Powrót";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.player2ClassesPanel);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numberOfMineProgressBar2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.healthProgressBar2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.speedProgressBar2);
            this.groupBox2.Controls.Add(this.powerProgressBar2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.rangeProgressBar2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(629, 201);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gracz 2";
            // 
            // player2ClassesPanel
            // 
            this.player2ClassesPanel.AutoScroll = true;
            this.player2ClassesPanel.Location = new System.Drawing.Point(6, 19);
            this.player2ClassesPanel.Name = "player2ClassesPanel";
            this.player2ClassesPanel.Size = new System.Drawing.Size(414, 166);
            this.player2ClassesPanel.TabIndex = 27;
            this.player2ClassesPanel.WrapContents = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(462, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Iloœæ min";
            // 
            // numberOfMineProgressBar2
            // 
            this.numberOfMineProgressBar2.Location = new System.Drawing.Point(516, 134);
            this.numberOfMineProgressBar2.Name = "numberOfMineProgressBar2";
            this.numberOfMineProgressBar2.Size = new System.Drawing.Size(100, 23);
            this.numberOfMineProgressBar2.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(477, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "¯ycie";
            // 
            // healthProgressBar2
            // 
            this.healthProgressBar2.Location = new System.Drawing.Point(516, 105);
            this.healthProgressBar2.Name = "healthProgressBar2";
            this.healthProgressBar2.Size = new System.Drawing.Size(100, 23);
            this.healthProgressBar2.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(437, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Zasiêg bomby";
            // 
            // speedProgressBar2
            // 
            this.speedProgressBar2.Location = new System.Drawing.Point(516, 19);
            this.speedProgressBar2.Name = "speedProgressBar2";
            this.speedProgressBar2.Size = new System.Drawing.Size(100, 23);
            this.speedProgressBar2.TabIndex = 16;
            // 
            // powerProgressBar2
            // 
            this.powerProgressBar2.Location = new System.Drawing.Point(516, 47);
            this.powerProgressBar2.Name = "powerProgressBar2";
            this.powerProgressBar2.Size = new System.Drawing.Size(100, 23);
            this.powerProgressBar2.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(448, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Moc bomby";
            // 
            // rangeProgressBar2
            // 
            this.rangeProgressBar2.Location = new System.Drawing.Point(516, 76);
            this.rangeProgressBar2.Name = "rangeProgressBar2";
            this.rangeProgressBar2.Size = new System.Drawing.Size(100, 23);
            this.rangeProgressBar2.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(457, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Szybkoœæ";
            // 
            // SelectPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 480);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SelectPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wybierz postaæ";
            this.Load += new System.EventHandler(this.SelectPlayerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar rangeProgressBar;
        private System.Windows.Forms.ProgressBar powerProgressBar;
        private System.Windows.Forms.ProgressBar speedProgressBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar numberOfMineProgressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar healthProgressBar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ProgressBar numberOfMineProgressBar2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar healthProgressBar2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar speedProgressBar2;
        private System.Windows.Forms.ProgressBar powerProgressBar2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar rangeProgressBar2;
        private System.Windows.Forms.Label label12;
        private FlowLayoutPanel player1ClassesPanel;
        private FlowLayoutPanel player2ClassesPanel;
    }
}
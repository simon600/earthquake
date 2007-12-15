using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheEarthQuake.GUI
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy chcesz opuœciæ grê The Earth Quake?", "The Earh Quake", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            GameOptionsForm window = new GameOptionsForm();
            window.ShowDialog();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            SelectPlayerForm window = new SelectPlayerForm();
            window.ShowDialog();
        }
    }
}
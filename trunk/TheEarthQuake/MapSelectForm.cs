using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheEarthQuake.GUI
{
    public partial class MapSelectForm : Form
    {
        public MapSelectForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Visible = false;

            SelectPlayerForm window = new SelectPlayerForm();
            window.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Visible = false;
            GameForm gameForm = new GameForm();
            gameForm.ShowDialog();
        }
    }
}
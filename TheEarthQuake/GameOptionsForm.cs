using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheEarthQuake.GUI
{
    public partial class GameOptionsForm : Form
    {
        public GameOptionsForm()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

       
      

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            this.textBox4.Text = e.KeyCode.ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            this.textBox1.Text = e.KeyCode.ToString();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            this.textBox3.Text = e.KeyCode.ToString();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            this.textBox2.Text = e.KeyCode.ToString();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            this.textBox5.Text = e.KeyCode.ToString();
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            this.textBox6.Text = e.KeyCode.ToString();
        }
    }
}
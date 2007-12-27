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

        /* This method handles key pressed event. */
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            { 
                /* quit application */
                case Keys.Escape:
                case Keys.Q:
                    Application.Exit();
                    return true;

                /* invoke options */
                case Keys.O: 
                    this.OptionButton.Focus();
                    this.OptionButton_Click(this, null);
                    return true;

                /* invoke new game */
                case Keys.N:
                    this.startButton.Focus();
                    this.startButton_Click(this, null);
                    return true;

                /* invoke exit */
                case Keys.E:
                    this.exitButton.Focus();
                    this.exitButton_Click(this, null);
                    return true;

                /* invoke the form that is focused */
                case Keys.Enter:
                case Keys.Right:
                    if (this.startButton.Focused)
                    {
                        this.startButton_Click(this, null);
                        return true;
                    }
                    if (this.OptionButton.Focused)
                    {
                        this.OptionButton_Click(this, null);
                        return true;
                    }
                    if (this.exitButton.Focused)
                    {
                        this.exitButton_Click(this, null);
                        return true;
                    }
                    return false;
                    
                /* let the base class handle the key */
                default:
                    return base.ProcessDialogKey(keyData);

            }
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
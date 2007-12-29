using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TheEarthQuake.Logic;

/*
 * TODO:
 *   -> w polach tekstowych "gora, dol, etc, etc" 
 *      powinny pojawiac sie klawisze przypisane do gracza,
 *      a nie klawisze wciskane na klawiaturze.
 *   -> pola tekstowe nie powinny przechwytywac focusu.
 */

namespace TheEarthQuake.GUI
{
    public partial class GameOptionsForm : Form
    {
        GameOptionsFormControllerWrapper controllerWrapper;
        
        public GameOptionsForm(GameOptionsFormControllerWrapper controllerWrapper)
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 0;

            this.controllerWrapper = controllerWrapper;
        }

        /* method for handling key pressed events */
        protected override bool ProcessDialogKey(Keys keyData)
        {
            /*
             * Keys:
             *   Space - check/unchech checkboxes, if focused
             *   Esc, Left - exit (invoke button1 action)
             *   Enter, Right - proceed (invoke button2 action)
             */
            
            switch (keyData)
            { 
                /* check/uncheck checkbox, if focused */
                case Keys.Space:
                    if (this.checkBox1.Focused)
                    {
                        this.checkBox1.Checked = !this.checkBox1.Checked;
                        return true;
                    }

                    if (this.checkBox2.Focused)
                    {
                        this.checkBox2.Checked = !this.checkBox2.Checked;
                        return true;
                    }

                    goto default; 
         
                /* apply settings */
                case Keys.Enter:
                case Keys.Right:
                    this.button2.Focus();
                    this.button2_Click(this, null);
                    return true;

                /* return without applying */
                case Keys.Left:
                case Keys.Escape:
                    this.button1.Focus();
                    this.button1_Click(this, null);
                    return true;

                /* let the base class handle the key event */
                default:
                    return base.ProcessDialogKey(keyData);
            }            
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
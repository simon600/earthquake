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
 *  wypelnienie metod. 
 */

namespace TheEarthQuake.GUI
{
    public partial class SelectPlayerForm : Form
    {
        SelectPlayerFormControllerWrapper controllerWrapper;

        public SelectPlayerForm(SelectPlayerFormControllerWrapper controllerWrapper)
        {
            InitializeComponent();
            this.controllerWrapper = controllerWrapper;
        }

        /* This method handles key pressed event. */
        protected override bool ProcessDialogKey(Keys keyData)
        {
            /*
             * Keys:
             *   1  - check radio button 1
             *   2  - check radio button 2
             *   3  - check radio button 3
             *  Alt+1 - check radiobutton 4
             *  Alt+2 - check radiobutton 5
             *  Alt+3 - check radiobutton 6
             * 
             *  Esc, Left - exit form (button1 action)
             *  Enter, Right - proceed (button2 action)
             */

            switch (keyData)
            {
                /* set first players name to first from the left */
                case Keys.D1:
                    this.radioButton1.Checked = true;
                    return true;

                /* set first players name to second from the left */
                case Keys.D2:
                    this.radioButton2.Checked = true;
                    return true;

                /* set first players name to third from the left */
                case Keys.D3:
                    this.radioButton3.Checked = true;
                    return true;

                /* set second players name to third from the left */
                case Keys.D3 | Keys.Alt:
                    this.radioButton4.Checked = true;
                    return true;

                /* set second players name to second from the left */
                case Keys.D2 | Keys.Alt:
                    this.radioButton5.Checked = true;
                    return true;

                /* set second players name to first from the left */
                case Keys.D1 | Keys.Alt:
                    this.radioButton6.Checked = true;
                    return true;

                /* exit */
                case Keys.Escape:
                case Keys.Left:
                    this.button2_Click(this, null);
                    return true;    // will it ever be called? 

                /* proceed */
                case Keys.Enter:
                case Keys.Right:
                    this.button1_Click(this, null);
                    return true;    // will this ever be invoked?

                /* let the base class handle the key */
                default:
                    return base.ProcessDialogKey(keyData);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HealtPprogressBar2_Click(object sender, EventArgs e)
        {

        }

        private void NumberOfMineProgressBar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Visible = false;
            MapSelectForm map = new MapSelectForm(this.controllerWrapper.MapSelectFormControllerWrapper);
            map.ShowDialog();
        }
    }
}
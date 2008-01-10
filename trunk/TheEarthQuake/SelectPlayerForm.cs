using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TheEarthQuake.Logic;
using TheEarthQuake.Players;

/*
 * TODO:
 *  wypelnienie metod. 
 */

namespace TheEarthQuake.GUI
{
    public partial class SelectPlayerForm : Form
    {
        private SelectPlayerFormControllerWrapper controllerWrapper;
        private PlayerClass[] P;

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
            map.Dispose();
        }

        private void SelectPlayerForm_Load(object sender, EventArgs e)
        {
            PlayerClasses PC = new PlayerClasses(@"..\..\..\Players\Config\players.xml");
            P = PC.GetAll();


            pictureBox1.Image = pictureBox4.Image =  System.Drawing.Image.FromFile(@P[0].LogoPath);
            pictureBox2.Image = pictureBox5.Image = System.Drawing.Image.FromFile(@P[1].LogoPath);
            pictureBox3.Image = pictureBox6.Image = System.Drawing.Image.FromFile(@P[2].LogoPath);

            speedProgressBar.Maximum = 3;
            speedProgressBar.Minimum = 0;
            speedProgressBar2.Maximum = 3;
            speedProgressBar2.Minimum = 0;

            powerProgressBar.Maximum = 100;
            powerProgressBar.Minimum = 0;
            powerProgressBar2.Maximum = 100;
            powerProgressBar2.Minimum = 0;

            rangeProgressBar.Maximum = 100;
            rangeProgressBar.Minimum = 0;
            rangeProgressBar2.Maximum = 100;
            rangeProgressBar2.Minimum = 0;

            healthProgressBar.Maximum = 3000;
            healthProgressBar.Minimum = 0;
            healthProgressBar2.Maximum = 3000;
            healthProgressBar2.Minimum = 0;

            numberOfMineProgressBar.Maximum = 3;
            numberOfMineProgressBar.Minimum = 0;
            numberOfMineProgressBar2.Maximum = 3;
            numberOfMineProgressBar2.Minimum = 0;

            SelectPlayer(0, false);

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            SelectPlayer(0,true);
        }

        private void SelectPlayer(int p,bool up)
        {
            if (up)
            {
                speedProgressBar.Value = P[p].Speed;
                powerProgressBar.Value = P[p].MinePower;
                rangeProgressBar.Value = P[p].MineRange;
                healthProgressBar.Value = P[p].MaxHealth;
                numberOfMineProgressBar.Value = P[p].SimultanousMines;
            }
            else
            {
                speedProgressBar2.Value = P[p].Speed;
                powerProgressBar2.Value = P[p].MinePower;
                rangeProgressBar2.Value = P[p].MineRange;
                healthProgressBar2.Value = P[p].MaxHealth;
                numberOfMineProgressBar2.Value = P[p].SimultanousMines;
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            SelectPlayer(1, true);
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            SelectPlayer(2, true);
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            SelectPlayer(2, false);
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            SelectPlayer(0, false);
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            SelectPlayer(1, false);
        }
    }
}
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
        private PlayerClasses playerClasses;

        private Dictionary<string, CheckBox> playerOneRadioButtons = new Dictionary<string, CheckBox>();
        private Dictionary<string, CheckBox> playerTwoRadioButtons = new Dictionary<string, CheckBox>();

        private PlayerClass[] selected = new PlayerClass[2];

        public SelectPlayerForm(SelectPlayerFormControllerWrapper controllerWrapper)
        {
            InitializeComponent();
            this.controllerWrapper = controllerWrapper;
        }

        ///* This method handles key pressed event. */
        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    /*
        //     * Keys:
        //     *   1  - check radio button 1
        //     *   2  - check radio button 2
        //     *   3  - check radio button 3
        //     *  Alt+1 - check radiobutton 4
        //     *  Alt+2 - check radiobutton 5
        //     *  Alt+3 - check radiobutton 6
        //     * 
        //     *  Esc, Left - exit form (button1 action)
        //     *  Enter, Right - proceed (button2 action)
        //     */

        //    switch (keyData)
        //    {
        //        /* set first players name to first from the left */
        //        case Keys.D1:
        //            this.radioButton1.Checked = true;
        //            return true;

        //        /* set first players name to second from the left */
        //        case Keys.D2:
        //            this.radioButton2.Checked = true;
        //            return true;

        //        /* set first players name to third from the left */
        //        case Keys.D3:
        //            this.radioButton3.Checked = true;
        //            return true;

        //        /* set second players name to third from the left */
        //        case Keys.D3 | Keys.Alt:
        //            this.radioButton4.Checked = true;
        //            return true;

        //        /* set second players name to second from the left */
        //        case Keys.D2 | Keys.Alt:
        //            this.radioButton5.Checked = true;
        //            return true;

        //        /* set second players name to first from the left */
        //        case Keys.D1 | Keys.Alt:
        //            this.radioButton6.Checked = true;
        //            return true;

        //        /* exit */
        //        case Keys.Escape:
        //        case Keys.Left:
        //            this.button2_Click(this, null);
        //            return true;    // will it ever be called? 

        //        /* proceed */
        //        case Keys.Enter:
        //        case Keys.Right:
        //            this.button1_Click(this, null);
        //            return true;    // will this ever be invoked?

        //        /* let the base class handle the key */
        //        default:
        //            return base.ProcessDialogKey(keyData);
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            playerClasses = new PlayerClasses(@"..\..\..\Players\Config\players.xml");

            bool tmp = true;

            foreach (PlayerClass playerClass in playerClasses.GetAll())
            {

                Panel panel = new Panel();
                panel.Top = 0;
                panel.Width = 120;
                panel.Height = 130;
                panel.BorderStyle = BorderStyle.FixedSingle;
          

                PictureBox logo = new PictureBox();
                logo.Image = System.Drawing.Image.FromFile(@playerClass.LogoPath);
                logo.Width = 100;
                logo.Height = 100;
                logo.Top = 0;
                logo.Left = 9;
                logo.SizeMode = PictureBoxSizeMode.StretchImage;
                panel.Controls.Add(logo);


                CheckBox radio = new CheckBox();
                radio.Top = 100;
                radio.Left = 10;
                radio.Text = playerClass.Name;


                radio.Click += new EventHandler(radio_Click);


                panel.Controls.Add(radio);
                
                playerOneRadioButtons[playerClass.Name] = radio;
                player1ClassesPanel.Controls.Add(panel);                
            }


            tmp = true;
            foreach (PlayerClass playerClass in playerClasses.GetAll()) 
            {
                Panel panel = new Panel();
                panel.Top = 0;
                panel.Width = 120;
                panel.Height = 130;
                panel.BorderStyle = BorderStyle.FixedSingle;

                PictureBox logo = new PictureBox();
                logo.Width = 100;
                logo.Height = 100;
                logo.SizeMode = PictureBoxSizeMode.StretchImage;
                logo.Image = System.Drawing.Image.FromFile(@playerClass.LogoPath);
                panel.Controls.Add(logo);


                CheckBox radio = new CheckBox();
                radio.Top = 100;
                radio.Left = 10;
                radio.Text = playerClass.Name;
                radio.Click += new EventHandler(radio_Click2);
   

                panel.Controls.Add(radio);

              
           
                playerTwoRadioButtons[playerClass.Name] = radio;
                player2ClassesPanel.Controls.Add(panel);
            }

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


            playerOneRadioButtons[playerClasses.GetAll()[0].Name].Checked = true;
            playerTwoRadioButtons[playerClasses.GetAll()[0].Name].Checked = true;


            Bind(0, playerClasses.GetAll()[0].Name);
            Bind(1, playerClasses.GetAll()[0].Name);

        }

        void Bind(int i, string name)
        {
            selected[i] = playerClasses.GetPlayerClass(name);


            if (i == 0)
            {
                speedProgressBar.Value = selected[0].Speed;
                powerProgressBar.Value = selected[0].MinePower;
                rangeProgressBar.Value = selected[0].MineRange;
                healthProgressBar.Value = selected[0].MaxHealth;
                numberOfMineProgressBar.Value = selected[0].SimultanousMines;
            }

            if (i == 1)
            {
                speedProgressBar2.Value = selected[1].Speed;
                powerProgressBar2.Value = selected[1].MinePower;
                rangeProgressBar2.Value = selected[1].MineRange;
                healthProgressBar2.Value = selected[1].MaxHealth;
                numberOfMineProgressBar2.Value = selected[1].SimultanousMines;
            }


        }

        void radio_Click2(object sender, EventArgs e)
        {
            string tmp = "";
            foreach (KeyValuePair<string, CheckBox> buttonX in playerTwoRadioButtons)
            {

                if (buttonX.Value == (CheckBox)sender)
                {
                    buttonX.Value.Checked = true;
                    tmp = buttonX.Key;
                }
                else
                {
                    buttonX.Value.Checked = false;
                }
            }

            Bind(1, tmp);
        }






        void radio_Click(object sender, EventArgs e)
        {
            string tmp = "";
            foreach (KeyValuePair<string, CheckBox> buttonX in playerOneRadioButtons)
            {

                if (buttonX.Value == (CheckBox)sender)
                {
                    buttonX.Value.Checked = true;
                }
                else
                {
                    buttonX.Value.Checked = false;
                    tmp = buttonX.Key;
                }
            }

            Bind(0, tmp);
        }


    }
}
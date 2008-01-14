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
 * Author: Marcin Golebiowski
 */

namespace TheEarthQuake.GUI
{
    public partial class GameOptionsForm : Form
    {
        GameOptionsFormControllerWrapper controller;

        public GameOptionsForm(GameOptionsFormControllerWrapper controller)
        {
            InitializeComponent();
            this.controller = controller;

            FillBasicOptions();
            this.cbxPlayer.SelectedIndex = 0;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// Fill controls with values from GameSettings in Controller
        /// </summary>
        public void FillBasicOptions()
        {
            numMusic.Value = controller.GameSettings.MusicVolume;
            numSound.Value = controller.GameSettings.SoundVolume;
            numSpeed.Value = controller.GameSettings.GameSpeed;

            cbxBonusesOn.Checked = controller.GameSettings.BonusesOn;
        }

        public void FillControllKeys(TheEarthQuake.Logic.Players player)
        {
            if (player == TheEarthQuake.Logic.Players.Player1)
            {
                tbxTop.Text = controller.GameSettings.PlayerOneKeys.Up.ToString();
                tbxDown.Text = controller.GameSettings.PlayerOneKeys.Down.ToString();
                tbxLeft.Text = controller.GameSettings.PlayerOneKeys.Left.ToString();
                tbxRight.Text = controller.GameSettings.PlayerOneKeys.Right.ToString();
                tbxBomb.Text = controller.GameSettings.PlayerOneKeys.Bomb.ToString();
                tbxSpecial.Text = controller.GameSettings.PlayerOneKeys.Special.ToString(); 
            }

            if (player == TheEarthQuake.Logic.Players.Player2)
            {
                tbxTop.Text = controller.GameSettings.PlayerTwoKeys.Up.ToString();
                tbxDown.Text = controller.GameSettings.PlayerTwoKeys.Down.ToString();
                tbxLeft.Text = controller.GameSettings.PlayerTwoKeys.Left.ToString();
                tbxRight.Text = controller.GameSettings.PlayerTwoKeys.Right.ToString();
                tbxBomb.Text = controller.GameSettings.PlayerTwoKeys.Bomb.ToString();
                tbxSpecial.Text = controller.GameSettings.PlayerTwoKeys.Special.ToString();
            }
        }
        
        private void cbxBonusesOn_Click(object sender, EventArgs e)
        {
            controller.GameSettings.BonusesOn = cbxBonusesOn.Checked;
        }

        private void numSpeed_ValueChanged(object sender, EventArgs e)
        {
            controller.GameSettings.GameSpeed = (int)numSpeed.Value;
        }

        private void numSound_ValueChanged(object sender, EventArgs e)
        {
            controller.GameSettings.SoundVolume = (int)numSound.Value;
        }

        private void numMusic_ValueChanged(object sender, EventArgs e)
        {
            controller.GameSettings.MusicVolume = (int)numMusic.Value;
        }

        private void cbxPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPlayer.SelectedItem != null)
            {
                if (cbxPlayer.SelectedIndex == 0)
                {
                    FillControllKeys(TheEarthQuake.Logic.Players.Player1);
                }

                if (cbxPlayer.SelectedIndex == 1)
                {
                    FillControllKeys(TheEarthQuake.Logic.Players.Player2);
                }
            }
        }

        private void tbxTop_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbxPlayer.SelectedIndex == 0)
            {
                controller.GameSettings.PlayerOneKeys.Up = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player1);
            }
            else
            {
                controller.GameSettings.PlayerTwoKeys.Up = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player2);
            }
        }

        private void tbxDown_KeyDown(object sender, KeyEventArgs e)
    {
            if (cbxPlayer.SelectedIndex == 0)
            {
                controller.GameSettings.PlayerOneKeys.Down = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player1);
            }
            else
            {
                controller.GameSettings.PlayerTwoKeys.Down = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player2);
            }
        }

        private void tbxRight_TextChanged(object sender, KeyEventArgs e)
        {
            if (cbxPlayer.SelectedIndex == 0)
            {
                controller.GameSettings.PlayerOneKeys.Right = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player1);
            }
            else
            {
                controller.GameSettings.PlayerTwoKeys.Right = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player2);
            }     
        }

        private void tbxLeft_TextChanged(object sender, KeyEventArgs e)
        {
            if (cbxPlayer.SelectedIndex == 0)
            {
                controller.GameSettings.PlayerOneKeys.Left = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player1);
            }
            else
            {
                controller.GameSettings.PlayerTwoKeys.Left = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player2);
            }
        }

        private void tbxBomb_TextChanged(object sender, KeyEventArgs e)
        {
            if (cbxPlayer.SelectedIndex == 0)
            {
                controller.GameSettings.PlayerOneKeys.Bomb = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player1);
            }
            else
            {
                controller.GameSettings.PlayerTwoKeys.Bomb = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player2);
            }
        }

        private void tbxSpecial_TextChanged(object sender, KeyEventArgs e)
        {
            if (cbxPlayer.SelectedIndex == 0)
            {
                controller.GameSettings.PlayerOneKeys.Special = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player1);
            }
            else
            {
                controller.GameSettings.PlayerTwoKeys.Special = e.KeyCode;
                FillControllKeys(TheEarthQuake.Logic.Players.Player2);
            }
        }

        private void GameOptionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.GameSettings.UpdateXML();
        }

        ///* method for handling key pressed events */
        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    /*
        //     * Keys:
        //     *   Space - check/unchech checkboxes, if focused
        //     *   Esc, Left - exit (invoke button1 action)
        //     *   Enter, Right - proceed (invoke button2 action)
        //     */
            
        //    switch (keyData)
        //    { 
        //        /* check/uncheck checkbox, if focused */
        //        case Keys.Space:
        //            if (this.checkBox2.Focused)
        //            {
        //                this.checkBox2.Checked = !this.checkBox2.Checked;
        //                return true;
        //            }
        //            goto default; 
         
        //        /* apply settings */
        //        case Keys.Enter:
        //        case Keys.Right:
        //            this.button2.Focus();
        //            this.button2_Click(this, null);
        //            return true;

        //        /* return without applying */
        //        case Keys.Left:
        //        case Keys.Escape:
        //            this.button1.Focus();
        //            this.button1_Click(this, null);
        //            return true;

        //        /* let the base class handle the key event */
        //        default:
        //            return base.ProcessDialogKey(keyData);
        //    }            
        //}

    }
}
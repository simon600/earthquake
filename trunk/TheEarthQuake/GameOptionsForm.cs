using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TheEarthQuake.Logic;

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
            Bind();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// Fill controls with values from GameSettings in Controller
        /// </summary>
        public void Bind()
        {
            numMusic.Value = controller.GameSettings.MusicVolume;
            numSound.Value = controller.GameSettings.SoundVolume;
            numSpeed.Value = controller.GameSettings.GameSpeed;

            cbxBonusesOn.Checked = controller.GameSettings.BonusesOn;
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

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            
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
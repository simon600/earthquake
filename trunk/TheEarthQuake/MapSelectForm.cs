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
 *    -> nazwac sensownie klawisze!
 *    -> dorobic wczytywanie i zapisywanie mapy
 *    -> dorobic ladowanie mapy
 */

namespace TheEarthQuake.GUI
{
    public partial class MapSelectForm : Form
    {
        MapSelectFormControllerWrapper controllerWrapper;
        Engine.Engine engine;

        public MapSelectForm(MapSelectFormControllerWrapper controllerWrapper)
        {
            InitializeComponent();
            this.controllerWrapper = controllerWrapper;

            engine = this.controllerWrapper.GraphicsEngine;
            engine.Preview = true;
            engine.Width = 250;
            engine.Height = 250;
            engine.Location = new System.Drawing.Point(285, 37);
            engine.Parent = this;
        }

        /* This method handles key pressed event. */
        protected override bool ProcessDialogKey(Keys keyData)
        {
            /*
             * Keys:
             *  L - generate map
             *  Esc, Left - invoke button2 action
             *  Enter, Right - invoke button1 action
             */
            
            switch (keyData)
            {
                /* generate map */
                case Keys.L:
                    // invoke generate map button_click 
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Visible = false;

            SelectPlayerForm window = 
                new SelectPlayerForm(
                    this.controllerWrapper.selectPlayerFormControllerWrapper);
            window.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Visible = false;
            GameForm gameForm = 
                new GameForm(
                    this.controllerWrapper.gameFormControllerWrapper);
            
            gameForm.ShowDialog();
            gameForm.Dispose(); // releases all the components in gameForm
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //creates new map in state machine, and sets new wrapper in graphics engine
            this.controllerWrapper.StateMachine.GenerateMap();
            this.controllerWrapper.GraphicsEngine.SetMapWrapper(this.controllerWrapper.StateMachine.GetMapWrapper());
            //refresh preview
            this.engine.Refresh();
        }
    }
}
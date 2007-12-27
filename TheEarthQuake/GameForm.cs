using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
    TODO: napisac obsluge klawiszy. (Karol)
 */

namespace TheEarthQuake.GUI
{
    public partial class GameForm : Form
    {
        private Engine.Engine engine;
        private Logic.StateMachine stateMachine;

        /* method for handling key pressed events */
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
               


                default:
                    return base.ProcessDialogKey(keyData);
            }
        }


        public GameForm()
        {
            InitializeComponent();

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Name = "EarthQuake";
            this.Text = "EarthQuake";

            this.engine = new Engine.Engine();
            this.engine.Parent = this;
            this.stateMachine = new Logic.StateMachine();
            Maps.MapWrapper mapwr = new Maps.MapWrapper(stateMachine.Map);
            this.engine.SetWrapper(mapwr);
            this.engine.Dock = DockStyle.Fill;
        }
    }
}
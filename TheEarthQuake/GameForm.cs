using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TheEarthQuake.GUI
{
    public partial class GameForm : Form
    {
        private Engine.Engine engine;

        public GameForm()
        {
            InitializeComponent();

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Name = "EarthQuake";
            this.Text = "EarthQuake";
            this.engine = new Engine.Engine(new Logic.StateMachine());
            this.engine.Parent = this;
            this.engine.Dock = DockStyle.Fill;
        }
    }
}
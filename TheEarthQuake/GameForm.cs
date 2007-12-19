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
        private Logic.StateMachine stateMachine;

        public GameForm()
        {
            InitializeComponent();

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Name = "EarthQuake";
            this.Text = "EarthQuake";


            // Something doesn't work correctly: don't know why, but
            // engine constructor can't find files to load textures
            // Of course it used to work two days ago with the 
            // same piece of code (I checked it - see revision 24 at svn).
            // Wtf?
            this.engine = new Engine.Engine();
            this.engine.Parent = this;
            this.stateMachine = new Logic.StateMachine();
            Maps.MapWrapper mapwr = new Maps.MapWrapper(stateMachine.Map);
            this.engine.SetWrapper(mapwr);
            this.engine.Dock = DockStyle.Fill;
        }
    }
}
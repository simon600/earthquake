using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TheEarthQuake.Logic;
using TheEarthQuake.Maps;
using TheEarthQuake.Players;
using System.Runtime.InteropServices;

namespace TheEarthQuake.GUI
{
    /// <summary>
    /// Form for displaying game.
    /// </summary>
    public partial class GameForm : Form
    {
        private Engine.Engine engine;
        private Logic.StateMachine stateMachine;
        private Thread thrOpenGL;   //thread needed to display scene and modify the state

        private GameFormControllerWrapper controllerWrapper;
        private bool isActive;

        /// <summary>
        /// Game form constructor
        /// </summary>
        /// <param name="controllerWrapper"></param>
        public GameForm(GameFormControllerWrapper controllerWrapper)
        {
            InitializeComponent();
            this.isActive = true;
            // Next line is needed to avoid some faults with thread
            // (delete it to check what happens). If you know better
            // solution feel free to modify code :).
            CheckForIllegalCrossThreadCalls = false;
            this.controllerWrapper = controllerWrapper;

            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Name = "EarthQuake";
            this.Text = "EarthQuake";

            this.engine = this.controllerWrapper.GraphicsEngine;
            this.stateMachine = this.controllerWrapper.StateMachine;

            //sets engine control in whole form
            this.engine.Preview = false;
            this.engine.Parent = this;
            this.engine.Dock = DockStyle.Fill;

            //sets some wrappers in engine
            Maps.MapWrapper mapwr = this.stateMachine.GetMapWrapper();
            this.engine.SetMapWrapper(mapwr);
            PlayerWrapper p1 = this.stateMachine.GetPlayerOneWrapper();
            PlayerWrapper p2 = this.stateMachine.GetPlayerTwoWrapper();
            this.engine.SetPlayersWrapper(p1, p2);

            //starts redrawing thread
            this.thrOpenGL = new Thread(new ThreadStart(Tick));
            this.thrOpenGL.Start();
        }

        /* importing the GetKeyboardState function */
        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true, CallingConvention=CallingConvention.Winapi)]
		public static extern short GetKeyState(int keyCode);

        /// <summary>
        /// Checking, if wheter given key is pressed or not */
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private bool IsKeyPressed(Keys key)
        {
            const ushort keyDownBit = 0x80;
            return ((GetKeyState((short)key) & keyDownBit) == keyDownBit);
        }

        /// <summary>
        /// Sets false to isActive when form is deactivated
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.isActive = false;
        }

        /// <summary>
        /// Sets true to isActive when form is activated.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.isActive = true;
        }

        /// <summary>
        /// Checking the keyboard state for pressed keys
        /// </summary>
        private void ProcessKeyboard()
        {
            // checking state of keys for PlayerOne actions

            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerOneKeys.Up))
            {
                controllerWrapper.MovePlayer1Up();
            }
            
            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerOneKeys.Down))
            {
                controllerWrapper.MovePlayer1Down();
            }

            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerOneKeys.Left))
            {
                controllerWrapper.MovePlayer1Left();
            }

            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerOneKeys.Right))
            {
                controllerWrapper.MovePlayer1Right();
            }

            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerOneKeys.Bomb))
            {
                controllerWrapper.Player1SetUpBomb();
            }

            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerOneKeys.Special))
            {
                controllerWrapper.Player1Special();
            }


            // checking state of keys for PlayerTwo actions

            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerTwoKeys.Up))
            {
                controllerWrapper.MovePlayer2Up();
            }

            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerTwoKeys.Down))
            {
                controllerWrapper.MovePlayer2Down();
            }

            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerTwoKeys.Left))
            {
                controllerWrapper.MovePlayer2Left();
            }

            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerTwoKeys.Right))
            {
                controllerWrapper.MovePlayer2Right();
            }

            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerTwoKeys.Special))
            {
                controllerWrapper.Player2Special();
            }

            if (this.IsKeyPressed(controllerWrapper.StateMachine.CurrentGameSettings.PlayerTwoKeys.Bomb))
            {
                controllerWrapper.Player2SetUpBomb();
            }

            // form control keys 

            if (this.IsKeyPressed(Keys.Escape))
            {
                this.Close();               // is it ok?
            }
        }

        /// <summary>
        /// Use to redraw scene, and allow things to live their lives :) (eg. bomb explode)
        /// </summary>
        private void Tick()
        {
            DateTime time = DateTime.Now; // used to count fps
            DateTime tempTime; // used to count fps
            TimeSpan timeDifference; // used to count fps


            //it should depend of the fps (because loop speed is depend of machine speed)

            while(true) // infinity loop for rendering
            { 
                if(this.isActive)
                    this.ProcessKeyboard();
                this.engine.Refresh();

                /* counting fps */
                tempTime = DateTime.Now;
                timeDifference = (tempTime - time);
                stateMachine.CurrentFPS = 1000.0f / timeDifference.Milliseconds;
                time = tempTime;
                controllerWrapper.Tick();
            }
        }
    }
}
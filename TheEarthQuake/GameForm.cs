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
    public partial class GameForm : Form
    {
        private Engine.Engine engine;
        private Logic.StateMachine stateMachine;
        private Thread thrOpenGL;   //thread needed to display scene and modify the state

        GameFormControllerWrapper controllerWrapper;

        public GameForm(GameFormControllerWrapper controllerWrapper)
        {
            InitializeComponent();
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

        /* checking, if wheter given key is pressed or not */
        private bool IsKeyPressed(Keys key)
        {
            const ushort keyDownBit = 0x80;
            return ((GetKeyState((short)key) & keyDownBit) == keyDownBit);
        }

        /* checking the keyboard state for pressed keys */
        private void ProcessKeyboard()
        {
            /* Keys:
             *   WSAD - player 1 move up, down, left, right
             *   E - player 1 special key
             *   X - player 1 set up bomb
             * 
             *   IKJL - player 2 move up, down, left, right
             *   U - player 2 special key
             *   N - player 2 set up bomb
             * 
             *   Esc - exit form
             */

            if (this.IsKeyPressed(Keys.W))
            {
                controllerWrapper.MovePlayer1Up();
            }
            
            if (this.IsKeyPressed(Keys.S))
            {
                controllerWrapper.MovePlayer1Down();
            }

            if (this.IsKeyPressed(Keys.A))
            {
                controllerWrapper.MovePlayer1Left();
            }

            if (this.IsKeyPressed(Keys.D))
            {
                controllerWrapper.MovePlayer1Right();
            }

            if (this.IsKeyPressed(Keys.X))
            {
                controllerWrapper.Player1SetUpBomb();
            }

            if (this.IsKeyPressed(Keys.E))
            {
                controllerWrapper.Player1Special();
            }

            if (this.IsKeyPressed(Keys.I))
            {
                controllerWrapper.MovePlayer2Up();
            }

            if (this.IsKeyPressed(Keys.K))
            {
                controllerWrapper.MovePlayer2Down();
            }

            if (this.IsKeyPressed(Keys.J))
            {
                controllerWrapper.MovePlayer2Left();
            }

            if (this.IsKeyPressed(Keys.L))
            {
                controllerWrapper.MovePlayer2Right();
            }

            if (this.IsKeyPressed(Keys.U))
            {
                controllerWrapper.Player2Special();
            }

            if (this.IsKeyPressed(Keys.M))
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
            //it should depend of the fps (because loop speed is depend of machine speed)

            while(true) // infinity loop for rendering
            {
                this.ProcessKeyboard();
                this.engine.Refresh();
            }
        }
    }
}
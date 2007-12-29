using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TheEarthQuake.Logic;

/*
 *  TODO: prawdopodobnie taki sposob obslugi klawiszy spowoduje, ze 
 *        wystapia konflikty na klawiaturze. 
 * 
 *        Rozwiazanie 1: zaimplementowanie hashtablicy z klawiszami
 *                       i modyfikowanie jej wg zdarzen onkeydown, onkeyup
 * 
 *        Rozwiazanie 2: GetKeyboardState (ojoj, to chyba w C++). Patrz msdn.
 */

namespace TheEarthQuake.GUI
{
    public partial class GameForm : Form
    {
        private Engine.Engine engine;
        private Logic.StateMachine stateMachine;
        private Thread thrOpenGL;   //watek dla wyswietlania i dla podejmowanych akcji

        GameFormControllerWrapper controllerWrapper;

        public GameForm(GameFormControllerWrapper controllerWrapper)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.controllerWrapper = controllerWrapper;

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

            this.thrOpenGL = new Thread(new ThreadStart(OpenGL_Start));
            this.thrOpenGL.Start();
        }
                
        /* method for handling key pressed events */
        protected override bool ProcessDialogKey(Keys keyData)
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
            
            switch (keyData)
            {
                /* player control keys */

                case Keys.W:
                    controllerWrapper.MovePlayer1Up();
                    return true;

                case Keys.S:
                    controllerWrapper.MovePlayer1Down();
                    return true;

                case Keys.A:
                    controllerWrapper.MovePlayer1Left();
                    return true;

                case Keys.D:
                    controllerWrapper.MovePlayer1Right();
                    return true;
                
                case Keys.E:
                    controllerWrapper.Player1SetUpBomb();
                    return true;

                case Keys.X:
                    controllerWrapper.Player1SetUpBomb();
                    return true;

                case Keys.I:
                    controllerWrapper.MovePlayer2Up();
                    return true;

                case Keys.K:
                    controllerWrapper.MovePlayer2Down();
                    return true;

                case Keys.J:
                    controllerWrapper.MovePlayer2Left();
                    return true;

                case Keys.L:
                    controllerWrapper.MovePlayer2Right();
                    return true;

                case Keys.U:
                    controllerWrapper.Player2Special();
                    return true;

                case Keys.M:
                    controllerWrapper.Player2SetUpBomb();
                    return true;

                /* form control keys */

                case Keys.Escape:
                    this.Close();               // is it ok?
                    return true;

                default:
                    return base.ProcessDialogKey(keyData);
            }
        }
        

        private void OpenGL_Start()
        {
            //to powinno jeszcze wywolywac jakies tiki itd...

            while(true) // infinity loop for rendering
            {
                this.engine.Refresh();
            }
        }
    }
}
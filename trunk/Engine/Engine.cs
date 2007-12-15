using System;
using System.Drawing;
using System.Windows.Forms;
using CsGL.OpenGL;
using TheEarthQuake.Logic.Maps;
using TheEarthQuake.Logic;

namespace TheEarthQuake.Engine
{
    public class Engine : OpenGLControl
    {
        private Map map;
        private Player[] players;
        private const float width  = 1024;
        private const float height = 768;

        public Engine(Map map, Player[] players)
            : base()
        {
            this.map = map;
            this.players = players;           
        }

        public override void glDraw()
        {
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.glLoadIdentity();
            DrawBackground();
            DrawMap();
            DrawPlayers();
        }        

        protected override void InitGLContext()
        {
            GL.glShadeModel(GL.GL_SMOOTH);
            GL.glClearColor(0.0f, 1.0f, 0.0f, 0.5f);
            GL.glClearDepth(1.0f);		
            GL.glEnable(GL.GL_DEPTH_TEST);
            GL.glDepthFunc(GL.GL_LEQUAL);
            GL.glHint(GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Size s = Size;

            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.glLoadIdentity();
            GL.gluOrtho2D(-width / 2, width / 2, -height / 2, height / 2);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();
        }

        private void DrawMap()
        {            
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    //tu bêdzie rozpopznawanie obiektów i ich malowanie
                }
        }

        private void DrawPlayers()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        private void DrawBackground()
        {
            GL.glPushMatrix();
            GL.glLoadIdentity();
            GL.glColor3f(0.0f, 0.0f, 1.0f);
            GL.glBegin(GL.GL_QUADS);
                GL.glVertex2f(-width / 2, -height / 2);
                GL.glVertex2f(width / 2, -height / 2);
                GL.glVertex2f(width / 2, height / 2);
                GL.glVertex2f(-width / 2, height / 2);
            GL.glEnd();
            GL.glPopMatrix();
            //tu bêdzie rysunek
        }
    }
}

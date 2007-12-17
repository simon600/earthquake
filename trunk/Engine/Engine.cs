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
        private StateMachine stateMachine;
        private Map map;
        private float width;
        private float height;
        private CsGL.OpenGL.OpenGLTexture2D[] textures;

        public Engine(StateMachine stateMachine)
            : base()
        {
            this.stateMachine = stateMachine;
            this.map = this.stateMachine.Map;
            width = StateMachine.Width;
            height = StateMachine.Height;

            textures = new OpenGLTexture2D[4];

            textures[0] = new OpenGLTexture2D(@"Textures\\Stone.bmp");
            textures[1] = new OpenGLTexture2D(@"Textures\\Bricks.bmp");
            textures[2] = new OpenGLTexture2D(@"Textures\\Path.bmp");
            textures[3] = new OpenGLTexture2D(@"Textures\\Water.bmp");
            
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
            GL.glEnable(GL.GL_TEXTURE_2D); 
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
            GL.glPushMatrix();
            GL.glTranslatef(-width / 2, height / 2, 0.0f);
            GL.glColor3f(1.0f, 1.0f, 1.0f);

            for (int i = 0; i < Map.MapHeight; i++)
            {
                for (int j = 0; j < Map.MapWidth; j++)
                {
                    if (map.Fields[i, j] is NonPersistentWall)
                    {
                        //GL.glColor3f(0.5f, 0.5f, 0.5f);
                        textures[1].Bind();
                    }
                    else if (map.Fields[i, j] is PersistentWall)
                    {
                        //GL.glColor3f(0.0f, 0.0f, 0.0f);
                        textures[0].Bind();
                    }
                    else if (map.Fields[i, j] is Path)
                    {
                        //GL.glColor3f(1.0f, 1.0f, 0.0f);
                        textures[2].Bind();
                    }
                    else
                    {
                        //GL.glColor3f(0.0f, 0.0f, 1.0f);
                        textures[3].Bind();
                    }

                    GL.glBegin(GL.GL_QUADS);
                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex2f(j * StateMachine.FieldSize, -(i + 1) * StateMachine.FieldSize);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex2f((j + 1) * StateMachine.FieldSize, -(i + 1) * StateMachine.FieldSize);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex2f((j + 1) * StateMachine.FieldSize, -i * StateMachine.FieldSize);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex2f(j * StateMachine.FieldSize, -i * StateMachine.FieldSize);
                    GL.glEnd();
                }
            }

            GL.glPopMatrix();
        }

        private void DrawPlayers()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        private void DrawBackground()
        {
            GL.glPushMatrix();
            GL.glLoadIdentity();
            GL.glColor3f(0.0f, 1.0f, 0.0f);
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

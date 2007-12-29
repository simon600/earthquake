/* TODO:
 *  Wyœwietlanie graczy jak bêd¹ napisani
 *  Wyœwietlanie bomb, wybuchów i wszystkiego czego jeszcze nie ma
 *  Poprawiæ coœ z teksturami wody
 *  
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using CsGL.OpenGL;
using TheEarthQuake.Maps;

namespace TheEarthQuake.Engine
{
    /// <summary>
    /// Initializes OpenGL and draws everything that needs to be drawn
    /// in OpenGL (map, players, bombs etc.
    /// </summary>
    public class Engine : OpenGLControl
    {        
        private MapWrapper mapWrapper;  //grants access to some function and properties of Map
        private float width;    //window width
        private float height;   //window height
        private OpenGLTexture2D[] textures; //holds textures for terain
        private OpenGLTexture2D[] waterTextures;    //holds textures for wter tiles

        /// <summary>
        /// Constructor - loads textures and sets some default values
        /// </summary>
        public Engine() : base()
        {   
            mapWrapper = null;
           
            /*
             * You can change the values of width and height 
             * using setters (in StatesMachine); default values are:
             */

            width = 1024;
            height = 768;
            

            textures = new OpenGLTexture2D[3];
            waterTextures = new OpenGLTexture2D[20];
          
            textures[0] = new OpenGLTexture2D(@"Textures\\Stone.bmp");
            textures[1] = new OpenGLTexture2D(@"Textures\\Bricks.bmp");
            textures[2] = new OpenGLTexture2D(@"Textures\\Path.bmp");

            waterTextures[0]  = new OpenGLTexture2D(@"Textures\\Water.bmp");
            waterTextures[1]  = new OpenGLTexture2D(@"Textures\\Water1Left.bmp");
            waterTextures[2]  = new OpenGLTexture2D(@"Textures\\Water1Down.bmp");
            waterTextures[3]  = new OpenGLTexture2D(@"Textures\\Water1Right.bmp");
            waterTextures[4]  = new OpenGLTexture2D(@"Textures\\Water1Up.bmp");
            waterTextures[5]  = new OpenGLTexture2D(@"Textures\\Water2DownLeft.bmp");
            waterTextures[6]  = new OpenGLTexture2D(@"Textures\\Water2DownRight.bmp");
            waterTextures[7]  = new OpenGLTexture2D(@"Textures\\Water2UpLeft.bmp");
            waterTextures[8]  = new OpenGLTexture2D(@"Textures\\Water2UpRight.bmp");
            waterTextures[9]  = new OpenGLTexture2D(@"Textures\\Water2UpDown.bmp");
            waterTextures[10] = new OpenGLTexture2D(@"Textures\\Water2LeftRight.bmp");
            waterTextures[11] = new OpenGLTexture2D(@"Textures\\Water3NoLeft.bmp");
            waterTextures[12] = new OpenGLTexture2D(@"Textures\\Water3NoDown.bmp");
            waterTextures[13] = new OpenGLTexture2D(@"Textures\\Water3NoRight.bmp");
            waterTextures[14] = new OpenGLTexture2D(@"Textures\\Water3NoUp.bmp");
            waterTextures[15] = new OpenGLTexture2D(@"Textures\\Water4.bmp");
            waterTextures[16] = new OpenGLTexture2D(@"Textures\\WaterCDownLeft.bmp");
            waterTextures[17] = new OpenGLTexture2D(@"Textures\\WaterCDownRight.bmp");
            waterTextures[18] = new OpenGLTexture2D(@"Textures\\WaterCUpRight.bmp");
            waterTextures[19] = new OpenGLTexture2D(@"Textures\\WaterCUpLeft.bmp");
        }

        /// <summary>
        /// Sets window width
        /// </summary>
        public float WindowWidth
        {
            set
            {
                this.width = value;
            }
        }

        /// <summary>
        /// Sets window height
        /// </summary>
        public float WindowHeight
        {
            set
            {
                this.height = value;
            }
        }

        /// <summary>
        /// Sets map wrapper
        /// </summary>
        /// <param name="mapWrapper">Map wrapper to be set</param>
        public void SetWrapper(MapWrapper mapWrapper)
        {
            this.mapWrapper = mapWrapper;
        }

        /// <summary>
        /// This function is called every time a frame is drawn
        /// </summary>
        public override void glDraw()
        {
            GL.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.glLoadIdentity();


            DrawBackground();
            DrawMap();
            DrawPlayers();

            GL.glColor3d(0.5, 0.5, 0.5);
            GL.glBegin(GL.GL_TRIANGLES);
            GL.glVertex2d(0.0, 0.0);
            GL.glVertex2d(100.0, 0.0);
            GL.glVertex2d(0.0, 100.0);
            GL.glEnd();
        }        

        /// <summary>
        /// Initializes OpenGL
        /// </summary>
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

        /// <summary>
        /// Called when window size is changed
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        /// Draws a map
        /// </summary>
        private void DrawMap()
        {                        
            GL.glPushMatrix();
            GL.glTranslatef(-width / 2, height / 2, 0.0f);
            GL.glColor3f(1.0f, 1.0f, 1.0f);

            for (int i = 0; i < mapWrapper.MapHeight; i++)
            {
                for (int j = 0; j < mapWrapper.MapWidth; j++)
                {
                    if (mapWrapper.GetField(i, j) is NonPersistentWall)
                    {
                        textures[1].Bind();
                    }
                    else if (mapWrapper.GetField(i, j) is PersistentWall)
                    {
                        textures[0].Bind();
                    }
                    else if (mapWrapper.GetField(i, j) is Path)
                    {
                        textures[2].Bind();
                    }
                    else if (mapWrapper.GetField(i, j) is Water)
                    {
                        if (j < mapWrapper.MapWidth-1 && !(mapWrapper.GetField(i, j + 1) is Water)) //no water on right
                        {
                            if (i < mapWrapper.MapHeight-1 && !(mapWrapper.GetField(i + 1, j) is Water)) //no water down and right
                            {
                                if (j > 0 && !(mapWrapper.GetField(i, j - 1) is Water)) //no water on down, right and left
                                {
                                    if (i > 0 && !(mapWrapper.GetField(i - 1, j) is Water)) //no water around
                                    {
                                        waterTextures[15].Bind();
                                    }
                                    else //water only up
                                    {
                                        waterTextures[14].Bind();
                                    }
                                }
                                else //water left and no water down and right
                                {
                                    if (i > 0 && !(mapWrapper.GetField(i - 1, j) is Water)) //water only left
                                    {
                                        waterTextures[11].Bind();
                                    }
                                    else //water left and up and no water right and down
                                    {
                                        waterTextures[6].Bind();
                                    }
                                }
                            }
                            else //water down and no water on right
                            {
                                if (j > 0 && !(mapWrapper.GetField(i, j - 1) is Water)) //water down and no water right and left
                                {
                                    if (i > 0 && !(mapWrapper.GetField(i - 1, j) is Water)) //water only down
                                    {
                                        waterTextures[12].Bind();
                                    }
                                    else //water down and up and no water left and right
                                    {
                                        waterTextures[10].Bind();
                                    }
                                }
                                else //water down and left and no water on right
                                {
                                    if (i > 0 && !(mapWrapper.GetField(i - 1, j) is Water)) //water down and left and no water up and right
                                    {
                                        waterTextures[8].Bind();
                                    }
                                    else
                                    {
                                        waterTextures[3].Bind(); //no water only right
                                    }
                                }
                            }
                        }
                        else //water on right
                        {
                            if (i <= mapWrapper.MapHeight && !(mapWrapper.GetField(i + 1, j) is Water)) //water on right and no water down
                            {
                                if (j > 0 && !(mapWrapper.GetField(i, j - 1) is Water)) //water on right and no water down and left
                                {
                                    if (i > 0 && !(mapWrapper.GetField(i - 1, j) is Water)) //water on right only
                                    {
                                        waterTextures[13].Bind();
                                    }
                                    else //water on right and up, no water down and left
                                    {
                                        waterTextures[5].Bind();
                                    }
                                }
                                else //water on right and left and no water down
                                {
                                    if (i > 0 && !(mapWrapper.GetField(i - 1, j) is Water)) //water right and left, no water down and up
                                    {
                                        waterTextures[9].Bind(); 
                                    }
                                    else //water right, left and up and no water down
                                    {
                                        waterTextures[2].Bind();
                                    }
                                }
                            }
                            else //water right and down
                            {
                                if (j > 0 && !(mapWrapper.GetField(i, j - 1) is Water)) //water right and down and no water on left
                                {
                                    if (i > 0 && !(mapWrapper.GetField(i - 1, j) is Water)) //water right and down, no water on left and up
                                    {
                                        waterTextures[7].Bind();
                                    }
                                    else //water right, down and up and no water on left
                                    {
                                        waterTextures[1].Bind();
                                    }
                                }
                                else //water on right and down and on left
                                {
                                    if (i > 0 && !(mapWrapper.GetField(i - 1, j) is Water)) //no water only up
                                    {
                                        waterTextures[4].Bind();
                                    }
                                    else //water around
                                    {
                                        waterTextures[0].Bind();
                                    }
                                }
                            }
                        }                        
                    }

                    GL.glBegin(GL.GL_QUADS);
                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex2f(j * mapWrapper.FieldSize, -(i + 1) * mapWrapper.FieldSize);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex2f((j + 1) * mapWrapper.FieldSize, -(i + 1) * mapWrapper.FieldSize);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex2f((j + 1) * mapWrapper.FieldSize, -i * mapWrapper.FieldSize);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex2f(j * mapWrapper.FieldSize, -i * mapWrapper.FieldSize);
                    GL.glEnd();
                }
            }

            GL.glPopMatrix();
        }

        private void DrawPlayers()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Draws background
        /// </summary>
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

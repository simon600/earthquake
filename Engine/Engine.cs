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
using TheEarthQuake.Players;
using TheEarthQuake.Maps.Bomb;
using System.Collections.Generic;

namespace TheEarthQuake.Engine
{
    /// <summary>
    /// Initializes OpenGL and draws everything that needs to be drawn
    /// in OpenGL (map, players, bombs etc.)
    /// </summary>
    public class Engine : OpenGLControl
    {        
        private MapWrapper mapWrapper;          //grants access to some function and properties of Map
        private PlayerWrapper player1Wrapper;   //grants access to some properties of Players
        private PlayerWrapper player2Wrapper;   //grants access to some properties
        private float width;                    //window width
        private float height;                   //window height
        private OpenGLTexture2D[] textures;     //holds textures for terain
        private OpenGLTexture2D[] waterTextures;//holds textures for water tiles
        private OpenGLTexture2D[] bombTextures;
        private OpenGLTexture2D[] bombMasks;
        private OpenGLTexture2D[] blowTextures;
        private OpenGLTexture2D[] blowMasks;
        private OpenGLTexture2D flame;
        private OpenGLTexture2D flameMask;
        private bool preview;                   //true iff draw functions will be use to draw only map preview

        private OpenGLTexture2D playerOneTexture;
        private OpenGLTexture2D playerTwoTexture;
        private OpenGLTexture2D playerOneTextureMask;
        private OpenGLTexture2D playerTwoTextureMask;


        private int cycleIterator;  // used for iterating textures        
        private int iteratorIterator; // when it reaches certain value, other iterators iterate

        private List<Bomb> drawingBombsList; //lista bomb do narysowania;

        private static Random rand = new Random();

        /// <summary>
        /// Constructor - loads textures and sets some default values
        /// </summary>
        public Engine() : base()
        {   
            mapWrapper = null;
            player1Wrapper = null;
            player2Wrapper = null;
            this.preview = false;
            this.cycleIterator = 0;
            this.iteratorIterator = 0;
            this.drawingBombsList = new List<Bomb>();
           
            /*
             * You can change the values of width and height 
             * using setters (in StatesMachine); default values are:
             */
            width = 768;
            height = 768;
            
            // initializes textures
            textures = new OpenGLTexture2D[3];
            waterTextures = new OpenGLTexture2D[20];
            bombTextures = new OpenGLTexture2D[3];
            bombMasks = new OpenGLTexture2D[3];
            blowTextures = new OpenGLTexture2D[5];
            blowMasks = new OpenGLTexture2D[5];

            textures[0] = new OpenGLTexture2D(@"..\..\..\textures\Stone.bmp");
            textures[1] = new OpenGLTexture2D(@"..\..\..\textures\Bricks.bmp");
            textures[2] = new OpenGLTexture2D(@"..\..\..\textures\Path.bmp");

            waterTextures[0] = new OpenGLTexture2D(@"..\..\..\textures\Water.bmp");
            waterTextures[1] = new OpenGLTexture2D(@"..\..\..\textures\Water1Left.bmp");
            waterTextures[2] = new OpenGLTexture2D(@"..\..\..\textures\Water1Down.bmp");
            waterTextures[3] = new OpenGLTexture2D(@"..\..\..\textures\Water1Right.bmp");
            waterTextures[4] = new OpenGLTexture2D(@"..\..\..\textures\Water1Up.bmp");
            waterTextures[5] = new OpenGLTexture2D(@"..\..\..\textures\Water2DownLeft.bmp");
            waterTextures[6] = new OpenGLTexture2D(@"..\..\..\textures\Water2DownRight.bmp");
            waterTextures[7] = new OpenGLTexture2D(@"..\..\..\textures\Water2UpLeft.bmp");
            waterTextures[8] = new OpenGLTexture2D(@"..\..\..\textures\Water2UpRight.bmp");
            waterTextures[9] = new OpenGLTexture2D(@"..\..\..\textures\Water2UpDown.bmp");
            waterTextures[10] = new OpenGLTexture2D(@"..\..\..\textures\Water2LeftRight.bmp");
            waterTextures[11] = new OpenGLTexture2D(@"..\..\..\textures\Water3NoLeft.bmp");
            waterTextures[12] = new OpenGLTexture2D(@"..\..\..\textures\Water3NoDown.bmp");
            waterTextures[13] = new OpenGLTexture2D(@"..\..\..\textures\Water3NoRight.bmp");
            waterTextures[14] = new OpenGLTexture2D(@"..\..\..\textures\Water3NoUp.bmp");
            waterTextures[15] = new OpenGLTexture2D(@"..\..\..\textures\Water4.bmp");
            waterTextures[16] = new OpenGLTexture2D(@"..\..\..\textures\WaterCDownLeft.bmp");
            waterTextures[17] = new OpenGLTexture2D(@"..\..\..\textures\WaterCDownRight.bmp");
            waterTextures[18] = new OpenGLTexture2D(@"..\..\..\textures\WaterCUpRight.bmp");
            waterTextures[19] = new OpenGLTexture2D(@"..\..\..\textures\WaterCUpLeft.bmp");

            bombTextures[0] = new OpenGLTexture2D(@"..\..\..\textures\Bomb1.bmp");
            bombTextures[1] = new OpenGLTexture2D(@"..\..\..\textures\Bomb2.bmp");
            bombTextures[2] = new OpenGLTexture2D(@"..\..\..\textures\Bomb3.bmp");
            bombMasks[0] = new OpenGLTexture2D(@"..\..\..\textures\BombMask1.bmp");
            bombMasks[1] = new OpenGLTexture2D(@"..\..\..\textures\BombMask2.bmp");
            bombMasks[2] = new OpenGLTexture2D(@"..\..\..\textures\BombMask3.bmp");

            blowTextures[0] = new OpenGLTexture2D(@"..\..\..\textures\Blow1.bmp");
            blowTextures[1] = new OpenGLTexture2D(@"..\..\..\textures\Blow2.bmp");
            blowTextures[2] = new OpenGLTexture2D(@"..\..\..\textures\Blow3.bmp");
            blowTextures[3] = new OpenGLTexture2D(@"..\..\..\textures\Blow4.bmp");
            blowTextures[4] = blowTextures[3];

            blowMasks[0] = new OpenGLTexture2D(@"..\..\..\textures\BlowMask1.bmp");
            blowMasks[1] = new OpenGLTexture2D(@"..\..\..\textures\BlowMask2.bmp");
            blowMasks[2] = new OpenGLTexture2D(@"..\..\..\textures\BlowMask3.bmp");
            blowMasks[3] = blowMasks[2];

            flame = new OpenGLTexture2D(@"..\..\..\textures\flame.bmp");
            flameMask = new OpenGLTexture2D(@"..\..\..\textures\flameMask.bmp");
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
        /// Accessor to preview boolean value. Both get and set.
        /// </summary>
        public bool Preview
        {
            set
            {
                this.preview = value;
            }
            get
            {
                return this.preview;
            }
        }

        /// <summary>
        /// Sets map wrapper.
        /// </summary>
        /// <param name="mapWrapper">Map wrapper to be set.</param>
        public void SetMapWrapper(MapWrapper mapWrapper)
        {
            this.mapWrapper = mapWrapper;
        }

        /// <summary>
        /// Sets players wrapper.
        /// </summary>
        /// <param name="player1">First player wrapper to be set.</param>
        /// <param name="player2">Second player wrapper to be set.</param> 
        public void SetPlayersWrapper(PlayerWrapper player1, PlayerWrapper player2)
        {
            this.player1Wrapper = player1;
            this.player2Wrapper = player2;

            if (player1.PlayerClass.Name == player2.PlayerClass.Name)
            {
                int count = player1.PlayerClass.TexturePaths.Length;
                int pos = rand.Next(count);

                playerOneTexture = new OpenGLTexture2D(@player1.PlayerClass.TexturePaths[pos]);
                playerOneTextureMask = new OpenGLTexture2D(@player1.PlayerClass.TexturePaths[pos] + ".mask.bmp");
                playerTwoTexture = new OpenGLTexture2D(@player1.PlayerClass.TexturePaths[(pos + 1) % count]);
                playerTwoTextureMask = new OpenGLTexture2D(@player1.PlayerClass.TexturePaths[(pos + 1) % count] + ".mask.bmp");
            }
            else
            {
                int count = player1.PlayerClass.TexturePaths.Length;
                int pos = rand.Next(count);
                playerOneTexture = new OpenGLTexture2D(@player1.PlayerClass.TexturePaths[pos]);
                playerOneTextureMask = new OpenGLTexture2D(@player1.PlayerClass.TexturePaths[pos] + ".mask.bmp");

                count = player2.PlayerClass.TexturePaths.Length;
                pos = rand.Next(count);
                playerTwoTexture = new OpenGLTexture2D(@player2.PlayerClass.TexturePaths[pos]);
                playerTwoTextureMask = new OpenGLTexture2D(@player2.PlayerClass.TexturePaths[pos] + ".mask.bmp");

            }
        }

        /// <summary>
        /// Do some things every tick of the program.
        /// </summary>
        public void Tick()
        {
            iteratorIterator++;
            if (iteratorIterator > 7)
            {
                cycleIterator = (cycleIterator + 1) % 100;
                iteratorIterator = 0;
            }
            
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
            //we just want to draw map preview, so we don't touch players
            if (!preview)
            {
                DrawBombs();
                DrawPlayers();
            }
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
        /// Draws a map.
        /// </summary>
        private void DrawMap()
        {                
            
            GL.glPushMatrix();
            GL.glTranslatef(-width / 2, height / 2, 0.0f);
            //stretch the whole map to the size of conrol where it is diplaying (only in preview)
            if (preview)
            {
                GL.glScalef(width / height, 1.0f, 1.0f);
            }
            GL.glColor3f(1.0f, 1.0f, 1.0f);

            for (int i = 0; i < mapWrapper.MapHeight; i++)
            {
                for (int j = 0; j < mapWrapper.MapWidth; j++)
                {
                    Field field = mapWrapper.GetField(i, j);

                    if (field is NonPersistentWall)
                    {
                        textures[1].Bind();
                    }
                    else if (field is PersistentWall)
                    {
                        textures[0].Bind();                        
                    }
                    else if (field is Path)
                    {
                        textures[2].Bind();
                    }
                    else if (field is Water)
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
                            if (i < mapWrapper.MapHeight-1 && !(mapWrapper.GetField(i + 1, j) is Water)) //water on right and no water down
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

                    if (field.Bonus != null && field is Path)
                    {
                        /* distance between bonus quad and field border */
                        float distanceFromEdge = (mapWrapper.FieldSize - mapWrapper.BonusSize) / 2;

                        /* beda teksturki */
                        GL.glBegin(GL.GL_QUADS);
                        GL.glVertex2f(j * mapWrapper.FieldSize + distanceFromEdge,
                            -(i + 1) * mapWrapper.FieldSize + distanceFromEdge);
                        GL.glVertex2f((j + 1) * mapWrapper.FieldSize - distanceFromEdge,
                            -(i + 1) * mapWrapper.FieldSize + distanceFromEdge);                        
                        GL.glVertex2f((j + 1) * mapWrapper.FieldSize - distanceFromEdge,
                            -i * mapWrapper.FieldSize - distanceFromEdge);
                        GL.glTexCoord2f(0.0f, 1.0f);
                        GL.glVertex2f(j * mapWrapper.FieldSize + distanceFromEdge,
                            -i * mapWrapper.FieldSize - distanceFromEdge);
                        GL.glEnd();
                    }

                    if (field.HasBomb()) // na polu jest bomba (ale nie w stanie wybuchu), trza wiêc namalowaæ
                    {
                        drawingBombsList.Add(field.GetBomb());                        
                    }
                }
            }

            GL.glPopMatrix();
        }

        /// <summary>
        /// Draws players.
        /// </summary>
        private void DrawPlayers()
        {
            float x1, y1;
            float x2, y2;
            float radius;

            x1 = player1Wrapper.PositionX;
            y1 = player1Wrapper.PositionY;

            x2 = player2Wrapper.PositionX;
            y2 = player2Wrapper.PositionY;

            radius = Player.PlayerRadius;

            GL.glPushMatrix();
            GL.glTranslatef(-width / 2, height / 2, 0.0f);
            GL.glEnable(GL.GL_BLEND);


            /** player one **/

            /* player one mask */
            GL.glBlendFunc(GL.GL_DST_COLOR, GL.GL_ZERO);
            playerOneTextureMask.Bind();
            GL.glBegin(GL.GL_QUADS);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex2f(x1 - radius, -(y1 - radius));
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex2f(x1 + radius, -(y1 - radius));
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex2f(x1 + radius, -(y1 + radius));
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex2f(x1 - radius, -(y1 + radius));
            GL.glEnd();

            /* player one texture */
            GL.glBlendFunc(GL.GL_ONE, GL.GL_ONE);
            playerOneTexture.Bind();
            GL.glBegin(GL.GL_QUADS);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex2f(x1 - radius, -(y1 - radius));
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex2f(x1 + radius, -(y1 - radius));
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex2f(x1 + radius, -(y1 + radius));
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex2f(x1 - radius, -(y1 + radius));
            GL.glEnd();


            /** player two **/

            /* player two mask */
            GL.glBlendFunc(GL.GL_DST_COLOR, GL.GL_ZERO);
            playerTwoTextureMask.Bind();
            GL.glBegin(GL.GL_QUADS);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex2f(x2 - radius, -(y2 - radius));
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex2f(x2 + radius, -(y2 - radius));
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex2f(x2 + radius, -(y2 + radius));
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex2f(x2 - radius, -(y2 + radius));
            GL.glEnd();

            /* player two texture */
            GL.glBlendFunc(GL.GL_ONE, GL.GL_ONE);
            playerTwoTexture.Bind();
            GL.glBegin(GL.GL_QUADS);
            GL.glTexCoord2f(0.0f, 1.0f);
            GL.glVertex2f(x2 - radius, -(y2 - radius));
            GL.glTexCoord2f(1.0f, 1.0f);
            GL.glVertex2f(x2 + radius, -(y2 - radius));
            GL.glTexCoord2f(1.0f, 0.0f);
            GL.glVertex2f(x2 + radius, -(y2 + radius));
            GL.glTexCoord2f(0.0f, 0.0f);
            GL.glVertex2f(x2 - radius, -(y2 + radius));
            GL.glEnd();


            GL.glDisable(GL.GL_BLEND);

            GL.glPopMatrix();
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

        private void DrawBombs() {
            /* distance between bomb quad and field border */
            GL.glPushMatrix();
            GL.glTranslatef(-width / 2, height / 2, 0.0f);

            foreach (Bomb bomb in drawingBombsList)
            {
                int i = bomb.IPos;
                int j = bomb.JPos;
                float distanceFromEdge = (mapWrapper.FieldSize - mapWrapper.BombSize) / 2;

                GL.glEnable(GL.GL_BLEND);
                GL.glDisable(GL.GL_DEPTH_TEST);

                if (bomb.state == BombState.Waiting)
                {
                    GL.glBlendFunc(GL.GL_DST_COLOR, GL.GL_ZERO);

                    bombMasks[cycleIterator % 3].Bind();

                    GL.glBegin(GL.GL_QUADS);
                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex2f(j * mapWrapper.FieldSize + distanceFromEdge,
                        -(i + 1) * mapWrapper.FieldSize + distanceFromEdge);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex2f((j + 1) * mapWrapper.FieldSize - distanceFromEdge,
                        -(i + 1) * mapWrapper.FieldSize + distanceFromEdge);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex2f((j + 1) * mapWrapper.FieldSize - distanceFromEdge,
                        -i * mapWrapper.FieldSize - distanceFromEdge);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex2f(j * mapWrapper.FieldSize + distanceFromEdge,
                        -i * mapWrapper.FieldSize - distanceFromEdge);
                    GL.glEnd();

                    GL.glBlendFunc(GL.GL_ONE, GL.GL_ONE);

                    bombTextures[cycleIterator % 3].Bind();

                    GL.glBegin(GL.GL_QUADS);
                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex2f(j * mapWrapper.FieldSize + distanceFromEdge,
                        -(i + 1) * mapWrapper.FieldSize + distanceFromEdge);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex2f((j + 1) * mapWrapper.FieldSize - distanceFromEdge,
                        -(i + 1) * mapWrapper.FieldSize + distanceFromEdge);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex2f((j + 1) * mapWrapper.FieldSize - distanceFromEdge,
                        -i * mapWrapper.FieldSize - distanceFromEdge);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex2f(j * mapWrapper.FieldSize + distanceFromEdge,
                        -i * mapWrapper.FieldSize - distanceFromEdge);
                    GL.glEnd();
                }
                else if (bomb.state == BombState.Blow)
                {
                    /* How far fire reaches. */
                    float upRange =
                        Math.Min(mapWrapper.FieldSize * GetBombUpRange(i, j),
                        5.0f * mapWrapper.FieldSize * bomb.GetProgressFactor() / 100.0f);
                    float downRange =
                        Math.Min(mapWrapper.FieldSize * GetBombDownRange(i, j),
                        5.0f * mapWrapper.FieldSize * bomb.GetProgressFactor() / 100.0f);

                    float leftRange =
                        Math.Min(mapWrapper.FieldSize * GetBombLeftRange(i, j),
                        5.0f * mapWrapper.FieldSize * bomb.GetProgressFactor() / 100.0f);
                    float rightRange =
                        Math.Min(mapWrapper.FieldSize * GetBombRightRange(i, j),
                        5.0f * mapWrapper.FieldSize * bomb.GetProgressFactor() / 100.0f);


                    /* drawing flame */


                    GL.glBlendFunc(GL.GL_DST_COLOR, GL.GL_ZERO);
                    flameMask.Bind();

                    GL.glBegin(GL.GL_QUADS);

                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex2f(j * mapWrapper.FieldSize - leftRange,
                        -(i + 1) * mapWrapper.FieldSize);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex2f((j + 1) * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex2f((j + 1) * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex2f(j * mapWrapper.FieldSize - leftRange,
                        -i * mapWrapper.FieldSize);

                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize + rightRange,
                        -(i + 1) * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize + rightRange,
                        -i * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize, 0.0f);

                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize - downRange, 0.0f);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize - downRange, 0.0f);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize, 0.0f);

                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize + upRange, 0.0f);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize + upRange, 0.0f);
                    GL.glEnd();

                    GL.glBlendFunc(GL.GL_ONE, GL.GL_ONE);
                    flame.Bind();

                    GL.glBegin(GL.GL_QUADS);

                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex2f(j * mapWrapper.FieldSize - leftRange,
                        -(i + 1) * mapWrapper.FieldSize);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex2f((j + 1) * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex2f((j + 1) * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex2f(j * mapWrapper.FieldSize - leftRange,
                        -i * mapWrapper.FieldSize);

                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize + rightRange,
                        -(i + 1) * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize + rightRange,
                        -i * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize, 0.0f);

                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize - downRange, 0.0f);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize - downRange, 0.0f);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize, 0.0f);

                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize,
                        -(i + 1) * mapWrapper.FieldSize, 0.0f);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize + upRange, 0.0f);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize,
                        -i * mapWrapper.FieldSize + upRange, 0.0f);                    

                    GL.glEnd();


                    /* drwawing the other efect */

                    GL.glBlendFunc(GL.GL_DST_COLOR, GL.GL_ZERO);

                    /* finding adequate texture index */
                    int textureIndex = (int)Math.Floor(4 * bomb.GetProgressFactor() / 100);

                    blowMasks[textureIndex].Bind();

                    GL.glBegin(GL.GL_QUADS);
                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize + distanceFromEdge,
                        -(i + 1) * mapWrapper.FieldSize + distanceFromEdge, 0.1f);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize - distanceFromEdge,
                        -(i + 1) * mapWrapper.FieldSize + distanceFromEdge, 0.1f);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize - distanceFromEdge,
                        -i * mapWrapper.FieldSize - distanceFromEdge, 0.1f);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize + distanceFromEdge,
                        -i * mapWrapper.FieldSize - distanceFromEdge, 0.1f);
                    GL.glEnd();

                    GL.glBlendFunc(GL.GL_ONE, GL.GL_ONE);

                    blowTextures[textureIndex].Bind();

                    GL.glBegin(GL.GL_QUADS);
                    GL.glTexCoord2f(0.0f, 0.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize + distanceFromEdge,
                        -(i + 1) * mapWrapper.FieldSize + distanceFromEdge, 0.1f);
                    GL.glTexCoord2f(1.0f, 0.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize - distanceFromEdge,
                        -(i + 1) * mapWrapper.FieldSize + distanceFromEdge, 0.1f);
                    GL.glTexCoord2f(1.0f, 1.0f);
                    GL.glVertex3f((j + 1) * mapWrapper.FieldSize - distanceFromEdge,
                        -i * mapWrapper.FieldSize - distanceFromEdge, 0.1f);
                    GL.glTexCoord2f(0.0f, 1.0f);
                    GL.glVertex3f(j * mapWrapper.FieldSize + distanceFromEdge,
                        -i * mapWrapper.FieldSize - distanceFromEdge, 0.1f);
                    GL.glEnd();

                }

                GL.glDisable(GL.GL_BLEND);
                GL.glEnable(GL.GL_DEPTH_TEST);
            }
            drawingBombsList.Clear();
            GL.glPopMatrix();
        }

        /// <summary>
        /// Return how far up bomb's flame reach
        /// </summary>
        /// <param name="i">vertical position of a bomb</param>
        /// <param name="j">horizontal position of a bomb</param>
        /// <returns>range</returns>
        private int GetBombUpRange(int i, int j)
        {
            int k = 0;
            for (k = 0; k < 6; k++)
            {
                if (i - k < 0 || mapWrapper.GetField(i-k, j) is PersistentWall
                    || mapWrapper.GetField(i-k, j) is NonPersistentWall)
                {
                    break;
                }
            }
            return Math.Max(k-1,0);
        }

        /// <summary>
        /// Return how far to the left bomb's flame reach
        /// </summary>
        /// <param name="i">vertical position of a bomb</param>
        /// <param name="j">horizontal position of a bomb</param>
        /// <returns>range</returns>
        private int GetBombLeftRange(int i, int j)
        {
            int k = 0;
            for (k = 0; k < 6; k++)
            {
                if (j - k < 0 || mapWrapper.GetField(i, j - k) is PersistentWall
                    || mapWrapper.GetField(i, j - k) is NonPersistentWall)
                {
                    break;
                }
            }
            return Math.Max(k - 1, 0);
        }

        /// <summary>
        /// Return how far down bomb's flame reach
        /// </summary>
        /// <param name="i">vertical position of a bomb</param>
        /// <param name="j">horizontal position of a bomb</param>
        /// <returns>range</returns>
        private int GetBombDownRange(int i, int j)
        {
            int k = 0;
            for (k = 0; k < 6; k++)
            {
                if (i + k >= mapWrapper.MapHeight || mapWrapper.GetField(i + k, j) is PersistentWall
                    || mapWrapper.GetField(i + k, j) is NonPersistentWall)
                {
                    break;
                }
            }
            return Math.Max(k - 1, 0);
        }

        /// <summary>
        /// Return how far to the right bomb's flame reach
        /// </summary>
        /// <param name="i">vertical position of a bomb</param>
        /// <param name="j">horizontal position of a bomb</param>
        /// <returns>range</returns>
        private int GetBombRightRange(int i, int j)
        {
            int k = 0;
            for (k = 0; k < 6; k++)
            {
                if (j + k >= mapWrapper.MapWidth || mapWrapper.GetField(i, j + k) is PersistentWall
                    || mapWrapper.GetField(i, j + k) is NonPersistentWall)
                {
                    break;
                }
            }
            return Math.Max(k - 1, 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TheEarthQuake.Players;
using TheEarthQuake.Maps;
using TheEarthQuake.Bonuses;

namespace TheEarthQuake.Logic
{
    /// <summary>
    /// Defines the player we manipulate.
    /// </summary>
    public enum Players {Player1, Player2};
    
    /// <summary>
    /// Directions pool.
    /// </summary>
    public enum Directions {Left, Right, Up, Down};

    /// <summary>
    /// State machine class. It is responsible for
    /// changin program state, for player collisions, 
    /// for applying settings, and wrapper creation.
    /// </summary>
    public class StateMachine
    {
        private static float width = 1024;      // screen width
        private static float height = 768;      // screnn height

        private Maps.Map map;                               // actual map//private State currentState = null;                  // current machine state
        private float currentFPS;                           // frames per second
        private GameSettings gameSettings;
        private Player PlayerOne;                           // player 1 instance
        private Player PlayerTwo;                           // player 2 instance
        private System.Collections.ArrayList bombs;


        /// <summary>
        /// Accessor to screen height. Only get.
        /// </summary>
        public static float Height
        {
            get
            {
                return StateMachine.height;
            }
        }

        /// <summary>
        /// Accessor to screen width. Only get.
        /// </summary>
        public static float Width
        {
            get
            {
                return StateMachine.width;
            }
        }

        /// <summary>
        /// Accessor to current map. Only get. Redundant?
        /// 
        /// I think so. We have a factory few lines below.. (michal)
        /// </summary>
        public Maps.Map Map
        {
            get
            {
                return map;
            }
        }

        /// <summary>
        /// Accessor to current game settings. Only get.
        /// </summary>
        public GameSettings CurrentGameSettings
        {
            get
            {
                return gameSettings;
            }
        }

        /// <summary>
        /// Accessor to current frames per second value. Both set and get.
        /// </summary>
        public float CurrentFPS
        {
            get
            {
                return currentFPS;
            }
            set
            {
                currentFPS = value;
            }
        }

        /// <summary>
        /// Method responsible for moving player. Called by controller.
        /// </summary>
        public void MovePlayer(Players playerId, Directions direction)
        {            
            Player player = null;
            switch (playerId)
            { 
                case (Players.Player1):
                    player = PlayerOne;
                    break;
                case (Players.Player2):
                    player = PlayerTwo;
                    break;
                default:
                    throw new Exception("Illegal player in StateMachine.MovePlayer()");
            }

            /* if the center of the player moves 
               to the neighbouring field, we check collisions */

            float centerDx = 0;  // x shift of the player's center
            float centerDy = 0;  // y shift of the player's center
            
            /* we shift both: players center and players i,j coordinates,
               depending on direction. */

            float wallTunnelDistance = Map.FieldSize * 0.3f;

            switch (direction)  
            {                   
                /* we wish to move player to the left */

                case(Directions.Left):
                    #region
                    {
                        /* we calculate the shift to the left */

                        centerDx = -player.Speed * gameSettings.GameSpeed / currentFPS * Player.BaseStep;
                        
                        /* we calculate the border of the neighbouring field
                           on the left to check if player collides */

                        float leftFieldBorder = player.PositionJ * map.FieldSize;
                        
                        /* if player's border crosses the left field's border... */

                        if (player.PositionX + centerDx - Player.PlayerRadius < leftFieldBorder)
                        {
                            /* if the left border is on the neighbouring field,
                               forbid the movement */

                            if (player.PositionY - Player.PlayerRadius < player.PositionI * Map.FieldSize)
                                return;

                            /* if the right border is on the neighbouring field,
                               forbid the movement */

                            if (player.PositionY + Player.PlayerRadius > (player.PositionI + 1) * Map.FieldSize)
                                return;
                            
                            /* we hold the case, when we reach the map edge:
                             * move player's border to the touch the map edge */
                            
                            if (player.PositionJ == 0)
                            {
                                player.PositionX = Player.PlayerRadius;
                                return;
                            }
                            
                            /* we hold the case when we are not on the edge of 
                               the map - neighbouring field exists. We check if 
                               player is able to enter the field; if not, we move 
                               player's border to touch the fields edge. */

                            Maps.Field field = Map.GetField(player.PositionI, player.PositionJ - 1);
                            if (!(field is Maps.Path))
                            {
                                player.PositionX = leftFieldBorder + Player.PlayerRadius;
                                /* we check if field contains a bonus to get */
                                if (field.Bonus != null)
                                {
                                    // player gets the bonus
                                    field.Bonus = null;
                                    // here goes code to handle bonus event
                                }
                                return;
                            }

                            /* if we're not outta here yet, we can enter the 
                               neighbouring field, we have to update the i,j 
                               coordinates, if necessary */

                            if (player.PositionX + centerDx < leftFieldBorder)
                            {
                                player.PositionJ = player.PositionJ - 1;
                            }
                        }

                        /* anyhow, we have to update the position in 
                           floating coordinates */

                        player.PositionX = player.PositionX + centerDx;


                    }

                    #endregion
                    break;
                case (Directions.Right):
                    #region
                    {                      
                        /* we calculate the shift to the right */

                        centerDx = player.Speed * gameSettings.GameSpeed / currentFPS * Player.BaseStep;

                        /* we calculate the border of the neighbouring field
                         * on the right to check if player collides */

                        float rightFieldBorder = (player.PositionJ + 1) * map.FieldSize;

                        /* if player's border crosses the right field's border... */

                        if (player.PositionX + centerDx + Player.PlayerRadius > rightFieldBorder)
                        {
                            /* if the left border is on the neighbouring field,
                               forbid the movement */

                            if (player.PositionY - Player.PlayerRadius < player.PositionI * Map.FieldSize)
                                return;

                            /* if the right border is on the neighbouring field,
                               forbid the movement */

                            if (player.PositionY + Player.PlayerRadius > (player.PositionI + 1) * Map.FieldSize)
                                return;
                            
                            /* we hold the case, when we reach the map edge:
                             * move player's border to the touch the map edge */

                            if (player.PositionJ == Map.MapWidth - 1)
                            {
                                player.PositionX = Map.MapWidth * Map.FieldSize - Player.PlayerRadius;
                                return;
                            }

                            /* we hold the case when we are not on the edge of 
                             the map - neighbouring field exists. We check if 
                             player is able to enter the field; if not, we move 
                             player's border to touch the fields edge. */

                            Maps.Field field = Map.GetField(player.PositionI, player.PositionJ + 1);
                            if (!(field is Maps.Path))
                            {
                                player.PositionX = rightFieldBorder - Player.PlayerRadius;
                                return;
                            }

						    /* if we're not outta here yet, we can enter the 
						       neighbouring field, we have to update the i,j 
						       coordinates, if necessary */

						    if (player.PositionX + centerDx > rightFieldBorder)
						    {
							    player.PositionJ = player.PositionJ + 1;
						    }
					    }

					    /* anyhow, we have to update the position in 
					       floating coordinates */

					    player.PositionX = player.PositionX + centerDx;
                    }
                    #endregion
                    break;
                case (Directions.Up):
                    #region
                    {
                         /* we calculate the shift to the up */

                        centerDy = -player.Speed * gameSettings.GameSpeed / currentFPS * Player.BaseStep;

                        /* we calculate the border of the neighbouring field
                         * on the up to check if player collides */

                        float upFieldBorder = player.PositionI * map.FieldSize;

                        /* if player's border crosses the up field's border... */

                        if (player.PositionY + centerDy - Player.PlayerRadius < upFieldBorder)
                        {
                            /* if the left border is on the neighbouring field,
                               forbid the movement */

                            if (player.PositionX - Player.PlayerRadius < player.PositionJ * Map.FieldSize)
                                return;

                            /* if the right border is on the neighbouring field,
                              forbid the movement */

                            if (player.PositionX + Player.PlayerRadius > (player.PositionJ + 1) * Map.FieldSize)
                                return;

                            /* we hold the case, when we reach the map edge:
                             * move player's border to the touch the map edge */

                            if (player.PositionI == 0)
                            {
                                player.PositionY = Player.PlayerRadius;
                                return;
                            }

                            /* we hold the case when we are not on the edge of 
                             the map - neighbouring field exists. We check if 
                             player is able to enter the field; if not, we move 
                             player's border to touch the fields edge. */

                            Maps.Field field = Map.GetField(player.PositionI - 1, player.PositionJ);
                            if (!(field is Maps.Path))
                            {
                                player.PositionY = upFieldBorder + Player.PlayerRadius;
                                return;
                            }

                            /* if we're not outta here yet, we can enter the 
                               neighbouring field, we have to update the i,j 
                               coordinates, if necessary */

                            if (player.PositionY + centerDy < upFieldBorder)
                            {
                                player.PositionI = player.PositionI - 1;
                            }
                        }

                        /* anyhow, we have to update the position in 
                           floating coordinates */

                        player.PositionY = player.PositionY + centerDy;
                    }
                    #endregion
                    break;
                case (Directions.Down):
                    #region
                    {
                        /* we calculate the shift to the down */

                        centerDy = player.Speed * gameSettings.GameSpeed / currentFPS * Player.BaseStep;

                        /* we calculate the border of the neighbouring field
                         * on the down to check if player collides */

                        float downFieldBorder = (player.PositionI + 1) * map.FieldSize;

                        /* if player's border crosses the down field's border... */

                        if (player.PositionY + centerDy + Player.PlayerRadius > downFieldBorder)
                        {
                            /* if the left border is on the neighbouring field,
                                forbid the movement */

                            if (player.PositionX - Player.PlayerRadius < player.PositionJ * Map.FieldSize)
                                return;

                            /* if the right border is on the neighbouring field,
                              forbid the movement */

                            if (player.PositionX + Player.PlayerRadius > (player.PositionJ + 1) * Map.FieldSize)
                                return;
                            
                            /* we hold the case, when we reach the map edge:
                             * move player's border to the touch the map edge */

                            if (player.PositionI == Map.MapHeight - 1)
                            {
                                player.PositionY = Map.MapHeight * Map.FieldSize - Player.PlayerRadius;
                                return;
                            }

                            /* we hold the case when we are not on the edge of 
                             the map - neighbouring field exists. We check if 
                             player is able to enter the field; if not, we move 
                             player's border to touch the fields edge. */

                            Maps.Field field = Map.GetField(player.PositionI + 1, player.PositionJ);
                            if (!(field is Maps.Path))
                            {
                                player.PositionY = downFieldBorder - Player.PlayerRadius;                                
                                return;
                            }

                            /* if we're not outta here yet, we can enter the 
                               neighbouring field, we have to update the i,j 
                               coordinates, if necessary */

                            if (player.PositionY + centerDy > downFieldBorder)
                            {
                                player.PositionI = player.PositionI + 1;
                            }
                        }

                        /* anyhow, we have to update the position in 
                           floating coordinates */

                        player.PositionY = player.PositionY + centerDy;
                    }
                    #endregion
                    break;
                default:
                    throw new Exception("Illegal direction in StateMachine.MovePlayer()");
            }

            /* check if player got bonus */
            CheckForBonuses(player);
        }

        /// <summary>
        /// MEthod responsible for creating (setting up) a new game.
        /// </summary>
        public void CreateGame()
        {
            map = new Maps.Map();
            this.bombs = new System.Collections.ArrayList();
            PlayerOne = new Player(0, 0, Map.FieldSize/2, Map.FieldSize/2);
            PlayerTwo = new Player(Map.MapWidth - 1, 
                                   Map.MapHeight - 1,
                                   Map.MapWidth * Map.FieldSize - Map.FieldSize/2,
                                   Map.MapHeight * Map.FieldSize - Map.FieldSize/2);
        }

        /// <summary>
        /// Generates new map.
        /// </summary>
        public void GenerateMap()
        {
            map = new Maps.Map();
        }
        
        /// <summary>
        /// Map wrapper factory.
        /// </summary>
        public Maps.MapWrapper GetMapWrapper()
        {
            return new Maps.MapWrapper(map);
        }

        /// <summary>
        /// Player one factory.
        /// </summary>
        public PlayerWrapper GetPlayerOneWrapper()
        {
            return new PlayerWrapper(this.PlayerOne);
        }

        /// <summary>
        /// Player two factory.
        /// </summary>
        public PlayerWrapper GetPlayerTwoWrapper()
        {
            return new PlayerWrapper(this.PlayerTwo);
        }

        /// <summary>
        /// State machine constructor. 
        /// </summary>
        public StateMachine()
        {
            this.map = new Maps.Map();
            this.gameSettings = new GameSettings();
        }

        /// <summary>
        /// Checks if player get's bonus
        /// </summary>
        /// <param name="player">player to take the bonus</param>
        private void CheckForBonuses(Player player)
        {
            Bonus bonus;
            bonus = Map.GetBonusForPlayer(player.PositionI, player.PositionJ);
           
            if (bonus != null)
            {
                player.TakeBonus(bonus);
            }
        }


        public void InsertBomb(Players player)
        {
            Player playerInstance;
            switch (player)
            {
                case (Players.Player1):
                    playerInstance = PlayerOne;
                    break;
                case (Players.Player2):
                    playerInstance = PlayerTwo;
                    break;
                default:
                    throw new Exception("Illegal player in StateMachine.InsertBomb()");
            }
            if (!playerInstance.CanSetMine())
            {
                return;
            }
            Field field = this.map.Fields[playerInstance.PositionI, playerInstance.PositionJ];
            if (field.HasBomb())
            {
                return;
            }
            Maps.Bomb.Bomb insertedBomb = new TheEarthQuake.Maps.Bomb.Bomb
            (
                playerInstance.PositionX, playerInstance.PositionY,
                playerInstance.PositionI, playerInstance.PositionJ
            );
            this.map.InsertBomb(playerInstance.PositionI, playerInstance.PositionJ, insertedBomb);
            this.bombs.Add(insertedBomb);
            playerInstance.SetMine();
        }

        private bool checkBombTouch(Maps.Bomb.Bomb b, Player p)
        {   //trzeba sprawdzic czy player i bomba leza na tej samej lini, oddalone o niewiecej niz 5 (TU TEZ ZHARDCOROWANE!!)
            //oraz ze po drodze wszystko jest pathem
            if (b.IPos != p.PositionI && b.JPos != p.PositionJ)
            { //nie leza na jednej linii
                return false;
            }
            if (!(Math.Abs(b.IPos - p.PositionI) < 6 && Math.Abs(b.JPos - p.PositionJ) < 6))
            { //leza na jednej linii, ale za daleko
                return false;
            }
            bool noRigid = true;
            if (b.IPos == p.PositionI)
            {//leza na tej samej wsp. i; wiec sprawdzamy wszystkie pola na j po drodze
                for (int k = 0; k < 4 && Math.Abs(b.JPos - p.PositionJ) > k; ++k)
                {
                    if (p.PositionJ > b.JPos)
                    {
                        if (!(map.Fields[b.IPos, b.JPos + k] is Maps.Path))
                        {
                            noRigid = false;
                        }
                    }
                    else
                    {
                        if (!(map.Fields[b.IPos, b.JPos - k] is Maps.Path))
                        {
                            noRigid = false;
                        }
                    }
                };
                return noRigid;
            }
            //leza na tej samej j; sprawdzamy pola na i po drodze
            noRigid = true;
            for (int k = 0; k < 4 && Math.Abs(b.IPos - p.PositionI) > k; ++k)
            {
                if (p.PositionI > b.IPos)
                {
                    if (!(map.Fields[b.IPos + k, b.JPos] is Maps.Path))
                    {
                        noRigid = false;
                    }
                }
                else
                {
                    if (!(map.Fields[b.IPos - k, b.JPos] is Maps.Path))
                    {
                        noRigid = false;
                    }
                }
            };
            return noRigid;
        }

        private void BlowWalls(int i, int j)
        {
            bool cut = true;
            //i -
            for (int k = 1; cut && k < 6; ++k)
            {
                if (i - k < 0)
                {
                    break;
                }

                if (!(this.map.Fields[i - k, j] is Maps.Path))
                {
                    if (this.map.Fields[i - k, j] is Maps.NonPersistentWall)
                    {//kruszymy sciane
                        /* kopiujemy bobus ¿eby by³ w na œcie¿ce */
                        Bonus bonus = this.map.Fields[i - k, j].Bonus;
                        this.map.Fields[i - k, j] = new Maps.Path(this.map.Fields[i - k, j]);
                        this.map.Fields[i - k, j].Bonus = bonus;

                    }
                    cut = false;
                }
            }
            cut = true;
            //i +
            for (int k = 1; cut && k < 6; ++k)
            {
                if (i + k >= this.map.MapWidth)
                {
                    break;
                }
                if (!(this.map.Fields[i + k, j] is Maps.Path))
                {
                    if (this.map.Fields[i + k, j] is Maps.NonPersistentWall)
                    {//kruszymy sciane
                        this.map.Fields[i + k, j] = new Maps.Path(this.map.Fields[i + k, j]);
                    }
                    cut = false;
                }
            }
            cut = true;
            // j -
            for (int k = 1; cut && k < 6; ++k)
            {
                if (j - k < 0)
                {
                    break;
                }
                if (!(this.map.Fields[i, j - k] is Maps.Path))
                {
                    if (cut && this.map.Fields[i, j - k] is Maps.NonPersistentWall)
                    {//kruszymy sciane
                        this.map.Fields[i, j - k] = new Maps.Path(this.map.Fields[i, j - k]);
                    }
                    cut = false;
                }
            }
            cut = true;
            //j +
            for (int k = 1; cut && k < 6; ++k)
            {
                if (j + k >= map.MapHeight)
                {
                    break;
                }
                if (!(this.map.Fields[i, j + k] is Maps.Path))
                {
                    if (cut && this.map.Fields[i, j + k] is Maps.NonPersistentWall)
                    {//kruszymy sciane
                        this.map.Fields[i, j + k] = new Maps.Path(this.map.Fields[i, j + k]);
                    }
                    cut = false;
                }
            }
        }

        public void Tick()
        {
            this.PlayerOne.tick();
            this.PlayerTwo.tick();
            System.Collections.IEnumerator bombaEnumerator = this.bombs.GetEnumerator();
            while (bombaEnumerator.MoveNext())
            {
                Maps.Bomb.Bomb bomba = ((Maps.Bomb.Bomb)bombaEnumerator.Current);
                bomba.tick();
                if (bomba.state == Maps.Bomb.BombState.Blow && !bomba.Blown)
                {
                    //TU JEST ZHARDCOROWANE NA ILE POL SIE ROZCHODZI WYBUCH
                    //bo zabraliscie z klasy player pole power; poza tym
                    //pytalem jak ma wygladac animacja i nic - no to spoko; dla mnie BOMBA
                    //wiec zaznaczam ze bomba jest wybuchnieta i niszcze pierwsza napotkana przeszkode, do tego
                    //dodam playerowi stub TouchedByMine - ale niech go uzupelni osoba odpowiedzialna za player'a

                    if (this.checkBombTouch(bomba, this.PlayerOne))
                    {
                        this.PlayerOne.TouchedByMine();
                    }
                    if (this.checkBombTouch(bomba, this.PlayerTwo))
                    {
                        this.PlayerTwo.TouchedByMine();
                    }
                    this.BlowWalls(bomba.IPos, bomba.JPos);
                    bomba.Blown = true;
                }
                if (bomba.state == Maps.Bomb.BombState.ToRemove)
                {
                    this.map.Fields[bomba.IPos, bomba.JPos].RemoveBomb();
                }
            }
        }

    }
}

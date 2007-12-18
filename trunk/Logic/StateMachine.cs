using System;
using System.Collections.Generic;
using System.Text;

/*
 *  TODO: 
 * -> sprawdzic, czy nie odwrocilismy indeksow w mapie!! ;-)
 * -> dorobic stan gry (jakis enum, pole, czy cos)  
 * -> dorobic klase playerWrapper na modle mapWrapper i dawac silnikowi zeby sobie 
 *    malowal graczy (kontroler daje, tu tylko zwracamy wrappery funkcyjnie)
 */

namespace TheEarthQuake.Logic
{
    public enum Players {Player1, Player2};
    public enum Directions {Left, Right, Up, Down};

    public class StateMachine
    {
        private static float width = 1024;
        private static float height = 768;       

        private Maps.Map map;
        private State currentState = null;
        private GameSettings currentGameSettings = null;
        private float currentFPS;

        private Player PlayerOne = null;
        private Player PlayerTwo = null;

        public static float Height
        {
            get
            {
                return StateMachine.height;
            }
        } 

        public static float Width
        {
            get
            {
                return StateMachine.width;
            }
        } 

        public Maps.Map Map
        {
            get
            {
                return map;
            }
        }

        public State CurrentState
        {
            get
            {
                return currentState;
            }
        }

        public GameSettings CurrentGameSettings
        {
            get
            {
                return currentGameSettings;
            }
        }

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
            
            switch (direction)  
            {   
                /* we wish to move player to the left */

                case(Directions.Left):    
                    {
                        /* we calculate the shift to the left */

                        centerDx = -player.Speed * Player.BaseStep;
                        
                        /* we calculate the border of the neighbouring field
                           on the left to check if player collides */

                        float leftFieldBorder = player.PositionI * map.FieldSize;
                        
                        /* if player's border crosses the left field's border... */

                        if (player.PositionX + centerDx - Player.PlayerRadius < leftFieldBorder)
                        {
                            /* we hold the case, when we reach the map edge:
                             * move player's border to the touch the map edge */
                            
                            if (player.PositionI == 0)
                            {
                                player.PositionX = Player.PlayerRadius;
                                return;
                            }
                            
                            /* we hold the case when we are not on the edge of 
                               the map - neighbouring field exists. We check if 
                               player is able to enter the field; if not, we move 
                               player's border to touch the fields edge. */

                            Maps.Field field = Map.GetField(player.PositionI - 1, player.PositionJ);
                            if (!(field is Maps.Path))
                            {
                                player.PositionX = leftFieldBorder + Player.PlayerRadius;
                                return;
                            }

                            /* if we're not outta here yet, we can enter the 
                               neighbouring field, we have to update the i,j 
                               coordinates, if necessary */

                            if (player.PositionX + centerDx < leftFieldBorder)
                            {
                                player.PositionI = player.PositionI - 1;
                            }
                        }

                        /* anyhow, we have to update the position in 
                           floating coordinates */

                        player.PositionX = player.PositionX + centerDx;
                    }
                    break;

                case (Directions.Right):
                    {    
                        /* we calculate the shift to the right */

                        centerDx = player.Speed * Player.BaseStep;

                        /* we calculate the border of the neighbouring field
                         * on the right to check if player collides */

                        float rightFieldBorder = (player.PositionI + 1) * map.FieldSize;

                        /* if player's border crosses the right field's border... */

                        if (player.PositionX + centerDx + Player.PlayerRadius > rightFieldBorder)
                        {
                            /* we hold the case, when we reach the map edge:
                             * move player's border to the touch the map edge */

                            if (player.PositionI == Map.MapWidth - 1)
                            {
                                player.PositionX = Map.MapWidth * Map.FieldSize - Player.PlayerRadius;
                                return;
                            }

                            /* we hold the case when we are not on the edge of 
                             the map - neighbouring field exists. We check if 
                             player is able to enter the field; if not, we move 
                             player's border to touch the fields edge. */

                            Maps.Field field = Map.GetField(player.PositionI + 1, player.PositionJ);
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
							    player.PositionI = player.PositionI + 1;
						    }
					    }

					    /* anyhow, we have to update the position in 
					       floating coordinates */

					    player.PositionX = player.PositionX + centerDx;
                    }
                    break;
                case (Directions.Up):          
                    {
                        /* we calculate the shift to the up */

                        centerDy = -player.Speed * Player.BaseStep;

                        /* we calculate the border of the neighbouring field
                         * on the up to check if player collides */

                        float upFieldBorder = player.PositionJ * map.FieldSize;

                        /* if player's border crosses the up field's border... */

                        if (player.PositionY + centerDy - Player.PlayerRadius < upFieldBorder)
                        {
                            /* we hold the case, when we reach the map edge:
                             * move player's border to the touch the map edge */

                            if (player.PositionJ == 0)
                            {
                                player.PositionY = Player.PlayerRadius;
                                return;
                            }

                            /* we hold the case when we are not on the edge of 
                             the map - neighbouring field exists. We check if 
                             player is able to enter the field; if not, we move 
                             player's border to touch the fields edge. */

                            Maps.Field field = Map.GetField(player.PositionI, player.PositionJ - 1);
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
                                player.PositionJ = player.PositionJ - 1;
                            }
                        }

                        /* anyhow, we have to update the position in 
                           floating coordinates */

                        player.PositionY = player.PositionY + centerDy;
                    }
                    break;
                case (Directions.Down): 
                    {
                        /* we calculate the shift to the down */

                        centerDy = player.Speed * Player.BaseStep;

                        /* we calculate the border of the neighbouring field
                         * on the down to check if player collides */

                        float downFieldBorder = (player.PositionJ + 1) * map.FieldSize;

                        /* if player's border crosses the down field's border... */

                        if (player.PositionY + centerDy + Player.PlayerRadius > downFieldBorder)
                        {
                            /* we hold the case, when we reach the map edge:
                             * move player's border to the touch the map edge */

                            if (player.PositionJ == Map.MapHeight - 1)
                            {
                                player.PositionY = Map.MapHeight * Map.FieldSize - Player.PlayerRadius;
                                return;
                            }

                            /* we hold the case when we are not on the edge of 
                             the map - neighbouring field exists. We check if 
                             player is able to enter the field; if not, we move 
                             player's border to touch the fields edge. */

                            Maps.Field field = Map.GetField(player.PositionI, player.PositionJ + 1);
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
                                player.PositionJ = player.PositionJ + 1;
                            }
                        }

                        /* anyhow, we have to update the position in 
                           floating coordinates */

                        player.PositionY = player.PositionY + centerDy;
                    }
                    break;
                default:
                    throw new Exception("Illegal direction in StateMachine.MovePlayer()");
            }
        }

        public void CreateGame()
        {
            map = new Maps.Map();
            PlayerOne = new Player(0, 0, Player.PlayerRadius, Player.PlayerRadius);
            PlayerTwo = new Player(Map.MapWidth - 1, 
                                   Map.MapHeight - 1,
                                   Map.MapWidth * Map.FieldSize - Player.PlayerRadius,
                                   Map.MapHeight * Map.FieldSize - Player.PlayerRadius);
        }

        public Maps.MapWrapper GetWrapper()
        {
            return new Maps.MapWrapper(map);
        }

        public StateMachine()
        {
            map = new Maps.Map();
        }
    }
}

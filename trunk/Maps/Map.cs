/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace Maps
{
    public class Map
    {
        private Field[,] fields;

        private static int mapHeight = 49;                                  /// ought to be odd
        private static int mapWidth  = 49;                                  /// ought to be odd                                                                           

        private Random floatGenerator;
        private Random intGenerator;

        public static int MapHeight
        {
            get 
            {
                return mapHeight;
            }
        }

        public Map()
        {
            fields = new Path[mapHeight, mapWidth];

            floatGenerator = new Random();
            intGenerator = new Random();

            SetPersistentWalls();
            SetWaterFields();
            SetNonPersistentWalls();
            SetPlayersLivingSpace();
        }

        private void SetPersistentWalls()
        {
            for (int i = 1; i < mapHeight; i += 2)
                for (int j = 1; j < mapWidth; j += 2)
                {
                    fields[i, j] = new PersistentWall();
                }
        }

        private void SetWaterFields()
        { 
            /* 
             * TODO: 
             * -> generowac wieksze spojne obszary wody, a nie
             *    rozsiane pojedynczo kaluze
             * -> DFS zeby zachowac spojnosc mapy
             */

            double fractureOfWalkableFields = floatGenerator.NextDouble() * 0.2;  
            int totalWalkableFields = (mapWidth * mapHeight) - (mapWidth / 2 * mapHeight / 2);
            int wateredFields = (int)(totalWalkableFields * fractureOfWalkableFields);

            for (int i = 0; i < wateredFields; i++)
            {
                int waterColumn;
                int waterRow;

                do
                {
                    waterRow = intGenerator.Next(mapWidth);
                    waterColumn = intGenerator.Next(MapHeight);
                }
                while (fields[waterRow, waterColumn] is PersistentWall);

                fields[waterRow, waterColumn] = new Water();
            }
        }

        private void SetNonPersistentWalls()
        {
            double fractureOfWalkableFields = floatGenerator.NextDouble() * 0.4;
            int totalWalkableFields = (mapWidth * mapHeight) - (mapWidth / 2 * mapHeight / 2);
            int walledFields = (int)(totalWalkableFields * fractureOfWalkableFields);

            for (int i = 0; i < walledFields; i++)
            {
                int wallColumn;
                int wallRow;

                do
                {
                    wallRow = intGenerator.Next(mapWidth);
                    wallColumn = intGenerator.Next(MapHeight);
                }
                while (!(fields[wallRow, wallColumn] is Path));

                fields[wallRow, wallColumn] = new NonPersistentWall();
            }

        }

        private void SetPlayersLivingSpace()
        { 
            /* 
             *  Each player must have a "minimal" living space around 
             *  him at start, so he does not to have blow himself up to get out.
             */    

            /// Setting up first players living space

            fields[0, 0] = new Path();
            fields[0, 1] = new Path();
            fields[1, 0] = new Path();

            /// Setting up second players living space

            fields[mapHeight - 1, mapWidth - 1] = new Path();
            fields[mapHeight - 2, mapWidth - 1] = new Path();
            fields[mapHeight - 1, mapWidth - 2] = new Path();
        }
    }

}

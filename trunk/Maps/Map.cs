/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

/*
 *  TODO:
 *   -> napisac sprawdzanie spojnosci mapy
 *      (
 *        wg nastepujacego schematu:
 *          1. rozlewamy wode;
 *          2. po rozlaniu wody odpalamy DFS, ktory zlicza nam ilosc pol na ktore moze przejsc
 *             gracz
 *          3. jezeli liczba tych pol jest rowna liczbie pol typu Paths, to ok
 *          4. w przeciwnym razie trzeba cofnac zmiany i sprobowac rozlac wode gdzie indziej (historia) * 
 *      )
 *   -> jak sie pojawi obsluga bomb, to wypelnic metode BlowUp()
 *   -> GetFieldState jest do wypelnienia (trzeba ustalic co ma zwracac)
 */

using System;

namespace TheEarthQuake.Maps
{
    public class Map
    {
        private int mapHeight = 19;                     /// ought to be odd
        private int mapWidth = 19;                      /// ought to be odd 
        
        private float fieldSize = 35;

        private Field[,] fields;                        /// container for fields

        private Random floatGenerator;                  /// used to generate some doubles
        private Random intGenerator;                    /// same for ints
                                                        /// 
        public int MapHeight
        {
            get 
            {
                return this.mapHeight;
            }
        }

        public int MapWidth
        {
            get
            {
                return this.mapWidth;
            }
        }

        public Field[,] Fields
        {
            get
            {
                return fields;
            }
        }

        /* Constructor for class
         * Be careful with order of function calls!
         * (e.g. SetPlayersLivingSpace() must be called as
         * a last one *)
         */
        public Map()
        {
            fields = new Field[mapHeight, mapWidth];

            floatGenerator = new Random();
            intGenerator = new Random();

            FillWithPaths();
            SetPersistentWalls();
            SetWaterFields();
            SetNonPersistentWalls();
            SetPlayersLivingSpace();
        }

        public float FieldSize
        {
            get 
            {
                return this.fieldSize;
            }
        }
    
        public Field GetField(int i, int j) 
        {
            return Fields[i, j].clone();
        }
        
        public void BlowUp(int i, int j)
        {
            /* STUB! */
        }

        /*
         *  Fills the map with fields of type Path
         *  (fills only those fields, which are empty).
         *  Path is the simplest field,
         *  on which player can walk with no limits. 
         */
         
        private void FillWithPaths()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (fields[i, j] == null)
                        fields[i, j] = new Path();
                }
            }
        }                 

        /*
         * Fills the map with persistent walls, which are
         * non-destroyable by any bomb (except Chuck Norris).
         * Persistent walls positions are set with 
         * a check pattern.
         */

        private void SetPersistentWalls()
        {
            for (int i = 1; i < mapHeight; i += 2)
            {
                for (int j = 1; j < mapWidth; j += 2)
                {
                    fields[i, j] = new PersistentWall();
                }
            }
        }

        /*
         * This function picks up a number of fields to be watered
         * (at most 20% of maps total walkable fields). Then it tries
         * to pick up a place to spill some water (at most 5 fields per try)
         * and spills it. 
         */

        private void SetWaterFields()
        { 
            double fractureOfWalkableFields = floatGenerator.NextDouble() * 0.1;  
            int totalWalkableFields = (mapWidth * mapHeight) - (mapWidth / 2 * mapHeight / 2);
            int fieldsToWater = (int)(totalWalkableFields * fractureOfWalkableFields);

            for (int i = 0; i < fieldsToWater; i++)
            {
                int waterColumn;
                int waterRow;

                do
                {
                    waterRow = intGenerator.Next(mapWidth);
                    waterColumn = intGenerator.Next(MapHeight);
                }
                while (fields[waterRow, waterColumn] is PersistentWall);

                i += SpillWater(waterRow, waterColumn, fieldsToWater, i);
            }
        }

        /*
         * Function responsible for each try of spilling the water.
         * It picks up a number of fields to water (at most 5 fields),
         * then, for each field, it picks up a direction, and:
         *    1. if it is a Path, then it changes it to Water 
         *       (with checking map boundaries!)
         *    2. else, if it is already filled with water, it just 
         *       moves to that field (it does not spill anything!)
         *    3. to do: check for the coherency of accessible fields
         *    4. to do: roll back spilling if it spoils coherency
         */

        private int SpillWater(int row, int column, int fieldsToWater, int wateredFieldsYet)
        {
            fields[row, column] = new Water();
            
            int maxSpilledWaterFields = 6;
            int waterFieldsToSpill = intGenerator.Next(maxSpilledWaterFields);

            /// number of total watered fields must not exceed picked up value
            
            if (wateredFieldsYet + waterFieldsToSpill >= fieldsToWater)
                waterFieldsToSpill = fieldsToWater - wateredFieldsYet;

            /// instead of enum type, which had to be declared outside of this function

            const short N = 0;
            const short S = 1;
            const short W = 2;
            const short E = 3;

            int pickedDirection;
            int waterSpilledYet = 0;
            while (waterSpilledYet <= waterFieldsToSpill)
            {
                pickedDirection = intGenerator.Next(4);
                switch (pickedDirection)
                { 
                    case N:
                        if (row > 0 && fields[row - 1, column] is Path)
                        {
                            fields[row - 1, column] = new Water();
                            waterSpilledYet++;
                        }
                        if (row > 0 && fields[row - 1, column] is Water)
                        {
                            row -= 1;
                        }
                        break;
                    case S:
                        if (row < mapHeight - 1 && fields[row + 1, column] is Path)
                        {
                            fields[row + 1, column] = new Water();
                            waterSpilledYet++;
                        }
                        if (row < mapHeight - 1 && fields[row + 1, column] is Water)
                        {
                            row += 1;
                        }
                        break;
                    case W:
                        if (column > 0 && fields[row, column - 1] is Path)
                        {
                            fields[row, column - 1] = new Water();
                            waterSpilledYet++;
                        }
                        if (column > 0 && fields[row, column - 1] is Water)
                        {
                            column -= 1;
                        }
                        break;
                    case E:
                        if (column < mapWidth - 1 && fields[row, column + 1] is Path)
                        {
                            fields[row, column + 1] = new Water();
                            waterSpilledYet++;
                        }
                        if (column < mapWidth - 1 && fields[row, column + 1] is Water)
                        {
                            column += 1;
                        }
                        break;
                }
            }

            return waterFieldsToSpill;
        }

        /* This function sets some non-persistent wall (at most 40%
         * of walkable fields) in simplest way (randomly)
         */

        private void SetNonPersistentWalls()
        {
            double fractureOfWalkableFields = floatGenerator.NextDouble() * 0.4 + 0.3;
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

        /* 
         *  Each player must have a "minimal" living space around 
         *  him at start, so he does not to have blow himself up to get out.
         *  Player 1 is set in (0,0), and Player 2 is set in (mapHeight - 1, mapWidth - 1).
         *  Both of players neighboring fields must be walkable.
         */   

        private void SetPlayersLivingSpace()
        {  

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
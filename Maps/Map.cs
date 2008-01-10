/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace TheEarthQuake.Maps
{
    /// <summary>
    /// Represents map with container of fields. Map generator is provided
    /// in constructor.
    /// </summary>
    public class Map
    {
        private int mapHeight = 19;                     // ought to be odd
        private int mapWidth = 19;                      // ought to be odd 
        
        private float fieldSize;                        // field size for OpenGL
        private float bonusSize;                        // bonus' quad size for OpenGL

        private Field[,] fields;                        // container for fields

        private Random floatGenerator;                  // used to generate some doubles
        private Random intGenerator;                    // same for ints
        
        /// <summary>
        /// Returns number of fields in column.
        /// </summary>
        public int MapHeight
        {
            get 
            {
                return this.mapHeight;
            }
        }

        /// <summary>
        /// Returns number of fields in row.
        /// </summary>
        public int MapWidth
        {
            get
            {
                return this.mapWidth;
            }
        }

        /// <summary>
        /// Returns fields container.
        /// </summary>
        public Field[,] Fields
        {
            get
            {
                return fields;
            }
        }

        /// <summary>
        /// Returns field size.
        /// </summary>
        public float FieldSize
        {
            get
            {
                return this.fieldSize;
            }
        }

        /// <summary>
        /// Return bonus quad size.
        /// </summary>
        public float BonusSize
        {
            get
            {
                return this.bonusSize;
            }
        }

        /// <summary>
        /// Constructor - it generates map. It doesn't assure 
        /// that graph of walkable fields is connected.
        /// </summary>
        public Map()
        {
            /* Be careful with order of function calls!
             * (e.g. SetPlayersLivingSpace() must be called as
             * a last one *)
             */
            fieldSize = 768.0f / mapHeight;      //sets fieldSize so that map's height is equal to screen's height
            bonusSize = fieldSize - 10;          //sets bonusSize so that it's a bit smaller then a field

            fields = new Field[mapHeight, mapWidth];

            floatGenerator = new Random();
            intGenerator = new Random();

            FillWithPaths();
            SetPersistentWalls();
            SetWaterFields();
            SetNonPersistentWalls();
            SetPlayersLivingSpace();
        }

        /// <summary>
        /// Returns clone of field (used to access the type of field) from row 'i' and column 'j'.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public Field GetField(int i, int j) 
        {
            return Fields[i, j].clone();
        }
        
        /// <summary>
        /// Blows up bomb on row 'i' and column 'j'
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void BlowUp(int i, int j)
        {
            /* STUB! */
        }

        /// <summary>
        /// Return bonus that lies on row 'i', column 'j'
        /// providing that this bonus exists and erases it from the field.
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        public Bonuses.Bonus GetBonusForPlayer(int i, int j)
        {
            Bonuses.Bonus bonus = this.fields[i, j].Bonus;            
            this.fields[i, j].Bonus = null;
            return bonus;            
        }
        
        /// <summary>
        /// Fills the map with path fields.
        /// </summary>
        private void FillWithPaths()
        {       
            /*
             *  Fills the map with fields of type Path
             *  (fills only those fields, which are empty).
             *  Path is the simplest field,
             *  on which player can walk with no limits. 
             */
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (fields[i, j] == null)
                    {
                        fields[i, j] = new Path();                        
                    }
                }
            }
        }                 

        /// <summary>
        /// Sets persistent walls on map.
        /// </summary>
        private void SetPersistentWalls()
        {       
            /*
             * Fills the map with persistent walls, which are
             * non-destroyable by any bomb (except Chuck Norris).
             * Persistent walls positions are set with 
             * a check pattern.
             */
            for (int i = 1; i < mapHeight; i += 2)
            {
                for (int j = 1; j < mapWidth; j += 2)
                {
                    fields[i, j] = new PersistentWall();
                }
            }
        }
        
        /// <summary>
        /// Sets water fields on map.
        /// </summary>
        private void SetWaterFields()
        {
            /*
             * This function picks up a number of fields to be watered
             * (at most 20% of maps total walkable fields). Then it tries
             * to pick up a place to spill some water (at most 5 fields per try)
             * and spills it. 
             */
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

        /// <summary>
        /// Method fills few neighbored fields with water.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="fieldsToWater"></param>
        /// <param name="wateredFieldsYet"></param>
        /// <returns></returns>
        private int SpillWater(int row, int column, int fieldsToWater, int wateredFieldsYet)
        {
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
            fields[row, column] = new Water();
            
            int maxSpilledWaterFields = 6;
            int waterFieldsToSpill = intGenerator.Next(maxSpilledWaterFields);

            // number of total watered fields must not exceed picked up value
            
            if (wateredFieldsYet + waterFieldsToSpill >= fieldsToWater)
                waterFieldsToSpill = fieldsToWater - wateredFieldsYet;

            // instead of enum type, which had to be declared outside of this function

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


        /// <summary>
        /// Sets destroyable walls.
        /// </summary>
        private void SetNonPersistentWalls()
        {    
            /* This function sets some non-persistent wall (from 30% to 70%
             * of walkable fields) in simplest way (randomly)
             */
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

                /*set's bonus for a filed with some propability*/
                fields[wallRow, wallColumn].Bonus = GenerateBonus();
            }            
        }

        /// <summary>
        /// Sets three fields neghboring with start field (for both players) to bo walkable.
        /// </summary>
        private void SetPlayersLivingSpace()
        {
            /* 
             *  Each player must have a "minimal" living space around 
             *  him at start, so he does not to have blow himself up to get out.
             *  Player 1 is set in (0,0), and Player 2 is set in (mapHeight - 1, mapWidth - 1).
             *  Both of players neighboring fields must be walkable.
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
        
        /// <summary>
        /// Generates bonus of some type or null and returns it.
        /// </summary>
        /// <returns>some bonus as type Bonus or null</returns>
        private Bonuses.Bonus GenerateBonus()
        {            
            float bonusPropability = 0.1f;
            Type[] bonusTypes = { Type.GetType("TheEarthQuake.Maps.Bonuses.SampleBonus") };  // types of bonuses in the game            

            if (floatGenerator.NextDouble() < bonusPropability)
            {
                /*get type of bonus to return*/
                Type returnBonusType = bonusTypes[intGenerator.Next(bonusTypes.Length)];
                
                /*return new instance of a bonus*/
                return returnBonusType.GetConstructors()[0].Invoke(new object[0]) as Maps.Bonuses.Bonus;
            }
            else
            {
                return null;
            }
        }
    }    
}

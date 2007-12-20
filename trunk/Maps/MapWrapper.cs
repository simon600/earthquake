using System;
using System.Collections.Generic;
using System.Text;

/*
 TODO:
 *   -> GetFieldState jest do utworzenia i wypelnienia (trzeba ustalic co ma zwracac)
 */

namespace TheEarthQuake.Maps
{
    /// <summary>
    /// Map wrapper is used to avoid direct access to map
    /// </summary>
    public class MapWrapper
    {
        private Map map;

        /// <summary>
        /// Constructor sets the map reference.
        /// </summary>
        /// <param name="map"></param>
        public MapWrapper(Maps.Map map)
        {
            this.map = map;
        }

        /// <summary>
        /// Returns map height.
        /// </summary>
        public int MapHeight
        {
            get
            {
                return map.MapHeight;
            }
        }

        /// <summary>
        /// Returns map width.
        /// </summary>
        public int MapWidth
        {
            get
            {
                return map.MapWidth;
            }
        }

        /// <summary>
        /// Returns size of field.
        /// </summary>
        public float FieldSize
        {
            get
            {
                return map.FieldSize;
            }
        }

        /// <summary>
        /// Returns clone of field (used to access the type of field) from row 'i' and column 'j'.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public Field GetField(int i, int j)
        {
            return map.GetField(i, j);
        }

    }
}

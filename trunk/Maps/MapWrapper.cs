using System;
using System.Collections.Generic;
using System.Text;

/*
 TODO:
 *   -> GetFieldState jest do utworzenia i wypelnienia (trzeba ustalic co ma zwracac)
 */

namespace TheEarthQuake.Maps
{
    public class MapWrapper
    {
        private Map map;

        public MapWrapper(Maps.Map map)
        {
            this.map = map;
        }

        public int MapHeight
        {
            get
            {
                return this.MapHeight;
            }
        }

        public int MapWidth
        {
            get
            {
                return this.MapWidth;
            }
        }

        public Field GetField(int i, int j)
        {
            return map.GetField(i, j);
        }

        public float FieldSize
        {
            get 
            {
                return map.FieldSize;
            }
        }
    }
}

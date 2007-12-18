/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace TheEarthQuake.Maps

{
    /*
     * Abstract class representing field. Field may
     * contain bonus (see private Bonus bonus)
     */
    public abstract class Field
    {
        private Bonuses.Bonus bonus;

        public abstract Field clone();
    }
}

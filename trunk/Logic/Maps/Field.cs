/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;
using TheEarthQuake.Logic.Bonuses;

namespace TheEarthQuake.Logic.Maps

{
    /*
     * Abstract class representing field. Field may
     * contain bonus (see private Bonus bonus)
     */
    public abstract class Field
    {
        private Bonus bonus;
    }
}

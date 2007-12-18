/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace TheEarthQuake.Maps
{
    /*
     * This is non-walkable field, but
     * blows can go through it. It shouldn't
     * contain bonuses.
     */
    public class Water : Field
    {   
        public override Field clone()
        {
            return new Water();
        }
    }
}

/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace TheEarthQuake.Maps
{    
    /*
     * Non-destroyable wall, it is derived from Field, and
     * shouldn't contain bonus (there is no reason for that).
     */
    public class PersistentWall : Wall
    {
        public override Field clone()
        {
            return new PersistentWall();
        }    
    }
}

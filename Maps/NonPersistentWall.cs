/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace TheEarthQuake.Maps
{
    /*
     * Destroyable wall, it is derived from Field, and
     * can contain bonus.
     */
    public class NonPersistentWall : Wall
    {
        public override Field clone()
        {
            return new NonPersistentWall();
        }
    }
}

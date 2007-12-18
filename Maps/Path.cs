/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace TheEarthQuake.Maps
{
    /*
     * Simplest field, that player can walk on.
     * It is not intended to contain bonus, but it may
     */
    public class Path : Field
    {
        public override Field clone()
        {
            return new Path();
        }
    }
}

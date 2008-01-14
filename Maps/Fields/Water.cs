/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace TheEarthQuake.Maps
{
    /// <summary>
    /// This is non-walkable field, but blows can go through it. 
    /// It shouldn't contain bonuses.
    /// </summary>
    public class Water : Field
    {
        /// <summary>
        /// Clones field to avoid direct access to fields.
        /// </summary>
        /// <returns></returns>
        public override Field clone()
        {
            return new Water();
        }
    }
}

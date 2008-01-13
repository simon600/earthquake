/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace TheEarthQuake.Maps
{    
    /// <summary>
    /// Non-destroyable wall, it is derived from Field, and 
    /// shouldn't contain bonus (there is no reason for that).
    /// </summary>
    public class PersistentWall : Wall
    {
        /// <summary>
        /// Clones field to avoid direct access to fields.
        /// </summary>
        /// <returns></returns>
        public override Field clone()
        {
            return new PersistentWall();
        }    
    }
}

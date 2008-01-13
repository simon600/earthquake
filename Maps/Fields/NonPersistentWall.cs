/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace TheEarthQuake.Maps
{
    /// <summary>
    /// Destroyable wall, it is derived from Field, and can contain bonus.
    /// </summary>
    public class NonPersistentWall : Wall
    {
        /// <summary>
        /// Clones field to avoid direct access to fields.
        /// </summary>
        /// <returns></returns>
        public override Field clone()
        {
            NonPersistentWall returnNonPersistentWallField = new NonPersistentWall();
            returnNonPersistentWallField.Bonus = this.Bonus;
            return returnNonPersistentWallField;
        }
    }
}

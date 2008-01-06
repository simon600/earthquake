/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace TheEarthQuake.Maps

{
    /// <summary>
    /// Abstract class representing field. Field may contain bonus (see private Bonus bonus)
    /// </summary>
    public abstract class Field
    {
        private Bonuses.Bonus bonus;       

        /// <summary>
        /// Clones field to avoid direct access to fields.
        /// </summary>
        /// <returns></returns>
        public abstract Field clone();
        public Bonuses.Bonus Bonus
        {
            get
            {
                return bonus;
            }
            set
            {
                bonus = value;
            }
        }
    }
}

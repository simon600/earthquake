/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;
using TheEarthQuake.Bonuses;

namespace TheEarthQuake.Maps

{
    /// <summary>
    /// Abstract class representing field. Field may contain bonus (see private Bonus bonus)
    /// </summary>
    public abstract class Field
    {
        private Bonus bonus;       

        /// <summary>
        /// Clones field to avoid direct access to fields.
        /// </summary>
        /// <returns></returns>
        public abstract Field clone();
        public Bonus Bonus
        {
            get
            {
                return this.bonus;
            }
            set
            {
                this.bonus = value;
            }
        }
    }
}

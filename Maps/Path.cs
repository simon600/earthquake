/* Authors:
 *  Michal Anglart
 *  Karol Stosiek
 */

using System;

namespace TheEarthQuake.Maps
{
    /// <summary>
    /// Simplest field, that player can walk on. 
    /// It is not intended to contain bonus, but it may
    /// </summary>
    public class Path : Field
    {
        /// <summary>
        /// Clones field to avoid direct access to fields.
        /// </summary>
        /// <returns></returns>
        public override Field clone()
        {
            Path returnPathField = new Path();
            returnPathField.Bonus = this.Bonus;
            return returnPathField;
        }
    }
}

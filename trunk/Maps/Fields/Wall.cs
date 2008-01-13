using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Maps
{
    /// <summary>
    /// Representing both destroyable, and non-destroyable walls (abstract)
    /// </summary>
    public abstract class Wall : Field
    {
        /// <summary>
        /// Clones field to avoid direct access to fields.
        /// </summary>
        /// <returns></returns>
        public override abstract Field clone();
    }
}

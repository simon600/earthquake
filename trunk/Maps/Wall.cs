using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Maps
{
    /*
     * Representing both destroyable, and
     * non-destroyable walls;
     */
    public abstract class Wall : Field
    {
        public override abstract Field clone();
    }
}

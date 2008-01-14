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
        private Bomb.Bomb bomb;
        public Path()
        {
            this.bomb = null;
        }
        public Path(Field p)
        {
            this.Bonus = p.Bonus;
            this.bomb = null;
        }


        /// <summary>
        /// Clones field to avoid direct access to fields.
        /// </summary>
        /// <returns></returns>
        public override Field clone()
        {            
            Path returnPathField = new Path();
            returnPathField.Bonus = this.Bonus;
            returnPathField.Bomb = this.Bomb;
            return returnPathField;
        }
        public Bomb.Bomb Bomb
         {
            get
            {
                return this.bomb;
            }
            set
            {
                this.bomb = value;
            }
        }

       

        //seems broken! i dunno how to fix this yet, though
        public override bool HasBomb()
        {
            return this.bomb != null;
        }
        public override Bomb.Bomb GetBomb()
        {
            return this.bomb;
        }
        override public void InsertBomb(Bomb.Bomb b)
        {
            this.bomb = b;
            return;
        }
        public override void RemoveBomb()
        {
            this.bomb = null;
            return;
        }
    }
}

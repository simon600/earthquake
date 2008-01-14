using System;
using System.Collections.Generic;
using System.Text;
using TheEarthQuake.Maps.Bonuses;

namespace TheEarthQuake.Players
{
    public class PlayerBonuses
    {
        private List<Bonus> bonuses;

        public PlayerBonuses()
        {
            bonuses = new List<Bonus>();
        }

        internal void Add(Bonus B)
        {
            bonuses.Add(B);
        }

        internal Bonus Find(TypeOfBonus typeOfBonus)
        {
            foreach (Bonus B in bonuses)
            {
                if (B.Type == typeOfBonus)
                {
                    return B;
                }
            }
            return null;
        }

        internal void DeleteToOld()
        {
            foreach (Bonus B in bonuses)
            {
                if (B.End < DateTime.Now)
                {
                    bonuses.Remove(B);
                }
            }
        }
    }
}

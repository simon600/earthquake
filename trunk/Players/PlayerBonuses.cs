using System;
using System.Collections.Generic;
using System.Text;
using TheEarthQuake.Bonuses;

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

        internal Bonus DeleteToOld()
        {
            Bonus toDelete = null;
            
            for (int i = 0; i < bonuses.Count; i++)
            {
                if (bonuses[i].End < DateTime.Now)
                {
                    toDelete = bonuses[i];
                    break;
                }
                
            }
            if (toDelete != null)
            {
                bonuses.Remove(toDelete);
                return toDelete;
            }
            return null;
        }

    }
}

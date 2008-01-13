using System;
using System.Collections.Generic;
using System.Text;
using TheEarthQuake.Players;

namespace TheEarthQuake.Maps.Bonuses
{
    public enum TypeOfBonus
    { 
        Speed,
        Health,
        Kaczynski
    };

    public abstract class Bonus
    {
        internal TypeOfBonus type;
        internal int modyfication;


        public TypeOfBonus Type
        {
            get
            {
                return type;
            }
        }

        public int Modyfication
        {
            get 
            { 
                return modyfication; 
            }
            set 
            { 
                modyfication = value; 
            }
        }
        /// <summary>
        /// Acivate bonus
        /// </summary>
        public abstract void Activation(Player P);

    }

    public class SpeedBonus : Bonus
    {

        SpeedBonus()
        {
            type = TypeOfBonus.Speed;
            modyfication = 300;
        }

        public override void Activation(Player P)
        {
            //nothing
        }
    }

    public class HealthBonus : Bonus
    {
        public HealthBonus()
        {
            modyfication = 1000;
        }

        public override void Activation(Player P)
        {
            P.CurrentHealth = P.MaxHealth;
        }
    }

    public class KaczynskiBonus : Bonus
    {
        KaczynskiBonus()
        {
            type = TypeOfBonus.Kaczynski;
            modyfication = -1;
        }

        public override void Activation(Player P)
        {
            // Create 2 ducks !
        }
    }


}

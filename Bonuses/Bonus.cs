using System;
using System.Collections.Generic;
using System.Text;

namespace TheEarthQuake.Bonuses
{
    public enum TypeOfBonus
    { 
        Speed,
        Health,
        Kaczynski
    };

    public abstract class Bonus
    {
        protected TypeOfBonus type;
        protected int modyfication;
        protected DateTime start;
        protected DateTime end;

        
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

        public DateTime Start
        {
            get 
            { 
                return start; 
            }
            set 
            { 
                start = value; 
            }
        }


        public DateTime End
        {
            get 
            { 
                return end; 
            }
            set
            {
                end = value; 
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Bonus)
            {
                return this.Type == ((Bonus)obj).Type && this.Start == ((Bonus)obj).Start;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Activation bonus
        /// </summary>
        public abstract void Activation();

    }

    public class SpeedBonus : Bonus
    {

        public SpeedBonus()
        {
            type = TypeOfBonus.Speed;
            modyfication = 300;
            
        }

        public override void Activation()
        {
            start = DateTime.Now;
            end = DateTime.Now.AddSeconds(10.0);
        }
    }

    public class HealthBonus : Bonus
    {
        public HealthBonus()
        {
            modyfication = 1000;
        }

        public override void Activation()
        {
            start = DateTime.Now;
            end = DateTime.Now.AddYears(10);
        }
    }

    public class KaczynskiBonus : Bonus
    {
        KaczynskiBonus()
        {
            type = TypeOfBonus.Kaczynski;
            modyfication = -1;
            end = DateTime.Now.AddYears(10); 
        }

        public override void Activation()
        {
            start = DateTime.Now;
            end = DateTime.Now.AddYears(10);
        }
    }
}

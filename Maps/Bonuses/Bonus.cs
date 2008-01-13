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

        

        public abstract void Activate(Player P);
        public abstract void DeActivate(Player P);


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
    }

    public class SpeedBonus : Bonus
    {

        SpeedBonus()
        {
            type = TypeOfBonus.Speed;
        }


        public override void Activate(Player P)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void DeActivate(Player P)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    public class HealthBonus : Bonus
    {


        public override void Activate(Player P)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void DeActivate(Player P)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    public class KaczynskiBonus : Bonus
    {
        KaczynskiBonus()
        {
            type = TypeOfBonus.Kaczynski;
        }


        public override void Activate(Player P)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void DeActivate(Player P)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }


}

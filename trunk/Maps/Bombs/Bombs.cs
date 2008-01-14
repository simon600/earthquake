using TheEarthQuake.Maps;

namespace TheEarthQuake.Maps.Bomb
{

    public enum BombState
    {
        Waiting,
        Blow,
        ToRemove
    }


    public class Bomb
    {
        private const int bombWaitingDelayFactor = 300;
        private const int bombBlowingDelayFactor = 50;

        private int counter;
        private BombState _state;
        private float xPos;
        private float yPos;
        private int iPos;
        private int jPos;
        private bool blown;

        public BombState state
        {
            get
            {
                return _state;
            }
        }

        public float XPos
        {
            get
            {
                return xPos;
            }
        }

        public float YPos
        {
            get
            {
                return yPos;
            }
        }

        public int IPos
        {
            get
            {
                return iPos;
            }
        }

        public int JPos
        {
            get
            {
                return jPos;
            }
        }

        public bool Blown
        {
            get
            {
                return this.blown;
            }
            set
            {
                this.blown = value;
            }
        }

        public Bomb(float x, float y, int i, int j)
        {
            this.counter = bombWaitingDelayFactor;
            this.xPos = x;
            this.yPos = y;
            this.iPos = i;
            this.jPos = j;
            this._state = BombState.Waiting;
            this.blown = false;
        }

        public void tick()
        {
            switch (this._state)
            {
                case (BombState.Waiting):
                    --this.counter;
                    if (this.counter < 1)
                    {
                        this._state = BombState.Blow;
                        this.counter = bombBlowingDelayFactor;
                    }
                    break;
                case (BombState.Blow):
                    --this.counter;
                    if (this.counter < 1)
                    {
                        this._state = BombState.ToRemove;
                    }
                    break;
                case (BombState.ToRemove):
                    break;
                default:
                    throw new System.Exception("Illegal BombState (this._state) in Bomb.tick()");
            }
        }
        public float GetProgressFactor()
        {
            int full = 0;
            switch (this._state)
            {
                case (BombState.Waiting):
                    full = bombWaitingDelayFactor;
                    break;
                case (BombState.Blow):
                    full = bombBlowingDelayFactor;
                    break;
                case (BombState.ToRemove):
                    break;
                default:
                    throw new System.Exception("Illegal BobmbState (this._state) in Bomb.GetProgressFactor()");
            }
            return ((float)(full - this.counter)) / ((float)(full)) * 100.0f;
        }
    }

}